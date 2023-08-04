using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Models
{
    internal class Mazo
    {

        public List<Carta> Cartas { get; set; }

        public Mazo()
        {

           this.Cartas = GetCartaList();
        
        }

        private static List<Carta> GetCartaList()
        {

            var list = new List<Carta>();


            for(int i = 0; i < 56; i++)
            {


                Carta card = CrearCarta();

                while(list.Any(e => e.Palo == card.Palo && e.Valor == card.Valor) == true)
                {
                    card = CrearCarta();
                }

                list.Add(card);

            }


            return list;

        }

        private static Carta CrearCarta()
        {

            Palo[] arrayPalos = new Palo[4];
            Valores[] arrayValores = new Valores[14];

            for(int i = 0; i < 4; i++)
            {

                arrayPalos[i] = (Palo)i;


            }

            for (int i = 0; i < 14; i++)
            {

                arrayValores[i] = (Valores)i;

            }

            Random random = new Random();


            return new Carta(arrayPalos[random.Next(0,4)], arrayValores[random.Next(0,14)]);
            
        }

    }
}
