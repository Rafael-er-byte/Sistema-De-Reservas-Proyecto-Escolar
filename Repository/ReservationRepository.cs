using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using SistemaDeReservas.Config;
using SistemaDeReservas.Model;

namespace SistemaDeReservas.Repository
{
    public class ReservationRepository
    {
        private SqlConnection connection = Db.getConnection();

        public void Create(Reservation reservation)
        {
            using (SqlCommand cmd = new SqlCommand(@"
                INSERT INTO Reservation (persons, dateDay, idClient, idSchedule, status)
                VALUES (@persons, @dateDay, @idClient, @idSchedule, @status)
            ", connection))
            {
                cmd.Parameters.AddWithValue("@persons", reservation.Persons);
                cmd.Parameters.AddWithValue("@dateDay", reservation.ReservationDateTime.Date);
                cmd.Parameters.AddWithValue("@idClient", reservation.Client.Id);
                cmd.Parameters.AddWithValue("@idSchedule", reservation.Schedule.Id);
                cmd.Parameters.AddWithValue("@status", reservation.Status);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Update(Reservation reservation)
        {
            using (SqlCommand cmd = new SqlCommand(@"
                UPDATE Reservation
                SET persons = @persons,
                    dateDay = @dateDay,
                    idSchedule = @idSchedule
                WHERE id = @id
            ", connection))
            {
                cmd.Parameters.AddWithValue("@id", reservation.Id);
                cmd.Parameters.AddWithValue("@persons", reservation.Persons);
                cmd.Parameters.AddWithValue("@dateDay", reservation.ReservationDateTime.Date);
                cmd.Parameters.AddWithValue("@idSchedule", reservation.Schedule.Id);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }


        public void Delete(int reservationId)
        {
            if (reservationId <= 0)
                throw new ArgumentException("El id de la reservación no es válido.");

            using (SqlCommand cmd = new SqlCommand(
                "DELETE FROM Reservation WHERE id = @id", connection))
            {
                cmd.Parameters.AddWithValue("@id", reservationId);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void UpdateStatus(int reservationId, string newStatus)
        {
            if (reservationId <= 0)
                throw new ArgumentException("El id no es válido.");

            if (string.IsNullOrWhiteSpace(newStatus))
                throw new ArgumentException("El estado no es válido.");

            using (SqlCommand cmd = new SqlCommand(@"
                UPDATE Reservation
                SET status = @status
                WHERE id = @id
            ", connection))
            {
                cmd.Parameters.AddWithValue("@id", reservationId);
                cmd.Parameters.AddWithValue("@status", newStatus);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public List<Reservation> GetByCriteria(ReservationCriteria criteria)
        {
            if (string.IsNullOrWhiteSpace(criteria.status))
                throw new ArgumentException("El estado es obligatorio.");

            if (criteria.dateDay == DateTime.MinValue)
                throw new ArgumentException("La fecha es obligatoria.");

            List<Reservation> reservations = new List<Reservation>();

            StringBuilder query = new StringBuilder(@"
                SELECT 
                    r.id,
                    r.persons,
                    r.dateDay,
                    r.status,
                    c.id, c.name, c.tel, c.email,
                    s.id, s.startTime
                FROM Reservation r
                INNER JOIN Client c ON c.id = r.idClient
                INNER JOIN Schedule s ON s.id = r.idSchedule
                WHERE r.status = @status
                  AND r.dateDay = @dateDay
            ");

            bool isClientId =
                int.TryParse(criteria.clientNameLikeOrId, out int clientId);

            if (!string.IsNullOrWhiteSpace(criteria.clientNameLikeOrId))
            {
                if (isClientId)
                    query.Append(" AND c.id = @clientId");
                else
                    query.Append(" AND c.name LIKE @clientName");
            }

            if (criteria.dateHour != DateTime.MinValue)
                query.Append(" AND s.startTime = @startTime");

            using (SqlCommand cmd = new SqlCommand(query.ToString(), connection))
            {
                cmd.Parameters.AddWithValue("@status", criteria.status);
                cmd.Parameters.AddWithValue("@dateDay", criteria.dateDay.Date);

                if (!string.IsNullOrWhiteSpace(criteria.clientNameLikeOrId))
                {
                    if (isClientId)
                        cmd.Parameters.AddWithValue("@clientId", clientId);
                    else
                        cmd.Parameters.AddWithValue(
                            "@clientName",
                            $"%{criteria.clientNameLikeOrId}%"
                        );
                }

                if (criteria.dateHour != DateTime.MinValue)
                    cmd.Parameters.AddWithValue(
                        "@startTime",
                        criteria.dateHour.TimeOfDay
                    );

                connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Client client = Client.CreateExisting(
                            reader.GetInt32(4),
                            reader.GetString(5),
                            reader.GetString(6),
                            reader.IsDBNull(7) ? null : reader.GetString(7)
                        );

                        Schedule schedule = Schedule.CreateExisting(
                            reader.GetInt32(8),
                            reader.GetTimeSpan(9)
                        );

                        DateTime fullDateTime =
                            reader.GetDateTime(2).Date + schedule.StartTime;

                        reservations.Add(
                            Reservation.CreateExisting(
                                reader.GetInt32(0),   
                                client,
                                schedule,
                                fullDateTime,
                                reader.GetInt32(1),   
                                reader.GetString(3)   
                            )
                        );
                    }
                }

                connection.Close();
            }

            return reservations;
        }

    }
}
