using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PreFlopPlayer.Enums;

namespace PreFlopPlayer {
    public class Card {

        //fields & properties
        public Rank Rank { get; }
        public Suit Suit { get; }
        public bool faceUp { set; get; }      
        

        //methods
        public void FlipOver() {
            faceUp = !faceUp;
        }

         //constructor
        public Card(Rank rank, Suit suit) {
            this.Rank = rank;
            this.Suit = suit;
            faceUp = false;
        }       
    }


}
