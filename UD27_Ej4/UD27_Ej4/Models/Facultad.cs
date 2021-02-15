using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UD27_Ej4.Models
{
    public class Facultad
    {
        public Facultad()
        {
            Investigadores = new HashSet<Investigador>();
            Equipos = new HashSet<Equipo>();
        }
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public ICollection<Investigador> Investigadores { get; set; }
        public ICollection<Equipo> Equipos { get; set; }

    }
}
