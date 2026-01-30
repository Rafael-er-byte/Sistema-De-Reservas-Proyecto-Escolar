using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SistemaDeReservas.Config;
using SistemaDeReservas.Model;

namespace SistemaDeReservas.Repository
{
    public class ScheduleRepository
    {
        private SqlConnection connection = Db.getConnection();

        public ScheduleRepository() { }

        // Crear horario
        public Schedule Create(Schedule schedule)
        {
            const string query = @"
                INSERT INTO Schedule (startTime)
                VALUES (@startTime);
                SELECT SCOPE_IDENTITY();
            ";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@startTime", schedule.StartTime);

                connection.Open();
                int generatedId = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();

                return Schedule.CreateExisting(
                    generatedId,
                    schedule.StartTime
                );
            }
        }

        // Eliminar horario por id
        public void Delete(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El id del horario no es válido.");

            const string query = "DELETE FROM Schedule WHERE id = @id";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                int rows = command.ExecuteNonQuery();
                connection.Close();

                if (rows == 0)
                    throw new InvalidOperationException("No se encontró el horario para eliminar.");
            }
        }

        // Obtener todos los horarios
        public List<Schedule> GetAll()
        {
            const string query = "SELECT id, startTime FROM Schedule";
            List<Schedule> schedules = new List<Schedule>();

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        schedules.Add(
                            Schedule.CreateExisting(
                                reader.GetInt32(0),
                                reader.GetTimeSpan(1)
                            )
                        );
                    }
                }

                connection.Close();
            }

            return schedules;
        }

        // Valida si ya existe un horario con la misma hora de inicio
        public bool ExistsByStartTime(TimeSpan startTime)
        {
            const string query = @"
        SELECT COUNT(1)
        FROM Schedule
        WHERE startTime = @startTime
    ";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@startTime", startTime);

                connection.Open();
                int count = (int)command.ExecuteScalar();
                connection.Close();

                return count > 0;
            }
        }

        public Schedule GetById(int id)
        {
            const string query = @"
                SELECT startTime
                FROM Schedule
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

                    TimeSpan startTime = reader.GetTimeSpan(0);

                    connection.Close();

                    return Schedule.CreateExisting(id, startTime);
                }
            }
        }
    }
}
