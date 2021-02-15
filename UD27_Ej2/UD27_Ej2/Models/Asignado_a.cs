using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UD27_Ej2.Models
{
    public class Asignado_a
    {
        public string IdCientifico { get; set; }
        public string IdProyecto { get; set; }
        public virtual Cientifico Cientifico { get; set; }
        public virtual Proyecto Proyecto { get; set; }
    }
}
