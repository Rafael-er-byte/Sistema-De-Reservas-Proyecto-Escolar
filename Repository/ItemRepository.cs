using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using SistemaDeReservas.Config;
using SistemaDeReservas.Model;

namespace SistemaDeReservas.Repository
{
    public class ItemRepository
    {
        private SqlConnection connection = Db.getConnection();

        public ItemRepository() { }

        // Inserta un ítem nuevo en la base de datos
        public Item Create(Item item)
        {
            const string query = @"
                INSERT INTO Item (name, description, price)
                VALUES (@name, @description, @price);
                SELECT SCOPE_IDENTITY();
            ";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@name", item.Name);

                if (item.Description == null)
                    command.Parameters.AddWithValue("@description", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@description", item.Description);

                command.Parameters.AddWithValue("@price", item.Price);

                connection.Open();
                int generatedId = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();

                return Item.CreateExisting(
                    generatedId,
                    item.Name,
                    item.Description,
                    item.Price
                );
            }
        }

        // Actualiza un ítem existente usando su id
        public void Update(Item item)
        {
            const string query = @"
                UPDATE Item
                SET name = @name,
                    description = @description,
                    price = @price
                WHERE id = @id
            ";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id", item.Id);
                command.Parameters.AddWithValue("@name", item.Name);

                if (item.Description == null)
                    command.Parameters.AddWithValue("@description", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@description", item.Description);

                command.Parameters.AddWithValue("@price", item.Price);

                connection.Open();
                int rows = command.ExecuteNonQuery();
                connection.Close();

                if (rows == 0)
                    throw new InvalidOperationException("No se encontró el ítem para actualizar.");
            }
        }

        // Busca un ítem por su id
        public Item GetById(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El id del ítem no es válido.");

            const string query = "SELECT id, name, description, price FROM Item WHERE id = @id";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id", id);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        connection.Close();
                        return null;
                    }

                    int itemId = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    string description = reader.IsDBNull(2) ? null : reader.GetString(2);
                    decimal price = reader.GetDecimal(3);

                    connection.Close();

                    return Item.CreateExisting(itemId, name, description, price);
                }
            }
        }

        // Busca ítems usando criterios dinámicos
        public List<Item> GetByCriteria(SearchItemCriteria criteria)
        {
            List<Item> items = new List<Item>();

            StringBuilder query = new StringBuilder();
            query.Append("SELECT id, name, description, price FROM Item WHERE 1 = 1 ");

            if (criteria.id > 0)
            {
                query.Append("AND id = @id ");
            }

            if (!string.IsNullOrWhiteSpace(criteria.name))
            {
                query.Append("AND name LIKE @name ");
            }

            using (SqlCommand command = new SqlCommand(query.ToString(), connection))
            {
                if (criteria.id > 0)
                {
                    command.Parameters.AddWithValue("@id", criteria.id);
                }

                if (!string.IsNullOrWhiteSpace(criteria.name))
                {
                    command.Parameters.AddWithValue("@name", "%" + criteria.name + "%");
                }

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        string description = reader.IsDBNull(2) ? null : reader.GetString(2);
                        decimal price = reader.GetDecimal(3);

                        items.Add(
                            Item.CreateExisting(id, name, description, price)
                        );
                    }
                }

                connection.Close();
            }

            return items;
        }

        // Elimina un ítem por su id
        public void Delete(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El id del ítem no es válido.");

            const string query = "DELETE FROM Item WHERE id = @id";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                int rows = command.ExecuteNonQuery();
                connection.Close();

                if (rows == 0)
                    throw new InvalidOperationException("No se encontró el ítem para eliminar.");
            }
        }

        public List<Item> GetAll()
        {
            List<Item> items = new List<Item>();

            const string query = "SELECT id, name, description, price FROM Item";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        items.Add(
                            Item.CreateExisting(
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.IsDBNull(2) ? null : reader.GetString(2),
                                reader.GetDecimal(3)
                            )
                        );
                    }
                }

                connection.Close();
            }

            return items;
        }

    }
}
