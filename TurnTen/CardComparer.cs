using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnTen
{
    class CardComparer : EqualityComparer<Card>
    {
        public CardComparer()
        { }

        public override bool Equals(Card x, Card y) => x.Number == y.Number && x.Suit == y.Suit;
        public override int GetHashCode(Card obj) => obj.GetHashCode();
    }
}
