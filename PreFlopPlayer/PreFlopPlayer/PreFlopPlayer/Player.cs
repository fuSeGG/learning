using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PreFlopPlayer.Enums;

namespace PreFlopPlayer {
    class Player {
        public string Name { get; set; }
        public double Stack { get; set; }
        public Enum Position { get; set; }
        public List<Card> Hand;
        public void TakeAction() { }


        public List<Player> AddSixPlayers(Deck deckName) {
            List<Player> myPlayers = new List<Player>();
            foreach (Position pos in Enum.GetValues(typeof(Position))) {
                int playerName = 1;
                List<Card> hand = new List<Card>();
                myPlayers.Add(new Player { Name = $"Player{playerName}", Position = pos, Stack = 100, Hand = deckName.DealHand(hand, deckName) });
                ++playerName;
            }
            return myPlayers;

        }

    }
}
