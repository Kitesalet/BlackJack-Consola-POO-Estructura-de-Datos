using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Models
{
    internal class Carta
    {
        
        public Valores Valor { get; set; }
        public Palo Palo { get; set; }

        public Carta(Palo palo, Valores valor)
        {

            this.Valor = valor;
            this.Palo = palo;
        
        }



    }
}
