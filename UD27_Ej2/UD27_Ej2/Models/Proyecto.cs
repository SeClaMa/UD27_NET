using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UD27_Ej2.Models
{
    public class Proyecto
    {
        public Proyecto()
        {
            Asignados_a = new HashSet<Asignado_a>();
        }

        public string Id { get; set; }
        public string Nombre { get; set; }
        public int Horas { get; set; }
        public ICollection<Asignado_a> Asignados_a { get; set; }

    }
}
