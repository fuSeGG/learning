using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleThougths {
    class Program {
        static void Main(string[] args) {
            Dictionary<string, string> thoughts = new Dictionary<string, string>();


            ShowThoughts();
            
            ReadLine();




            // add a thought to the list
            void AddThought() {
                Write("\nNew Thought:");
                string value = ReadLine();
                Write("Name the thought: ");
                string key = ReadLine();
                thoughts.Add(key, value);
                Clear();
                ShowThoughts();
            }


            // show all thoughts on list
            void ShowThoughts() {
                int index = 0;
                if (thoughts.Count > 0) {                    
                    foreach (string s in thoughts.Values) {
                        index += 1;
                        WriteLine($"[{index}] {s}");
                    }
                }

                WriteLine("\n1) Add thought \n2) Remove Thought");
                var foo = ReadLine();
                if (Char.Equals(foo, "1")){
                    AddThought();
                }                
            }



        }
    }
}
