using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreFlopPlayer
{
    public class Hand
    {
        public Card[] Cards = new Card[2];

        public CardCombo CardCombo { get; private set; }
        public bool isPocketPair { get; private set; }
        public bool isBroadway { get; private set; }
        public bool isSuited { get; private set; }
        public bool hasAce { get; private set; }
        public bool hasKing { get; private set; }
        public bool hasQueen { get; private set; }
        public bool isOpenConnected { get; private set; } //45-TJ CURRENTLY: 23-AK
        //bool isClosedConnected; //A2-34 + QJ-AK
        //bool isOneGap;

        public Hand()
        {
            CategoriseHand(this);
        }

        public Hand(Card card1, Card card2)
        {
            this.Cards[1] = card1;
            this.Cards[2] = card2;
            CategoriseHand(this);
        }

        private void CategoriseHand(Hand hand)
        {
            // Order cards in hand by rank
            hand.Cards.OrderByDescending(c => c.Rank);

            // Set description bools
            hand.isBroadway = hand.Cards.All(c => c.Rank > Rank.Ten);
            hand.hasAce = hand.Cards.Any(c => c.Rank == Rank.Ace);
            hand.hasKing = hand.Cards.Any(c => c.Rank == Rank.King);
            hand.hasQueen = hand.Cards.Any(c => c.Rank == Rank.Queen);

            hand.isPocketPair = hand.Cards[0].Rank == hand.Cards[1].Rank;
            hand.isSuited = hand.Cards[0].Suit == hand.Cards[1].Suit;
            hand.isOpenConnected = Math.Abs((int)hand.Cards[0].Rank - (int)hand.Cards[1].Rank) == 1;
            
            // isClose
            // isOneGap         
        }
    }
}
