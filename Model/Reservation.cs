using System;

namespace SistemaDeReservas.Model
{
    public class Reservation
    {
        private int id;
        private Client client;
        private Schedule schedule;
        private DateTime reservationDateTime;
        private int persons;
        private string status;

        // Constructor privado para forzar el uso de factory methods
        private Reservation(
            int id,
            Client client,
            Schedule schedule,
            DateTime reservationDateTime,
            int persons,
            string status)
        {
            this.id = id;
            this.client = client;
            this.schedule = schedule;
            this.reservationDateTime = reservationDateTime;
            this.persons = persons;
            this.status = status;
        }

        // Factory method para crear una nueva reservación
        // Valida que la fecha y hora resultante estén en el futuro
        public static Reservation CreateNew(
            Client client,
            DateTime day,
            Schedule schedule,
            int persons)
        {
            if (client == null)
                throw new ArgumentException("La reservación debe tener un cliente.");

            if (schedule == null)
                throw new ArgumentException("La reservación debe tener un horario.");

            if (persons < 1)
                throw new ArgumentException("El número de personas debe ser mayor a cero.");

            DateTime fullDateTime = day.Date + schedule.StartTime;

            if (fullDateTime <= DateTime.Now)
                throw new ArgumentException("La fecha y hora de la reservación deben ser futuras.");

            return new Reservation(
                0,
                client,
                schedule,
                fullDateTime,
                persons,
                "Pendiente"
            );
        }

        // Factory method para crear una reservación ya existente
        // Solo valida formato, no si la fecha es futura
        public static Reservation CreateExisting(
            int id,
            Client client,
            Schedule schedule,
            DateTime reservationDateTime,
            int persons,
            string status)
        {
            if (id <= 0)
                throw new ArgumentException("El id de la reservación no es válido.");

            if (client == null)
                throw new ArgumentException("La reservación debe tener un cliente.");

            if (schedule == null)
                throw new ArgumentException("La reservación debe tener un horario.");

            if (persons < 1)
                throw new ArgumentException("El número de personas debe ser mayor a cero.");

            if (string.IsNullOrWhiteSpace(status))
                throw new ArgumentException("El estado de la reservación no es válido.");

            return new Reservation(
                id,
                client,
                schedule,
                reservationDateTime,
                persons,
                status
            );
        }

        // Cambia el estado de la reservación a cancelada
        public void Cancel()
        {
            status = "Cancelada";
        }

        // Cambia el estado de la reservación a finalizada
        public void Finish()
        {
            if (status == "Cancelada")
                throw new InvalidOperationException("No se puede finalizar una reservación cancelada.");

            status = "Finalizada";
        }

        // Indica si la reservación ya caducó según la fecha y hora actual
        public bool IsExpired()
        {
            return DateTime.Now > reservationDateTime && status == "Pendiente";
        }

        // Getters

        public int Id
        {
            get
            {
                if (id == 0)
                    throw new InvalidOperationException("La reservación aún no tiene un id asignado.");

                return id;
            }
        }

        public Client Client
        {
            get => client;
        }

        public Schedule Schedule
        {
            get => schedule;
        }

        public DateTime ReservationDateTime
        {
            get => reservationDateTime;
        }

        public int Persons
        {
            get => persons;
        }

        public string Status
        {
            get => status;
        }
    }
}
