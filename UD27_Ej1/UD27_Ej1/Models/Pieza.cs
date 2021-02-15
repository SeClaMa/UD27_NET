using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UD27_Ej1.Models
{
    public class Pieza
    {
        public Pieza()
        {
            Suministras = new HashSet<Suministra>();
        }
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public ICollection<Suministra> Suministras { get; set; }
    }
}
