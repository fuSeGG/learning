using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Console;

namespace PreFlopPlayer {
    class Program {

        static void Main() {

            var myDeck = new Deck();         
            var playerMaker = new Player();
            var gameState = new GameState();
            List<Player> myPlayers = playerMaker.AddSixPlayers();

            gameState.NewHand(myDeck, myPlayers);

            
            //TEST: Print all players hands + Take Action where strategy has been written
            UTGStrat strat = new UTGStrat();
            var hp = new HandParser();
            foreach (Player p in myPlayers) {                
                Write(p.Position + ": ");
                p.ShowHand(p.Hand);                
                if (p.Position is "UTG") { Console.WriteLine($"[UTG {strat.Action(hp.HandType(p.Hand))}s]"); }
                else Console.WriteLine();
            }
            Write("Potsize: ");
            WriteLine(gameState.PotSize);
            ReadLine();
        }
    }
}