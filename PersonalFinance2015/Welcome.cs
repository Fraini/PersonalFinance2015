using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 *Class Welcome Screen
 */

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

           Console.SetCursorPosition(23,15);
           Console.BackgroundColor = ConsoleColor.Black;
           Console.Write("Press Any Key To Menu...");
           Console.ReadLine();
        }
    }
}
