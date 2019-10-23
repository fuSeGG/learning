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

        private void CategoriseHand(Hand hand)
        {
            hand.isPocketPair = hand.Cards[0].Rank == hand.Cards[1].Rank;
            hand.isSuited = hand.Cards[0].Suit == hand.Cards[1].Suit;
            hand.isBroadway = (int)hand.Cards[0].Rank >= 10 && (int)hand.Cards[1].Rank >= 10;
            hand.isOpenConnected = Math.Abs((int)hand.Cards[0].Rank - (int)hand.Cards[1].Rank) == 1;
            hand.hasAce = (int)hand.Cards[0].Rank == 14 || (int)hand.Cards[1].Rank == 14;
            hand.hasKing = (int)hand.Cards[0].Rank == 13 || (int)hand.Cards[1].Rank == 13;
            hand.hasQueen = (int)hand.Cards[0].Rank == 12 || (int)hand.Cards[1].Rank == 12;
            // isClose
            // isOneGap         
        }
    }
}
