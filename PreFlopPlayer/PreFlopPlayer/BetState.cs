using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreFlopPlayer {
    public class BetState {

        // En counter der starter på 0 og stiger med 1 hver gang nogle forøger betsize i runden (PF starter på 1 pga BB)
        public int betstate { get; set; }

        // En token man tager når man forøger betsize. (så der er kun 1 der kan have den)
        public string initiator { get; set; }

        // true if someone could C-bet this or next street.
        public bool CBetOpen { get; set; }     

    }
}
