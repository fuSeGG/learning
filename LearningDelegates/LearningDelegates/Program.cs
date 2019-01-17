using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningDelegates
{
    class Program
    {
        int bountyValue = 40;
        int addedBounty = 10;
        static int bountyCount = 0;
        
        static void Main()
        {
            
            Program obj = new Program();
            
            
            Console.WriteLine(obj.NextBounty(bountyCount));            
            
            Console.ReadLine();
        }

        public int Udregneren(int a, int b, int c) {
            int NetWorthSwing = a * b + c;
            return NetWorthSwing;
        }


        public int NextBounty(int n)
        {
            return n += 5;            
        }        

        public delegate void Kladden(int num, int num2, int num3);
    }
}
