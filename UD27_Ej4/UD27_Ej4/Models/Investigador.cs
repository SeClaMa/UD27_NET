using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UD27_Ej4.Models
{
    public class Investigador
    {
        public Investigador()
        {
            Reservas = new HashSet<Reserva>();
        }
        public int IdFacultad { get; set; }
        public string DNI { get; set; }
        public string NomApels { get; set; }
        public virtual Facultad Facultad { get; set; }
        public ICollection<Reserva> Reservas { get; set; }

    }
}
