using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UD27_Ej2.Models
{
    public class Cientifico
    {
        public Cientifico()
        {
            Asignados_a = new HashSet<Asignado_a>();
        }
        public string DNI { get; set; }
        public string NomApels { get; set; }
        public ICollection<Asignado_a> Asignados_a { get; set; }
    }
}
