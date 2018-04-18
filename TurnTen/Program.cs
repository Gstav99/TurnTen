using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnTen
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(2);
            game.GameOver += Game_GameOver;
            game.Run();
        }

        private static void Game_GameOver(object sender, GameOverArgs e)
        {
            Console.WriteLine("Do ya'll want to play again(y/n)");
            if(Console.ReadLine() == "y")
            {
                Game game = new Game(2);
                game.GameOver += Game_GameOver;
                game.Run();
            }
        }
    }
}
