using System;

namespace SistemaDeReservas.Model
{
    public class Item
    {
        private int id;
        private string name;
        private string description;
        private decimal price;

        // Constructor privado para forzar el uso de factory methods
        private Item(int id, string name, string description, decimal price)
        {
            this.id = id;
            Name = name;
            Description = description;
            Price = price;
        }

        // Factory method para crear un ítem nuevo (sin id)
        public static Item CreateNew(string name, string description, decimal price)
        {
            return new Item(0, name, description, price);
        }

        // Factory method para crear un ítem existente (con id)
        public static Item CreateExisting(int id, string name, string description, decimal price)
        {
            if (id <= 0)
                throw new ArgumentException("El id del ítem no es válido.");

            return new Item(id, name, description, price);
        }

        // Devuelve el identificador del ítem
        // Lanza una excepción si el id aún no existe
        public int Id
        {
            get
            {
                if (id == 0)
                    throw new InvalidOperationException("El ítem aún no tiene un id asignado.");

                return id;
            }
        }

        // Permite obtener o cambiar el nombre del ítem
        // El nombre no puede estar vacío
        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El nombre del ítem no puede estar vacío.");

                name = value;
            }
        }

        // Permite obtener o cambiar la descripción del ítem
        // La descripción es opcional
        public string Description
        {
            get => description;
            set
            {
                description = string.IsNullOrWhiteSpace(value) ? null : value;
            }
        }

        // Permite obtener o cambiar el precio del ítem
        // El precio no puede ser negativo y se guarda con dos decimales
        public decimal Price
        {
            get => price;
            set
            {
                if (value < 0)
                    throw new ArgumentException("El precio no puede ser negativo.");

                price = Math.Round(value, 2);
            }
        }
    }
}
