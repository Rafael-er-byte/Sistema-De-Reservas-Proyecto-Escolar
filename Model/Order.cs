using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaDeReservas.Model
{
    public class Order
    {
        private int id;
        private int idClient;
        private DateTime date;
        private string status;
        private decimal total;

        private Dictionary<Item, int> items;

        private const string STATUS_PENDING = "Pendiente";
        private const string STATUS_CONFIRMED = "Confirmada";
        private const string STATUS_CANCELLED = "Cancelada";

        private Order(
            int id,
            int idClient,
            DateTime date,
            string status,
            Dictionary<Item, int> items)
        {
            this.id = id;
            this.idClient = idClient;
            this.date = date;
            this.status = status;

            this.items = items ?? new Dictionary<Item, int>();
            CalculateTotal();
        }

        // 🔹 Crear orden nueva
        public static Order CreateNew(
            int idClient,
            Dictionary<Item, int> items)
        {
            if (idClient <= 0)
                throw new ArgumentException("El cliente de la orden no es válido.");

            ValidateItems(items);

            return new Order(
                0,
                idClient,
                DateTime.Now,
                STATUS_PENDING,
                items
            );
        }

        // 🔹 Crear orden existente
        public static Order CreateExisting(
            int id,
            int idClient,
            DateTime date,
            string status,
            Dictionary<Item, int> items)
        {
            if (id <= 0)
                throw new ArgumentException("El id de la orden no es válido.");

            if (idClient <= 0)
                throw new ArgumentException("El cliente de la orden no es válido.");

            if (string.IsNullOrWhiteSpace(status))
                throw new ArgumentException("El estado de la orden no es válido.");

            ValidateItems(items);

            return new Order(id, idClient, date, status, items);
        }

        // 🔹 Validación centralizada
        private static void ValidateItems(Dictionary<Item, int> items)
        {
            if (items == null || items.Count == 0)
                throw new ArgumentException("La orden debe tener al menos un ítem.");

            foreach (var pair in items)
            {
                if (pair.Key == null)
                    throw new ArgumentException("El ítem no puede ser nulo.");

                if (pair.Value <= 0)
                    throw new ArgumentException("La cantidad del ítem debe ser mayor a cero.");
            }
        }

        public int Id
        {
            get
            {
                if (id == 0)
                    throw new InvalidOperationException("La orden aún no tiene un id asignado.");

                return id;
            }
        }

        public int IdClient => idClient;
        public DateTime Date => date;
        public string Status => status;
        public decimal Total => total;

        public IReadOnlyDictionary<Item, int> Items => items;

        private void CalculateTotal()
        {
            total = items.Sum(i => i.Key.Price * i.Value);
        }

        public void ConfirmOrder()
        {
            if (status == STATUS_CANCELLED)
                throw new InvalidOperationException("No se puede confirmar una orden cancelada.");

            status = STATUS_CONFIRMED;
        }

        public void CancelOrder()
        {
            status = STATUS_CANCELLED;
        }
    }
}
