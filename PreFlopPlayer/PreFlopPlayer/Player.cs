using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace PreFlopPlayer {
    class Player {
        public string Name { get; set; }
        public double Stack { get; set; }
        public string Position { get; set; }
        public List<Card> Hand;
        public double BetState { get; set; }

        public void ShowHand(List<Card> h) {
            foreach (Card c in h) {
                Console.Write($"{c.Rank} ({c.Suit})| ");
            }
        }


        public List<Player> AddSixPlayers() {
            List<Player> myPlayers = new List<Player>();

            foreach (var pos in PositionDictionary.Positions) {
                int count = 1;
                List<Card> hand = new List<Card>();
                myPlayers.Add(new Player {
                    Name = $"Player{count}",
                    Position = pos.Value,
                    Stack = 100,
                    Hand = hand
                });
                ++count;
            }
            return myPlayers;
        }
    }
    public static class PositionDictionary {
        public static Dictionary<int, string> Positions = new Dictionary<int, string>(){
            {1, "SB"},
            {2, "BB"},
            {3, "UTG"},
            {4, "HJ"},
            {5, "CO"},
            {6, "BTN"} };

    }
}
