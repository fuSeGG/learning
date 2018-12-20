using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PreFlopPlayer.Enums;
using static System.Console;

namespace PreFlopPlayer {
    class Program {

        static void Main() {

            var myDeck = new Deck();
            myDeck.FillDeck();
            myDeck.Shuffle();
                        
            var playerMaker = new Player();
            List<Player> myPlayers = playerMaker.AddSixPlayers(myDeck);

            
            //TEST: Print all players hands + Take Action where strategy has been written
            UTGStrat strat = new UTGStrat();
            var hp = new HandParser();
            foreach (Player p in myPlayers) {                
                Console.WriteLine($"({p.Position}): {p.Hand[0].Rank} ({p.Hand[0].Suit}) & {p.Hand[1].Rank} ({p.Hand[1].Suit})");
                if (p.Position is Position.UTG) { Console.WriteLine($"[UTG {strat.Action(hp.HandType(p.Hand))}s]"); }
            }          
            ReadLine();
        }
    }
}