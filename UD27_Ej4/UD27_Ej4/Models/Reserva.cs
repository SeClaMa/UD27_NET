using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UD27_Ej4.Models
{
    public class Reserva
    {
        public string IdInvestigador { get; set; }
        public string IdEquipo { get; set; }
        public DateTime Comienzo { get; set; }
        public DateTime Fin { get; set; }
        public virtual Investigador Investigador { get; set; }
        public virtual Equipo Equipo { get; set; }
    }
}
