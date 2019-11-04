using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreFlopPlayer
{
    public class PreflopStrategy
    {
        public Bet LJ(Hand myHand, BetState betState)
        {
            switch (betState.BetCount)
            {
                case 0:
                    if (myHand.isPaired || myHand.isSuitedAce || myHand.isSuitedBroadway || myHand.isSuitedConnecter ||
                        myHand.CardCombo == RankCombos.RankPairs.Where(r => r.FirstCardRank == Rank.King && r.SecondCardRank == Rank.Nine && myHand.isSuited) ||
                        myHand.CardCombo == RankCombos.RankPairs.Where(r => r.FirstCardRank == Rank.Queen && r.SecondCardRank == Rank.Nine && myHand.isSuited) ||
                        myHand.CardCombo == RankCombos.RankPairs.Where(r => r.FirstCardRank == Rank.Jack && r.SecondCardRank == Rank.Nine && myHand.isSuited))
                    {
                        return new Bet(2.5m);
                    }
                    else return null;
                case 1:
                    Console.WriteLine("This shouldn't happen.");
                    return null;
                case 2:
                    if (myHand.isPaired && myHand.CardCombo.FirstCardRank >= Rank.Queen)
                    {
                        return new Bet(betState.FacingBetSize * 2.5m);
                    }
                    else return null;                    
                case 3:
                    if (myHand.hasAce && myHand.isPaired) { }
                    break;                    
            }                       

            return null;
        }

        private Bet LJ3B() { return null; }
        private Bet LJAI() { return null; }

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
