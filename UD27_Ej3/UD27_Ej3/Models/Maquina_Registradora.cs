using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UD27_Ej3.Models
{
    public class Maquina_Registradora
    {
        public Maquina_Registradora()
        {
            Ventas = new HashSet<Venta>();
        }
        public int Codigo { get; set; }
        public int Piso { get; set; }
        public ICollection<Venta> Ventas { get; set; }
    }
}
