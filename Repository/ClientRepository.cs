using SistemaDeReservas.Config;
using SistemaDeReservas.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SistemaDeReservas.Repository
{
    public class ClientRepository
    {
        private SqlConnection connection = Db.getConnection();

        public ClientRepository() { }

        // Inserta un cliente nuevo en la base de datos
        public Client Create(Client client)
        {
            const string query = @"
                INSERT INTO Client (name, tel, email)
                VALUES (@name, @tel, @mail);
                SELECT SCOPE_IDENTITY();
            ";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@name", client.Name);
                command.Parameters.AddWithValue("@tel", client.Tel);

                if (client.Mail == null)
                    command.Parameters.AddWithValue("@mail", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@mail", client.Mail);

                connection.Open();
                int generatedId = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();

                return Client.CreateExisting(
                    generatedId,
                    client.Name,
                    client.Tel,
                    client.Mail
                );
            }
        }

        // Actualiza la información de un cliente existente usando su id
        public void Update(Client client)
        {
            const string query = @"
                UPDATE Client
                SET name = @name,
                    tel = @tel,
                    email = @mail
                WHERE id = @id
            ";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id", client.Id);
                command.Parameters.AddWithValue("@name", client.Name);
                command.Parameters.AddWithValue("@tel", client.Tel);

                if (client.Mail == null)
                    command.Parameters.AddWithValue("@mail", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@mail", client.Mail);

                connection.Open();
                int rows = command.ExecuteNonQuery();
                connection.Close();

                if (rows == 0)
                    throw new InvalidOperationException("No se encontró el cliente para actualizar.");
            }
        }

        public List<Client> getByCriteria(SearchClientCriteria criteria)
        {
            List<Client> clients = new List<Client>();

            StringBuilder query = new StringBuilder();
            query.Append("SELECT id, name, tel, email FROM Client WHERE 1 = 1 ");

            if (criteria != null)
            {
                if (criteria.id > 0)
                    query.Append("AND id = @id ");

                if (!string.IsNullOrWhiteSpace(criteria.nameLike))
                    query.Append("AND name LIKE @nameLike ");
            }

            using (SqlCommand command = new SqlCommand(query.ToString(), connection))
            {
                if (criteria != null)
                {
                    if (criteria.id > 0)
                        command.Parameters.AddWithValue("@id", criteria.id);

                    if (!string.IsNullOrWhiteSpace(criteria.nameLike))
                        command.Parameters.AddWithValue("@nameLike", $"%{criteria.nameLike}%");
                }

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Client client = Client.CreateExisting(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.IsDBNull(3) ? null : reader.GetString(3)
                        );

                        clients.Add(client);
                    }
                }

                connection.Close();
            }

            return clients;
        }

        // Elimina un cliente por su id
        public void Delete(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El id del cliente no es válido.");

            const string query = "DELETE FROM Client WHERE id = @id";

            try
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    connection.Open();
                    int rows = command.ExecuteNonQuery();
                    connection.Close();

                    if (rows == 0)
                        throw new InvalidOperationException("No se encontró el cliente para eliminar.");
                }
            }
            catch (SqlException ex)
            {
                // Error 547 = violación de FOREIGN KEY
                if (ex.Number == 547)
                {
                    throw new InvalidOperationException(
                        "No se puede eliminar el cliente porque está siendo utilizado en reservas u órdenes."
                    );
                }

                // Cualquier otro error de SQL
                throw;
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
        }


        public List<Client> GetAll()
        {
            List<Client> clients = new List<Client>();

            const string query = "SELECT id, name, tel, email FROM Client";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clients.Add(
                            Client.CreateExisting(
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.IsDBNull(3) ? null : reader.GetString(3)
                            )
                        );
                    }
                }

                connection.Close();
            }

            return clients;
        }

        public Client GetById(int id)
        {
            const string query = @"
                SELECT id, name, tel, email
                FROM Client
                WHERE id = @id 
            ";

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

                    Client client = Client.CreateExisting(
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.IsDBNull(3) ? null : reader.GetString(3)
                            );

                    connection.Close();

                    return client;
                }
            }
        }
    }
}
  