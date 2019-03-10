using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreFlopPlayer {
    class Dealer {

        public float PotSize { get; set; }

        public void NewHand(Deck deck, List<Player> players) {
            deck.NewDeck();
            deck.Shuffle();
            foreach (var p in players) {
                // Move the Dealer BTN                
                // p.Position = PositionDictionary.

                // Post Blinds
                if (p.Position is "SB") { p.Stack -= 0.5; p.HasBet = 0.5; PotSize += 0.5f; }
                else if (p.Position is "BB") { p.Stack -= 1; p.HasBet = 1; PotSize += 1; }

                // Deal Hands
                if (p.Hand.Count != 0) p.Hand.Clear();
                deck.DealHand(p.Hand, deck);
            }            
        }

        public void DealFlop(Deck deck) {
            Card a = deck.TakeTopCard();
            Card b = deck.TakeTopCard();
            Card c = deck.TakeTopCard();
            Console.WriteLine(a.Rank + " of " + a.Suit + ", " + b.Rank + " of " + b.Suit + ", " + c.Rank + " of " + c.Suit);
        }
    }
}
