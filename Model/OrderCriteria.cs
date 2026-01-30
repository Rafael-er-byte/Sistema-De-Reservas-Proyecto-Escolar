using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeReservas.Model
{
    public class OrderCriteria
    {

        public string status { get; set; }// No opcional

        public string clientNameLikeOrId { get; set; } //opcional
    }
}
