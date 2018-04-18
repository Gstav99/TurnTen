using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnTen
{
    /// <summary>
    /// Holds up to 52 unique playing cards
    /// </summary>
    class CardStack : IEnumerable<Card>, IEnumerable, IReadOnlyCollection<Card>
    {
        private const int MaximumCount = 52;

        private Card[] stack;
        private int count;
        private CardComparer comparer;

        public CardStack(IEnumerable<Card> collection)
            : this()
        {
            foreach(Card card in collection.Reverse())
            {
                Push(card);
            }
        }

        public CardStack()
        {
            stack = new Card[MaximumCount];
            count = 0;
            comparer = new CardComparer();
        }

        public int Count => count;

        public void Push(Card card)
        {
            //Check that the card isn't already added
            if (stack.Contains(card, comparer))
                throw new InvalidOperationException("That card is already in this collection");

            stack[count++] = card;
        }

        public Card Draw()
        {
            Card returnValue = stack[--count];
            stack[count] = default(Card);
            return returnValue;
        }

        public List<Card> DrawMany(int amount)
        {
            var returnValue = new List<Card>();
            for(int i = 0; i < amount; i++)
            {
                returnValue.Add(Draw());
            }
            return returnValue;
        }

        public Card Peek()
        {
            return stack[count - 1];
        }

        public void Shuffle()
        {
            var random = new Random();
            for(int i = count / 2; i > 0; i--)
            {
                Switch(stack, random.Next(count), random.Next(count));
            }
        }

        private void Switch(Card[] cards, int index1, int index2)
        {
            Card temp = cards[index1];
            cards[index1] = cards[index2];
            cards[index2] = temp;
        }

        public void Clear()
        {
            stack = new Card[MaximumCount];
            count = 0;
        }

        public void CopyTo(Card[] array, int arrayIndex)
        {
            Array.Copy(stack, 0, array, arrayIndex, count);
        }

        public IEnumerator<Card> GetEnumerator()
        {
            for(int i = count - 1; i >= 0; i--)
            {
                yield return stack[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public static CardStack GenerateFullDeck()
        {
            var stack = new CardStack();
            for(int suit = 0; suit < 4; suit++)
            {
                for(int number = 1; number < 13; number++)
                {
                    stack.Push(new Card()
                    {
                        Number = number,
                        Suit = (CardSuit)suit
                    });
                }
            }
            return stack;
        } 
    }
}
