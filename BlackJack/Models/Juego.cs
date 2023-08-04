using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Models.Diccionario;
using BlackJack.Models.ElementosJuego;
using BlackJack.Models.Jugadores;

namespace BlackJack.Models
{
    internal class Juego
    {

        private Jugador Jugador { get; set; }
        private Dealer Dealer { get; set; }
        private Mazo Mazo { get; set; }
        private List<Carta> CartasEnMesa { get; set; }

        public Juego()
        {

            this.Mazo = new Mazo();

            this.CartasEnMesa = new List<Carta>();


        }


        private Carta AsignarCarta(int numero)
        {
            Random random = new Random();

            Carta cartaMazo = null;

            for (int i = 0; i < numero; i++)
            {
                cartaMazo = Mazo.Cartas[random.Next(0, Mazo.Cartas.Count - 1)];

                this.CartasEnMesa.Add(cartaMazo);

                Mazo.Cartas.Remove(cartaMazo);
            }

            return cartaMazo;

        }

        public void ComienzoJuego()
        {
            this.Jugador = new Jugador();
            this.Dealer = new Dealer();

            Console.WriteLine("Bienvenidos al BlackJack!");
            Console.WriteLine("");
            Console.WriteLine("");

            this.Jugador.Mano.Add(AsignarCarta(1));
            this.Jugador.Mano.Add(AsignarCarta(1));


            this.Dealer.Mano.Add(AsignarCarta(1));

            Console.WriteLine($"Las primera carta del jugador es {Jugador.Mano[0].Valor} de {Jugador.Mano[0].Palo}");
            Console.WriteLine($"Las segunda carta del jugador es {Jugador.Mano[1].Valor} de {Jugador.Mano[1].Palo}");

            Console.WriteLine("");

            Console.WriteLine($"La carta del dealer es {Dealer.Mano[0].Valor} de {Dealer.Mano[0].Palo}");

            Console.WriteLine("");

            Console.WriteLine("Presionar 1 ||Hit|| ------- Presionar 2 ||Stay||");
            Console.WriteLine();
        }

        public int VerificarOpcionValida()
        {

            int opcion = int.Parse(Console.ReadLine());

            while (opcion != 1 && opcion != 2)
            {
                Console.WriteLine("Por favor, seleccione una opcion valida");
                opcion = int.Parse(Console.ReadLine());
            }

            return opcion;
        }

        public void MostrarNuevaMano()
        {
            Jugador.Mano.Add(AsignarCarta(1));

            Console.WriteLine($"La {Jugador.Mano.Count} carta del jugador es {Jugador.Mano[Jugador.Mano.Count - 1].Valor} de {Jugador.Mano[Jugador.Mano.Count - 1].Palo}");
            Console.WriteLine();
            Jugador.Puntos = DiccionarioPuntajes.ObtenerPuntaje(Jugador.Mano);
            Console.WriteLine("Tus puntos actuales son: {0}", Jugador.Puntos);
        }

        public void HitLoop(int opcion)
        {
            while (Jugador.Perdio == false || Jugador.Stand == true)
            {
                if (opcion == 1)
                {

                    MostrarNuevaMano();

                    if (Jugador.Puntos > 21)
                    {
                        Jugador.Perdio = true;
                    }
                    else
                    {
                        opcion = VerificarOpcionValida();

                        if (opcion == 2)
                        {
                            Jugador.Stand = true;
                        }
                    }

                }
            }
        }
        public void DealerLoop()
        {
            Dealer.Puntos = DiccionarioPuntajes.ObtenerPuntaje(Dealer.Mano);

            Console.WriteLine("Los puntos iniciales del dealer son {0}", Dealer.Puntos);

            do
            {
                Dealer.Mano.Add(AsignarCarta(1));

                Dealer.Puntos = DiccionarioPuntajes.ObtenerPuntaje(Dealer.Mano);

                Console.WriteLine("");
                Console.WriteLine($"La carta que saco el Dealer es {Dealer.Mano[Dealer.Mano.Count - 1].Valor} de {Dealer.Mano[Dealer.Mano.Count - 1].Palo}");
                Console.WriteLine($"Los nuevos puntos del Dealer son {Dealer.Puntos}");
                Console.WriteLine("");

                if (Dealer.Puntos > Jugador.Puntos && Dealer.Puntos <= 21)
                {

                    Jugador.Perdio = true;

                }


            } while (Dealer.Puntos <= Jugador.Puntos && Dealer.Perdio == false || Jugador.Perdio == false);
        }
        public void Jugar()
        {
            ComienzoJuego();

            int opcion = VerificarOpcionValida();

            HitLoop(opcion);

            if (Jugador.Perdio == true)
            {
                Console.WriteLine($"Perdiste en el hit, llegaste a los {Jugador.Puntos} puntos...");
            } else if (Jugador.Stand == true)
            {
                DealerLoop();

                if (Jugador.Perdio == true)
                {
                    Console.WriteLine($"El Dealer te gano con {Dealer.Puntos} Puntos");
                }
                else
                {
                    Console.WriteLine($"Le ganaste al Dealer con {Jugador.Puntos}, el tenia {Dealer.Puntos}");
                }

            }



        }




    }
}
