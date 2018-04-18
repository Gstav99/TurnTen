using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnTen
{
    public struct Card : IComparable<Card>
    {
        public int Number { get; set; }
        public CardSuit Suit { get; set; }

        public int CompareTo(Card other) => throw new NotImplementedException();
    }

    public enum CardSuit
    {
        Heart,
        Clove,
        Diamond,
        Spade
    }
}
