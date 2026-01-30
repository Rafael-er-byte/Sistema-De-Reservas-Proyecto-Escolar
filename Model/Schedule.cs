using System;

namespace SistemaDeReservas.Model
{
    public class Schedule
    {
        private int id;
        private readonly TimeSpan startTime;

        // Constructor privado para forzar el uso de factory methods
        private Schedule(int id, TimeSpan startTime)
        {
            if (startTime < TimeSpan.Zero || startTime >= TimeSpan.FromDays(1))
                throw new ArgumentException("El horario debe ser una hora válida en formato 00:00.");

            this.id = id;
            this.startTime = startTime;
        }

        // Factory method para crear un horario nuevo (sin id)
        public static Schedule CreateNew(TimeSpan startTime)
        {
            return new Schedule(0, startTime);
        }

        // Factory method para crear un horario existente (con id)
        public static Schedule CreateExisting(int id, TimeSpan startTime)
        {
            if (id <= 0)
                throw new ArgumentException("El id del horario no es válido.");

            return new Schedule(id, startTime);
        }

        // Devuelve el identificador del horario
        // Lanza una excepción si el id aún no existe
        public int Id
        {
            get
            {
                if (id == 0)
                    throw new InvalidOperationException("El horario aún no tiene un id asignado.");

                return id;
            }
        }

        // Devuelve la hora de inicio del horario
        public TimeSpan StartTime
        {
            get => startTime;
        }
    }
}
