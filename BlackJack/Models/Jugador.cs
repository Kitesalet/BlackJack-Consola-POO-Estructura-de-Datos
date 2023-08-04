using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Models
{
    internal class Jugador : Persona
    {
        public bool Stand { get; set; } = false;    
        public Jugador()
        {

            Mano = new List<Carta>();
        
        }



    }
}
