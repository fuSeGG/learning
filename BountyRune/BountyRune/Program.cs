using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BountyRune
{
    class Program
    {
        static void Main()
        {
            int bountyGold = 40;
            int increasePerMinute = 2;
            int bountyWorth;
            int players = 5;
            int runes = 4;

            Console.WriteLine("Total Bounty Gold up for grabs at minute count:");

            for (int minute = 0; minute <= 60; minute++)
            {
                bountyWorth = bountyGold + increasePerMinute * minute;
                if (minute % 5 == 0)
                {
                    Console.WriteLine("{0}: " + bountyWorth * runes * players, minute);
                }
            }
            Console.ReadLine();
        }
    }
}
