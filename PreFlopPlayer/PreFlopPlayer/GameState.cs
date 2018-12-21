using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreFlopPlayer {
    class GameState {

        public double PotSize = 0;

        public void NewHand(Deck deck, List<Player> players) {

            deck.FillDeck();
            deck.Shuffle();

            foreach (var p in players) {

                // Move the Dealer BTN                
                // p.Position = PositionDictionary.

                // Post Blinds
                if (p.Position is "SB") { p.Stack -= 0.5; p.BetState = 0.5; PotSize += 0.5; }
                else if (p.Position is "BB") { p.Stack -= 1; p.BetState = 1; PotSize += 1; }

                // Deal Hands
                if (p.Hand.Count != 0) p.Hand.Clear();
                deck.DealHand(p.Hand, deck);

            }
        }
    }
}
