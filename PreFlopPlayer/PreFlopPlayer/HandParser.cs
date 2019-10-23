using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreFlopPlayer
{
    public class HandParser
    {
        bool isPocketPair;
        bool isBroadway;
        bool isSuited;
        bool isOpenConnected; //45-TJ CURRENTLY: 23-AK
        //bool isClosedConnected; //A2-34 + QJ-AK
        bool hasAce;
        bool hasKing;
        bool hasQueen;
        //bool isOneGap;

        //roughly categorises a given hand
        public void CategoriseHand(Card[] hand)
        {
            this.isPocketPair = hand[0].Rank == hand[1].Rank;
            this.isSuited = hand[0].Suit == hand[1].Suit;
            this.isBroadway = (int)hand[0].Rank >= 10 && (int)hand[1].Rank >= 10;
            this.isOpenConnected = Math.Abs((int)hand[0].Rank - (int)hand[1].Rank) == 1;
            this.hasAce = (int)hand[0].Rank == 14 || (int)hand[1].Rank == 14;
            this.hasKing = (int)hand[0].Rank == 13 || (int)hand[1].Rank == 13;
            this.hasQueen = (int)hand[0].Rank == 12 || (int)hand[1].Rank == 12;
            // isClose
            // isOneGap         
        }
    }
}
