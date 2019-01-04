using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreFlopPlayer {
    public class HandParser {


        bool isPocketPair;
        bool isBroadway;
        bool isSuited;
        bool isOpenConnected; //45-TJ
        //bool isClosedConnected; //A2-34 + QJ-AK
        bool hasAce;
        bool hasKing;
        bool hasQueen;
        //bool isOneGap;

        //roughly categorises a given hand
        public Dictionary<string, bool> HandType(List<Card> hand) {
             
            Dictionary<string, bool> handQuality = new Dictionary<string, bool>();

            handQuality.Add("isPocketPair", isPocketPair = hand[0].Rank == hand[1].Rank);
            handQuality.Add("isSuited", isSuited = hand[0].Suit == hand[1].Suit);
            handQuality.Add("isBroadway", isBroadway = (int)hand[0].Rank >= 10 && (int)hand[1].Rank >= 10);
            handQuality.Add("isOpenConnected", isOpenConnected = ((int)hand[0].Rank >= 4 && (int)hand[1].Rank >= 4) && ((int)hand[0].Rank <= 11 && (int)hand[1].Rank <= 11) && (Math.Pow(((int)hand[0].Rank - (int)hand[1].Rank), 2) == 1));
            handQuality.Add("hasAce", hasAce = (int)hand[0].Rank == 14 || (int)hand[1].Rank == 14);
            handQuality.Add("hasKing", hasKing = (int)hand[0].Rank == 13 || (int)hand[1].Rank == 13);
            handQuality.Add("hasQueen", hasQueen = (int)hand[0].Rank == 12 || (int)hand[1].Rank == 12);            
            // isClose
            // isOneGap         




            return handQuality;

            /*
            var summary = new StringBuilder();
            if (isPocketPair) summary.Append("PocketPair");
            if (isSuited) summary.Append(" Suited");
            if (isBroadway) summary.Append(" Broadway");
            if (isOpenConnected) summary.Append(" OpenConnected");
            if (hasAce) summary.Append(" Ax");
            if (hasKing) summary.Append(" Kx");
            if (hasQueen) summary.Append(" Qx");
            if (summary.Length == 0) summary.Append(" Poop");            
            string result = summary.ToString();
            result = result.Trim();
            return result;
             */
        }
    }
}
