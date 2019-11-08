using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreFlopPlayer
{
    public class PreflopStrategy
    {
        public Bet UTG(Hand myHand, BetState betState)
        {
            switch (betState.BetCount)
            {
                case 0:
                    return UTGRFI(myHand);
                case 1:
                    Console.WriteLine("This shouldn't happen.");
                    return null;

                case 2:
                    return UTGvs3B(myHand, betState);

                default:
                    return UTGAllIn(myHand, betState);
            }
        }

        private Bet UTGRFI(Hand myHand)
        {
            if (myHand.isPaired || myHand.isSuitedAce || myHand.isSuitedBroadway || myHand.isSuitedConnecter ||
        myHand.CardCombo == RankCombos.RankPairs.Where(r => r.FirstCardRank == Rank.King && r.SecondCardRank == Rank.Nine && myHand.isSuited) ||
        myHand.CardCombo == RankCombos.RankPairs.Where(r => r.FirstCardRank == Rank.Queen && r.SecondCardRank == Rank.Nine && myHand.isSuited) ||
        myHand.CardCombo == RankCombos.RankPairs.Where(r => r.FirstCardRank == Rank.Jack && r.SecondCardRank == Rank.Nine && myHand.isSuited))
            {
                return new Bet(2.5m);
            }
            else return null;
        }
        private Bet UTGvs3B(Hand h, BetState b)
        {
            if (h.isPaired && h.CardCombo.FirstCardRank >= Rank.Queen)
            {
                return new Bet(b.FacingBetSize * 2.5m);
            }
            else return null;
        }

        private Bet UTGAllIn(Hand myHand, BetState betState)
        {
            if (myHand.hasAce && myHand.isPaired)
                return new Bet(betState.FacingBetSize * 2.5m);
            else return null;
        }

        public Bet HJ(Hand myHand, BetState b)
        {
            if (b.BetCount == 0)
            {
            }
            else if (b.BetCount == 1) { }
            else if (b.BetCount == 2) { }
            else if (b.BetCount == 3) { }

            return null;
        }
        public Bet CO(Hand myHand, BetState b)
        {
            if (b.BetCount == 0)
            {
            }
            else if (b.BetCount == 1) { }
            else if (b.BetCount == 2) { }
            else if (b.BetCount == 3) { }

            return null;
        }
        public Bet BTN(Hand myHand, BetState b)
        {
            if (b.BetCount == 0)
            {
            }
            else if (b.BetCount == 1) { }
            else if (b.BetCount == 2) { }
            else if (b.BetCount == 3) { }

            return null;
        }
        public Bet SB(Hand myHand, BetState b)
        {
            if (b.BetCount == 0)
            {
            }
            else if (b.BetCount == 1) { }
            else if (b.BetCount == 2) { }
            else if (b.BetCount == 3) { }

            return null;
        }

        public void LowjackVs3B(Hand myHand, Bet facingBet)
        {
            // Call

            // if (int betsize < ){ }

            // Raise


            // Fold

        }
        public void LowjackVs4B(Hand hand, int betsize) { }
        public void LowjackVs5BAndUp(Hand hand, int betsize) { }
    }
}
