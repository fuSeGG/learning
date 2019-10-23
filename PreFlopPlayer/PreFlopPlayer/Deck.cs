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
            if (cards.Count != 0) cards.Clear();
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
            for (int i = cards.Count - 1; i > 0; i--)
            {
                int randomIndex = rand.Next(i + 1);
                Card tempCard = cards[i];
                cards[i] = cards[randomIndex];
                cards[randomIndex] = tempCard;
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
                Card topCard = cards[cards.Count - 1];
                cards.RemoveAt(cards.Count - 1);
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
                if (p.Position is "SB") { p.Stack -= 0.5; p.SetHasBet(0.5); }
                else if (p.Position is "BB") { p.Stack -= 1; p.SetHasBet(1);}

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
