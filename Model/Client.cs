using System;
using System.Text.RegularExpressions;

namespace SistemaDeReservas.Model
{
    public class Client
    {
        private int id;
        private string name;
        private string tel;
        private string mail;

        // Constructor privado para forzar el uso de factory methods
        private Client(int id, string name, string tel, string mail)
        {
            this.id = id;
            Name = name;
            Tel = tel;
            Mail = mail;
        }

        // Factory method para crear un cliente nuevo (sin id)
        public static Client CreateNew(string name, string tel, string mail = null)
        {
            return new Client(0, name, tel, mail);
        }

        // Factory method para crear un cliente existente (con id)
        public static Client CreateExisting(int id, string name, string tel, string mail = null)
        {
            if (id <= 0)
                throw new ArgumentException("El id del cliente no es válido.");

            return new Client(id, name, tel, mail);
        }

        // Devuelve el identificador del cliente
        // Lanza una excepción si el id aún no existe
        public int Id
        {
            get
            {
                if (id == 0)
                    throw new InvalidOperationException("El cliente aún no tiene un id asignado.");

                return id;
            }
        }

        // Permite obtener o cambiar el nombre del cliente
        // El nombre no puede estar vacío
        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El nombre no puede estar vacío.");

                name = value;
            }
        }

        // Permite obtener o cambiar el número de teléfono del cliente
        // El teléfono es obligatorio, solo acepta números y máximo 10 dígitos
        public string Tel
        {
            get => tel;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El teléfono es obligatorio.");

                if (value.Length > 10)
                    throw new ArgumentException("El teléfono no puede tener más de 10 dígitos.");

                if (!Regex.IsMatch(value, @"^\d+$"))
                    throw new ArgumentException("El teléfono solo debe contener números.");

                tel = value;
            }
        }

        // Permite obtener o cambiar el correo electrónico del cliente
        // El correo es opcional, pero si se proporciona debe ser válido
        public string Mail
        {
            get => mail;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    mail = null;
                    return;
                }

                if (!Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                    throw new ArgumentException("El email no tiene un formato válido.");

                mail = value;
            }
        }
    }
}
