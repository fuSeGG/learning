using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreFlopPlayer
{
    public static class RankCombos
    {
        public static readonly List<CardCombo> RankPairs;

        static RankCombos()
        {
            RankPairs = CreateListOfPossibleRankCombos();
        }

        // Compare hand with ComboList
        public static CardCombo DefineHandCombo(Hand hand)
        {
            return RankPairs.Single(h => h.FirstCardRank == hand.Cards[0].Rank && h.SecondCardRank == hand.Cards[1].Rank);
        }

        private static List<CardCombo> CreateListOfPossibleRankCombos()
        {
            var tempList = new List<CardCombo>();
            for (int FirstRank = 14; FirstRank >= 2; FirstRank--)
            {
                for (int SecondRank = FirstRank; SecondRank >= 2; SecondRank--)
                {
                    tempList.Add(new CardCombo(FirstRank, SecondRank));
                }
            }
            return tempList;
        }
    }
}
