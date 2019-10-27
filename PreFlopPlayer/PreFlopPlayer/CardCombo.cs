using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreFlopPlayer
{
    public sealed class CardCombo
    {
        private readonly Rank FirstCardRank;
        private readonly Rank SecondCardRank;

        public static readonly List<CardCombo> AllPossibleRankCombos;

        // Constructor
        private CardCombo(int firstCardRank, int secondCardRank)
        {
            this.FirstCardRank = (Rank)firstCardRank;
            this.SecondCardRank = (Rank)secondCardRank;
        }

        // Compare hand with ComboList
        public static CardCombo DefineHandCombo(Hand hand)
        {
            return AllPossibleRankCombos.Single(h => h.FirstCardRank == hand.Cards[0].Rank && h.SecondCardRank == hand.Cards[1].Rank);
        }

        private List<CardCombo> CreateListOfPossibleRankCombos()
        {
            List<CardCombo> testList = new List<CardCombo>();
            foreach (Rank firstCardsRank in Enum.GetValues(typeof(Rank)))
            {
                foreach (Rank secondCardsRank in Enum.GetValues(typeof(Rank)))
                {
                    testList.Add(new CardCombo((int)firstCardsRank, (int)secondCardsRank));
                }
            }
            return testList;
        }


        // AA, KK, QQ, JJ, TT, Nines, Eights, Sevens, Sixes, Fives, Fours, Threes, Twos, AK, AQ, AJ, AT, ANine
    }
}
