using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreFlopPlayer {
    class UTGStrat {

        public string Action(Dictionary<string, bool> handQuality) {

            // RFI
            //      (MISSING: Qx / Kx && 9 && Suited)

            foreach (var entry in handQuality) {
                if ((handQuality["isPocketPair"]) ||
                    (handQuality["isSuited"] && handQuality["isBroadway"]) ||
                    (handQuality["isSuited"] && handQuality["isOpenConnected"]) ||
                    (handQuality["isSuited"] && handQuality["hasAce"]))
                    return "Raise";
            }
            return "Fold";


            // vs3B

            // vs4B

            // vs5B(?)



        }
    }
}
