using System.Collections.Generic;
using System.Linq;
using System;

namespace TurnTen
{
    public class FrontCards
    {
        Card card1, card2, card3;

		public FrontCards()
        {
            
        }

        public FrontCards(IEnumerable<Card> cards)
        {
            if (cards.Count() < 4)
                throw new ArgumentException();

            using(var enumerator = cards.GetEnumerator())
            {
                enumerator.MoveNext();
                card1 = enumerator.Current;
                enumerator.MoveNext();
                card2 = enumerator.Current;
                enumerator.MoveNext();
                card3 = enumerator.Current;
            }
        }

		public FrontCards(Card card1, Card card2, Card card3)
        {
            this.card1 = card1;
            this.card2 = card2;
            this.card3 = card3;
        }

        public ref Card Card1 { get => ref card1; }
        public ref Card Card2 { get => ref card2; }
        public ref Card Card3 { get => ref card3; }
    }
}
