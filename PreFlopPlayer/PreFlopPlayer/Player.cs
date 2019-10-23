using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace PreFlopPlayer {
    public class Player {
        // fields props
        public string Name { get; set; }
        public double Stack { get; set; }
        public Positions Position { get; set; }
        public List<Card> Hand;
        private double hasBet;

        public double GetHasBet()
        {
            return this.hasBet;
        }

        public void SetHasBet(double value)
        {
            this.hasBet = value;
        }

        // method for Showing Hand
        public void ShowHand(List<Card> h) {
            foreach (Card c in h) {
                Console.Write($"{c.Rank} ({c.Suit})| ");
            }
        }               
    }
}
