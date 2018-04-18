using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TurnTen
{
    public class Game
    {
        CardStack drawStack, playStack;
        List<Card> dumpPile;
        Queue<Player> players;

        public event EventHandler<GameOverArgs> GameOver = delegate { };

        public Game(int playerAmount)
        {
            drawStack = CardStack.GenerateFullDeck();
            playStack = new CardStack();
            dumpPile = new List<Card>();
            players = new Queue<Player>(playerAmount);
            for(int i = 0; i < playerAmount; i++)
            {
                var player = new Player(
                                    new FrontCards(drawStack.DrawMany(3)),
                                    new FrontCards(drawStack.DrawMany(3)),
                                    drawStack.DrawMany(3));
                player.TurnTaken += TurnTaken;
                players.Enqueue(player);
            }
        }

        private void TurnTaken(object sender, EventArgs e)
        {
            var player = sender as Player;
            //Check if someone won
            //if not continue
            players.Enqueue(player);
            players.Dequeue().TakeTurn();
        }

        public void Run()
        {
            players.Dequeue().TakeTurn();
        }
    }

    public class GameOverArgs : EventArgs
    {
        public Player Winner { get; private set; }

        public GameOverArgs(Player winner)
        {
            Winner = winner;
        }
    }
}
