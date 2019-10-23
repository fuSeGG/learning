using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreFlopPlayer
{
    class Brain
    {
        private List<Hand> FullRepresentingRange; // Starts at all possible hands, then gets reduced at each action taken
        private List<Hand> RaiseRange;
        private List<Hand> CallRange;
        private List<Hand> BluffRange;
        private List<Hand> FoldRange;
        private Hand CurrentHand;
    }
}
