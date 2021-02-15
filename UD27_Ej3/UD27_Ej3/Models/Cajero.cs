using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UD27_Ej3.Models
{
    public class Cajero
    {
        public Cajero()
        {
            Ventas = new HashSet<Venta>();
        }
        public int Codigo { get; set; }
        public string NomApels { get; set; }
        public ICollection<Venta> Ventas { get; set; }
    }
}
