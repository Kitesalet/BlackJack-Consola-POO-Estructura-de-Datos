using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Models.ElementosJuego;

namespace BlackJack.Models.Jugadores
{
    internal class Dealer : Persona
    {

        public Dealer()
        {

            Mano = new List<Carta>();

        }

    }
}
