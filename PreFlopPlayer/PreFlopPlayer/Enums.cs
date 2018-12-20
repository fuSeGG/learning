using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreFlopPlayer {
    public class Enums {
        public enum Rank { Two = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace };
        public enum Suit { hearts, diamonds, spades, clubs };
        public enum Position { SB = 1, BB, UTG, HJ, CO, BTN};
    }
}
