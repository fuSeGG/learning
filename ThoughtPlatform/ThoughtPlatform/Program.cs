using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ThoughtPlatform
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu m = new Menu();

            m.Show("MainMenu");





            Console.ReadLine();
        }



    }
}


public class Menu
{
    private string MainMenu = "1) Select Category \n" + "2) Create Category\n" + "3) Exit\n";
    private string CatList = "";
    private string NewCat = "";

    public void Show(string s)
    {
        if (s == "MainMenu") { s = MainMenu; }
        else if (s == "CatList") { s = CatList; }


        WriteLine(s);
        var choice = ReadLine();
        int c = Convert.ToInt32(choice);
    }

}