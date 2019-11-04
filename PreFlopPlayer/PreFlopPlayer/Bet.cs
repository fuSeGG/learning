using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreFlopPlayer
{
    public class Bet
    {
        public int BetCount { get; set; }
        public decimal BigBlinds { get; set; }

        public Bet(decimal bigBlinds) {
            this.BetCount++;
            this.BigBlinds = bigBlinds;
        }
    }
}
