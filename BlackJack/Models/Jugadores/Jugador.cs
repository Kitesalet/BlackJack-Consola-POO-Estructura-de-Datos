using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Models.ElementosJuego;

namespace BlackJack.Models.Jugadores
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
