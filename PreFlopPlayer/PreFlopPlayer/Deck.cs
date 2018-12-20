using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PreFlopPlayer.Enums;
using static System.Console;

namespace PreFlopPlayer {
    public class Deck {

        List<Card> cards = new List<Card>();

        public void FillDeck() {
            foreach (Suit suit in (Suit[])Enum.GetValues(typeof(Suit))) {
                foreach (Rank rank in (Rank[])Enum.GetValues(typeof(Rank))) {
                    cards.Add(new Card(rank, suit));
                }
            }
        }

        
        public List<Card> DealHand(List<Card> n, Deck d) {
            n.Add(d.TakeTopCard());
            n.Add(d.TakeTopCard());
            return n;
        }

        public void Shuffle() {
            Random rand = new Random();
            for (int i = cards.Count - 1; i > 0; i--) {
                int randomIndex = rand.Next(i + 1);
                Card tempCard = cards[i];
                cards[i] = cards[randomIndex];
                cards[randomIndex] = tempCard;
            }
        }

        public void ShowDeck() {
            foreach (var card in cards) {
                WriteLine(card.Rank + "(" + card.Suit + ")");
            }
        }

        public bool Empty {
            get { return cards.Count == 0; }
        }

        public Card TakeTopCard() {
            if (!Empty) {
                Card topCard = cards[cards.Count - 1];
                cards.RemoveAt(cards.Count - 1);
                return topCard;
            } else {
                return null;
            }
        }
    }
}
