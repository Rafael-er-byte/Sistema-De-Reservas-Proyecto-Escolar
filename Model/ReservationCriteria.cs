using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeReservas.Model
{
    public class ReservationCriteria
    {
        public string clientNameLikeOrId { get; set; }
        public string status { get; set; }// obligatorio

        public DateTime dateDay { get; set; }// obligatorio

        public DateTime dateHour { get; set; }
    }
}
