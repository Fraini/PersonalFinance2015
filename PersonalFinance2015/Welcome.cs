using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*********************************************************
 * Project: PersonalFinance2015
 * Coded by Fraini Sánchez at IES San Vicente
 * 
 * Welcome.cs - Welcom Screen* 
 * Authors: Fraini Sánchez
 *********************************************************/
namespace PersonalFinance2015
{
    class Welcome
    {
        public Welcome()
        {

        }

        public void WelcomeScreen()
        {
            string[] s = {
            "+==============================+",
            "|                              |",
            "|                              |",
            "|     PERSONAL FINANCE 2015    |",
            "|                              |",
            "|                              |",
            "+==============================+",
            "_______________________________"};

            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < s.Length; i++)
            {
                Console.SetCursorPosition(23, i + 7);
                Console.Write(s[i]);
            }

            Console.SetCursorPosition(23, 15);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("Press Any Key To Show Menu...");
            Console.ReadLine();
        }

        public void Help()
        {
            Console.Clear();
            string[] s = {
            "1-ADD NEW INCOME",
            "2-ADD NEW EXPENSE",
            "3-ADD NEW CATEGORY",
            "4-LIST ALL DATA",
            "5-SEARCH BY DATE ..."};

            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < s.Length; i++)
            {
                Console.SetCursorPosition(23, i + 7);
                Console.Write(s[i]);
            }

            Console.SetCursorPosition(23, 15);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("Press Any Key To Show Menu...");
            Console.ReadLine();
        }
    }
}
