using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Models
{
    internal abstract class Persona
    {

        public int Puntos { get; set; }

        public bool Perdio { get; set; }

        public List<Carta> Mano { get; set; }

    }
}
