using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnTen
{
    public class Player
    {
        public FrontCards TopCards { get; private set; }
        public FrontCards BottomCards { get; private set; }
        public List<Card> Hand { get; private set; }

        public event EventHandler TurnTaken = delegate { };

		public Player()
        {
            TopCards = new FrontCards();
            BottomCards = new FrontCards();
            Hand = new List<Card>();
        }

		public Player(FrontCards topCards, FrontCards bottomCards, IEnumerable<Card> hand)
        {
            TopCards = topCards;
            BottomCards = bottomCards;
            Hand = new List<Card>(hand);
        }

        public void TakeTurn(CardStack playStack, List<Player> dumpPile, CardStack drawStack, IReadOnlyCollection<Player> players)
        {

        }
    }
}
