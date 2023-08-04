using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Models.Enums;

namespace BlackJack.Models.ElementosJuego
{
    internal class Carta
    {

        public Valores Valor { get; set; }
        public Palo Palo { get; set; }

        public Carta(Palo palo, Valores valor)
        {

            Valor = valor;
            Palo = palo;

        }



    }
}
