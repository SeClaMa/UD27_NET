using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UD27_Ej3.Models
{
    public class Venta
    {
        public int IdCajero { get; set; }
        public int IdMaquina { get; set; }
        public int IdProducto { get; set; }
        public virtual Cajero Cajero { get; set; }
        public virtual Maquina_Registradora Maquina { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
