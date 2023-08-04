using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Models.ElementosJuego;
using BlackJack.Models.Enums;

namespace BlackJack.Models.Diccionario
{
    internal static class DiccionarioPuntajes
    {

        public static Dictionary<Valores, int> ValoresPuntos;


        public static int ObtenerPuntaje(List<Carta> cartas)
        {

            int acumulado = 0;

            ValoresPuntos = new Dictionary<Valores, int>()
            {

                {Valores.N1, 1 },
                {Valores.N2, 2 },
                {Valores.N3, 3 },
                {Valores.N4, 4 },
                {Valores.N5, 5 },
                {Valores.N6, 6 },
                {Valores.N7, 7 },
                {Valores.N8, 8 },
                {Valores.N9, 9 },
                {Valores.N10, 10 },
                {Valores.J, 10 },
                {Valores.K, 10 },
                {Valores.Q,10 },
                {Valores.A,1 },


            };

            foreach (Carta card in cartas)
            {

                acumulado += ValoresPuntos[card.Valor];

            }



            return acumulado;
        }



    }
}
