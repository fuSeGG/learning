using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleThougths {
    class Program {
        static void Main(string[] args) {

            NewNote();



        }

        // add a note
        private static void NewNote() {
            try {
                Write("Enter filename: ");
                string filename = ReadLine();
                Clear();
                Write(filename + ": ");
                using (StreamWriter sw = File.CreateText($"{filename}.txt")) {
                    string body = ReadLine();
                    sw.WriteLine($"{body}");
                    sw.Close();
                }
            }
            catch (Exception e) {
                Write(e.Message);
            }
        }

        /*
        private static void DeleteNote() { }

        private static void ListNotes() {
            
        }
        */





    }
}