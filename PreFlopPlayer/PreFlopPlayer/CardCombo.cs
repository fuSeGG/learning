using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreFlopPlayer
{
    public class CardCombo
    {
        public Rank FirstCardRank { get; }
        public Suit FirstCardSuit { get; }
        public Rank SecondCardRank { get; }
        public Suit SecondCardSuit { get; }

        // Constructor
        public CardCombo(int firstCardRank, int secondCardRank)
        {
            this.FirstCardRank = (Rank)firstCardRank;
            this.SecondCardRank = (Rank)secondCardRank;
        }
        // AA, KK, QQ, JJ, TT, Nines, Eights, Sevens, Sixes, Fives, Fours, Threes, Twos, AK, AQ, AJ, AT, ANine
    }
}
