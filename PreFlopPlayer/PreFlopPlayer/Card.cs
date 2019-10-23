using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreFlopPlayer {
    public class Card {

        //fields & properties
        public Rank Rank { get; }
        public Suit Suit { get; }
        public bool FaceUp { set; get; }      
        

        //methods
        public void FlipOver() {
            this.FaceUp = !this.FaceUp;
        }

         //constructor
        public Card(Rank rank, Suit suit) {
            this.Rank = rank;
            this.Suit = suit;
            this.FaceUp = false;
        }
        public Card(Rank rank, Suit suit, bool faceUp)
        {
            this.Rank = rank;
            this.Suit = suit;
            this.FaceUp = faceUp;
        }
    }
}
