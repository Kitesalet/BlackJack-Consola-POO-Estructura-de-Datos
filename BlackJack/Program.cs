using BlackJack.Models;

class Program
{
    static void Main(string[] args)
    {

        Juego blackjack = new Juego();

        blackjack.Jugar();

        Console.WriteLine("Juego terminado!");
    }


}