using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreFlopPlayer
{
    public class PreflopStrategy
    {
        public void UTG(Hand hand) { }
        /* UTG RFI
           (MISSING: Qx / Kx && 9 && Suited)

       foreach (var entry in handQuality)
       {
           if ((handQuality["isPocketPair"]) ||
               (handQuality["isSuited"] && handQuality["isBroadway"]) ||
               (handQuality["isSuited"] && handQuality["isOpenConnected"]) ||
               (handQuality["isSuited"] && handQuality["hasAce"]))
               return "Raise";
       } */
    }
}
