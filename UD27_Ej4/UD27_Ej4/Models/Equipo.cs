using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UD27_Ej4.Models
{
    public class Equipo
    {
        public Equipo()
        {
            Reservas = new HashSet<Reserva>();
        }
        public int IdFacultad { get; set; }
        public string NumSerie { get; set; }
        public string Nombre { get; set; }
        public virtual Facultad Facultad { get; set; }
        public ICollection<Reserva> Reservas { get; set; }

    }
}
