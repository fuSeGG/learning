using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace PreFlopPlayer
{
    public class Deck
    {
        List<Card> cards = new List<Card>();
        Random rand = new Random();

        public void NewDeck()
        {
            if (this.cards.Count != 0) this.cards.Clear();
            foreach (Suit suit in (Suit[])Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in (Rank[])Enum.GetValues(typeof(Rank)))
                {
                    this.cards.Add(new Card(rank, suit));
                }
            }
        }

        public List<Card> DealHand(List<Card> hand, Deck d)
        {
            hand.Add(d.TakeTopCard());
            hand.Add(d.TakeTopCard());
            return hand;
        }

        public void Shuffle()
        {
            for (int i = this.cards.Count - 1; i > 0; i--)
            {
                int randomIndex = this.rand.Next(i + 1);
                Card tempCard = this.cards[i];
                this.cards[i] = this.cards[randomIndex];
                this.cards[randomIndex] = tempCard;
            }
        }

        public void ShowDeck()
        {
            foreach (var card in this.cards)
            {
                WriteLine(card.Rank + "(" + card.Suit + ")");
            }
        }

        public bool isEmpty
        {
            get { return this.cards.Count == 0; }
        }

        public Card TakeTopCard()
        {
            if (!this.isEmpty)
            {
                Card topCard = this.cards[this.cards.Count - 1];
                this.cards.RemoveAt(this.cards.Count - 1);
                return topCard;
            }
            else
            {
                return null;
            }
        }

        public void NewHand(Deck deck, List<Player> players)
        {
            deck.NewDeck();
            deck.Shuffle();
            foreach (var p in players)
            {
                // Move the Dealer BTN                
                // p.Position = PositionDictionary.

                // Post Blinds
                if (p.Position == Positions.SB) { p.Stack -= 0.5; p.SetHasBet(0.5); }
                else if (p.Position == Positions.BB) { p.Stack -= 1; p.SetHasBet(1);}

                // Deal Hands
                if (p.Hand.Count != 0) p.Hand.Clear();
                deck.DealHand(p.Hand, deck);
            }
        }

        public void DealFlop(Deck deck)
        {
            Card a = deck.TakeTopCard();
            Card b = deck.TakeTopCard();
            Card c = deck.TakeTopCard();
            Console.WriteLine(a.Rank + " of " + a.Suit + ", " + b.Rank + " of " + b.Suit + ", " + c.Rank + " of " + c.Suit);
        }
    }
}
