﻿using System;
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
    class ListExpenses
    {
        private DataFile data;
        public ListExpenses()
        {
            data = new DataFile();
        }

        public int SummaryExpensive()
        {

            string datePatt = @"yyyy/M";
            DateTime d = DateTime.Now;
            List<Expense> expense = new List<Expense>();
            expense = data.LoadExpenses();
            Console.Clear();
            int totalExpense = 0;

            if (expense.Count > 0)
            {
                for (int i = 0; i < expense.Count; i++)
                {
                    if (expense[i].GetDate().Substring(0,7).TrimStart()
                                                == d.ToString(datePatt))
                    {
                        totalExpense += Convert.ToInt32(expense[i].GetQuantity());
                    }

                }
            }

            return totalExpense;
        }


        public int SummaryIncomes()
        {

            string datePatt = @"yyyy/M";
            DateTime d = DateTime.Now;
            List<Income> income = new List<Income>();
            income = data.LoadIncomes();
            int totalIncome = 0;

            if (income.Count > 0)
            {
                for (int i = 0; i < income.Count; i++)
                {
                    if (income[i].GetDate().Substring(0, 6).TrimStart()
                                                == d.ToString(datePatt))
                    {
                        totalIncome += Convert.ToInt32(income[i].GetQuantity());
                    }

                }
            }

            return totalIncome;
        }

        public void ListAll()
        {
            Console.Clear();
            DateTime d = DateTime.Now;
            string[] month = { "January","February","March","April","May",
                                 "June","July","August","September","Octuber",
                                    "November","December" };

            int totalExpenses = SummaryExpensive();
            int totalIncomes = SummaryIncomes();

            Console.SetCursorPosition(25, 5);
            Console.WriteLine("SUMMARY MONTH: {0}", month[d.Month - 1]);

            Console.SetCursorPosition(15, 8);
            Console.Write("Total Incomes {0}  Total Expenses {1} "
                                      , totalIncomes, totalExpenses);
            Console.SetCursorPosition(15, 9);
            Console.WriteLine("------------------------------------------------");
            Console.SetCursorPosition(15, 10);
            if (totalIncomes - totalExpenses < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Monthly difference: {0} ", 
                            totalIncomes - totalExpenses);
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
                Console.Write("Monthly difference: {0} ", 
                                totalIncomes - totalExpenses);


        }

        public void DisplayAll()
        {
            //TODO

            List<Expense> e = new List<Expense>();
            e = data.LoadExpenses();
            List<Income> income = new List<Income>();
            income = data.LoadIncomes();
            Dictionary<int, Category> c = new Dictionary<int, Category>();
            c = data.LoadCategory();
            List<string> aux = new List<string>();

            Console.Clear();

            
             for (int x = 0; x < e.Count; x++)
             {
                 aux.Add("Description:" + e[x].GetDescription());
                 aux.Add("Date:"+e[x].GetDate());
                 aux.Add("Amount:"+e[x].GetQuantity());
                 aux.Add("Category: " + c[Convert.ToInt32(
                     e[x].GetNameCategory())].GetNameCategory());
                 
             }

             //Esto falla ;)
            /* for (int i = 0; i < income.Count; i++ )
             {

                 Console.WriteLine(income[i].GetNameCategory());
                 /*aux.Add("Description:" + income[i].GetDescription());
                 aux.Add("Date:" + income[i].GetDate());
                 aux.Add("Amount:" + income[i].GetQuantity());
                 aux.Add("Category: " + c[Convert.ToInt32(
                        income[i].GetNameCategory())].GetNameCategory()
                     );
             }*/

            foreach (string v in aux)
            {
                Console.WriteLine(v);
            }

            Console.ReadLine();

        }

        /*static int  CompareCategory(Expense e, Income i)
        {
            if (e == null)
            {
                if (i == null)
                    return 0;
                else
                    return -1;
            }
            else
            {
                int value = e.GetNameCategory().Length.CompareTo
                        (i.GetNameCategory().Length);
                if (value != 0)
                    return value;
                else
                    return e.GetNameCategory().CompareTo(i.GetNameCategory());
            }
                
        }*/
    }
}
