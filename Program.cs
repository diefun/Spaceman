using System;

namespace Spaceman
{
  class Program
  {
    static void Main(string[] args)
    {
            Game playGame = new Game();
            playGame.Greet();

            do
            {
                playGame.Display();
                playGame.Ask();

                if (playGame.DidLoose())
                {
                    Console.WriteLine("Oh no! The person was abducted!!!");
                    break;
                }
                else if (playGame.DidWin())
                {
                    Console.WriteLine("Yeah!!! You save another person!");
                    break;
                }
            } while (true);
    }
  }
}
