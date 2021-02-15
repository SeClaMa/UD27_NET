using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UD27_Ej1.Models
{
    public class Proveedor
    {
        public Proveedor()
        {
            Suministras = new HashSet<Suministra>();
        }
        public string Id { get; set; }
        public string Nombre { get; set; }
        public ICollection<Suministra> Suministras { get; set; }

    }
}
