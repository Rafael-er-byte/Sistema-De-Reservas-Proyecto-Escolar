using SistemaDeReservas.Config;
using SistemaDeReservas.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SistemaDeReservas.Repository
{
    public class OrderRepository
    {
        private SqlConnection connection = Db.getConnection();

        // Crear orden
        public void Create(Order order)
        {
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                int orderId;

                string insertOrder = @"
                    INSERT INTO Orders (idClient, total, orderStatus)
                    VALUES (@idClient, @total, @status);
                    SELECT SCOPE_IDENTITY();
                ";

                using (SqlCommand cmd = new SqlCommand(insertOrder, connection, transaction))
                {
                    cmd.Parameters.AddWithValue("@idClient", order.IdClient);
                    cmd.Parameters.AddWithValue("@total", order.Total);
                    cmd.Parameters.AddWithValue("@status", order.Status);

                    orderId = Convert.ToInt32(cmd.ExecuteScalar());
                }

                InsertOrderItems(orderId, order, transaction);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        // Actualizar orden
        public void Update(Order order)
        {
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                string updateOrder = @"
                    UPDATE Orders
                    SET idClient = @idClient,
                        total = @total,
                        orderStatus = @status
                    WHERE id = @id
                ";

                using (SqlCommand cmd = new SqlCommand(updateOrder, connection, transaction))
                {
                    cmd.Parameters.AddWithValue("@id", order.Id);
                    cmd.Parameters.AddWithValue("@idClient", order.IdClient);
                    cmd.Parameters.AddWithValue("@total", order.Total);
                    cmd.Parameters.AddWithValue("@status", order.Status);
                    cmd.ExecuteNonQuery();
                }

                SyncOrderItems(order.Id, order, transaction);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        // Eliminar orden
        public void Delete(int orderId)
        {
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                using (SqlCommand cmd = new SqlCommand(
                    "DELETE FROM OrderItem WHERE idOrder = @id", connection, transaction))
                {
                    cmd.Parameters.AddWithValue("@id", orderId);
                    cmd.ExecuteNonQuery();
                }

                using (SqlCommand cmd = new SqlCommand(
                    "DELETE FROM Orders WHERE id = @id", connection, transaction))
                {
                    cmd.Parameters.AddWithValue("@id", orderId);
                    cmd.ExecuteNonQuery();
                }

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        // Insertar items de la orden
        private void InsertOrderItems(int orderId, Order order, SqlTransaction transaction)
        {
            string insertItem = @"
                INSERT INTO OrderItem (idOrder, idItem, quantity)
                VALUES (@idOrder, @idItem, @quantity)
            ";

            foreach (var pair in order.Items)
            {
                using (SqlCommand cmd = new SqlCommand(insertItem, connection, transaction))
                {
                    cmd.Parameters.AddWithValue("@idOrder", orderId);
                    cmd.Parameters.AddWithValue("@idItem", pair.Key.Id);
                    cmd.Parameters.AddWithValue("@quantity", pair.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Sincronizar items de la orden
        private void SyncOrderItems(int orderId, Order order, SqlTransaction transaction)
        {
            using (SqlCommand cmd = new SqlCommand(
                "DELETE FROM OrderItem WHERE idOrder = @idOrder", connection, transaction))
            {
                cmd.Parameters.AddWithValue("@idOrder", orderId);
                cmd.ExecuteNonQuery();
            }

            InsertOrderItems(orderId, order, transaction);
        }

        // Buscar órdenes por criterio
        public List<Order> GetByCriteria(OrderCriteria criteria)
        {
            if (string.IsNullOrWhiteSpace(criteria.status))
                throw new ArgumentException("El estado es obligatorio.");

            List<Order> orders = new List<Order>();

            StringBuilder query = new StringBuilder(@"
                SELECT 
                    o.id,
                    o.madeAt,
                    o.orderStatus,
                    o.idClient,
                    i.id,
                    i.name,
                    i.description,
                    i.price,
                    oi.quantity
                FROM Orders o
                INNER JOIN Client c ON c.id = o.idClient
                LEFT JOIN OrderItem oi ON oi.idOrder = o.id
                LEFT JOIN Item i ON i.id = oi.idItem
                WHERE o.orderStatus = @status
            ");

            bool isId = int.TryParse(criteria.clientNameLikeOrId, out int clientId);

            if (!string.IsNullOrWhiteSpace(criteria.clientNameLikeOrId))
            {
                if (isId)
                    query.Append(" AND c.id = @clientId");
                else
                    query.Append(" AND c.name LIKE @clientName");
            }

            using (SqlCommand cmd = new SqlCommand(query.ToString(), connection))
            {
                cmd.Parameters.AddWithValue("@status", criteria.status);

                if (!string.IsNullOrWhiteSpace(criteria.clientNameLikeOrId))
                {
                    if (isId)
                        cmd.Parameters.AddWithValue("@clientId", clientId);
                    else
                        cmd.Parameters.AddWithValue("@clientName", $"%{criteria.clientNameLikeOrId}%");
                }

                connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // Acumuladores
                    Dictionary<int, int> orderClientMap = new Dictionary<int, int>();
                    Dictionary<int, DateTime> orderDateMap = new Dictionary<int, DateTime>();
                    Dictionary<int, string> orderStatusMap = new Dictionary<int, string>();
                    Dictionary<int, Dictionary<Item, int>> orderItemsMap =
                        new Dictionary<int, Dictionary<Item, int>>();

                    while (reader.Read())
                    {
                        int orderId = reader.GetInt32(0);

                        // Inicializar la orden si no existe
                        if (!orderItemsMap.ContainsKey(orderId))
                        {
                            orderClientMap[orderId] = reader.GetInt32(3);
                            orderDateMap[orderId] = reader.GetDateTime(1);
                            orderStatusMap[orderId] = reader.GetString(2);
                            orderItemsMap[orderId] = new Dictionary<Item, int>();
                        }

                        // Si hay item
                        if (!reader.IsDBNull(4))
                        {
                            Item item = Item.CreateExisting(
                                reader.GetInt32(4),   // id
                                reader.GetString(5),  // name
                                reader.GetString(6),  // description
                                reader.GetDecimal(7)  // price
                            );

                            int quantity = reader.GetInt32(8);
                            orderItemsMap[orderId][item] = quantity;
                        }
                    }

                    // Crear órdenes YA COMPLETAS
                    foreach (int orderId in orderItemsMap.Keys)
                    {
                        orders.Add(
                            Order.CreateExisting(
                                orderId,
                                orderClientMap[orderId],
                                orderDateMap[orderId],
                                orderStatusMap[orderId],
                                orderItemsMap[orderId]
                            )
                        );
                    }
                }

                connection.Close();
            }

            return orders;
        }


        // Actualizar estado de la orden
        public void UpdateStatus(int orderId, string newStatus)
        {
            if (orderId <= 0)
                throw new ArgumentException("El id de la orden no es válido.");

            if (string.IsNullOrWhiteSpace(newStatus))
                throw new ArgumentException("El estado no es válido.");

            using (SqlCommand cmd = new SqlCommand(@"
                UPDATE Orders
                SET orderStatus = @status
                WHERE id = @id
            ", connection))
            {
                cmd.Parameters.AddWithValue("@id", orderId);
                cmd.Parameters.AddWithValue("@status", newStatus);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
