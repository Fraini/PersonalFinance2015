using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*********************************************************
 * Project: PersonalFinance2015
 * Coded by Fraini Sánchez at IES San Vicente
 * Authors: Fraini Sánchez
 *********************************************************/
namespace PersonalFinance2015
{
    class ListExpenses
    {
        
        private  SortData sort;
        private  int amounOfData = 10; //Maximum data by page
        private  int startShowData = 0; //Data initial to show
        private  int currentPage = 0;  //Page Current
        private  int amountPage = 0;  //Total of page
        public const int DATASLINE = 2; //Total of line by Page
        public int AllIncome = 0;  //Sum of all Income
        public int AllExpense = 0; //Sum of all Expense
        private DataFile data; 
        private List<SortData> aux;

        /**
         *@param Struct With the necessary fields to sort expense and income data
         */
        private struct ExpenseAndIncomes
        {
            public string description;
            public string category;
            public string date;
            public string amount;
        }

        //Initialize objects in the constructor
        public ListExpenses()
        {
            data = new DataFile();
            aux = new List<SortData>();
            sort = new SortData();
        }

        /*
         *@param method sum total of the current month
         *@return int --> totalExpenses
         */
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
                    if (expense[i].GetDate().Trim().Substring(0,6)
                                                == d.ToString(datePatt))
                    {
                        totalExpense += Convert.ToInt32(expense[i].GetAmount());
                    }

                }
            }

            return totalExpense;
        }


        /*
         *@param method sum total of the current month
         *@return int --> totalIncomes
         */
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
                        totalIncome += Convert.ToInt32(income[i].GetAmount());
                    }
                }
            }

            return totalIncome;
        }

        /*
         *@param methos what list summary 
         */
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

            //if the result is negative, painted red
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

        /*
         *@param This method display all Income / Expense sort by category and 
         *date.
         */
        public void DisplayAll()
        {
           
            List<Expense> e = new List<Expense>();
            e = data.LoadExpenses();
            List<Income> income = new List<Income>();
            income = data.LoadIncomes();
            Dictionary<int, Category> category = 
                        new Dictionary<int, Category>();
            category = data.LoadCategory();
            //List<SortData> aux = new List<SortData>();

            Console.Clear();

             //filling the data with all expenses
             for (int x = 0; x < e.Count; x++)
             {
                     aux.Add( new SortData(e[x].GetDescription(), 
                     e[x].GetDate(), e[x].GetAmount().ToString(),
                     category[e[x].GetValueCategory()].GetNameCategory()));
                     AllExpense += Convert.ToInt32(e[x].GetAmount());
             }

             //filling the data with all incomes
             for (int i = 0; i < income.Count; i++ )
             {
                 aux.Add(new SortData(income[i].GetDescription(),
                     income[i].GetDate(), income[i].GetAmount().ToString(),
                     category[
                     income[i].GetValueCategory()].GetNameCategory()));
                     AllIncome += Convert.ToInt32(income[i].GetAmount());
             }


             SortByCategoryAndDate(aux);
             PaginationData();
             
        }


        public void SortByCategoryAndDate(List<SortData> aux)
        {
            
            ExpenseAndIncomes[] pr = new ExpenseAndIncomes[aux.Count];

            //keep the data in a struct array now, 
            //because here is when you have data loaded
            for (int i = 0; i < aux.Count; i++)
            {
                pr[i].description = aux[i].description;
                pr[i].date = aux[i].date;
                pr[i].amount = aux[i].amount;
                pr[i].category = aux[i].category;

            }

            //sort by bubble
            for (int i = 0; i < pr.Length - 1; i++)
            {
                for (int j = i; j < pr.Length; j++)
                {
                    if (pr[i].category.CompareTo(pr[j].category) > 0)
                    {
                        string auxCategory, auxDescription, auxDate, auxAmount;
                        //description
                        auxDescription = pr[i].description;
                        pr[i].description = pr[j].description;
                        pr[j].description = auxDescription;

                        //date
                        auxDate = pr[i].date;
                        pr[i].date = pr[j].date;
                        pr[j].date = auxDate;

                        //amount
                        auxAmount = pr[i].amount;
                        pr[i].amount = pr[j].amount;
                        pr[j].amount = auxAmount;

                        //category
                        auxCategory = pr[i].category;
                        pr[i].category = pr[j].category;
                        pr[j].category = auxCategory;
                    }

                    //if category the are equal sort by date 
                    if (pr[i].category.CompareTo(pr[j].category) == 0
                                    && pr[i].date.CompareTo(pr[j].date) > 0)
                    {
                        string auxCategory, auxDescription, auxDate, auxAmount;
                        //description
                        auxDescription = pr[i].description;
                        pr[i].description = pr[j].description;
                        pr[j].description = auxDescription;

                        //date
                        auxDate = pr[i].date;
                        pr[i].date = pr[j].date;
                        pr[j].date = auxDate;

                        //amount
                        auxAmount = pr[i].amount;
                        pr[i].amount = pr[j].amount;
                        pr[j].amount = auxAmount;

                        //category
                        auxCategory = pr[i].category;
                        pr[i].category = pr[j].category;
                        pr[j].category = auxCategory;
                    }
                }
            }

            //Now we keep the data in a string list
            List<string> list = new List<string>();
            for (int i = 0; i < pr.Length; i++ )
            {
                list.Add(pr[i].date.Trim()+" "+pr[i].amount+
                    " " + pr[i].category + " " + pr[i].description);
                list.Add("-------------------------------------------");
            }

            sort.SetSortList(list);
        }

        /**
         * Method what Draw data sort
         */
        public void Draw()
        {
            int i = startShowData; 

            List<string> listTemp = sort.GetList();
            int limite = amounOfData * DATASLINE + startShowData;
            int x = 2;
            while (i < listTemp.Count && i <  limite )
            {
                Console.SetCursorPosition(20,x++ );
                Console.WriteLine(listTemp[i]);
                i++;
            }

        }

        //Method progresses page
        public void Next()
        {
            /**
             * amountOfData --> Amount of data to display default 10
             * currentPage --> Page actually
             * DATASLINE --> Constant having the number of lines for each row there -->Default 2 
             * because we keep data (one line) and -----  (second line).
             * limit --> calculation is performed to find out which pages will show
             */
            int limit = (amounOfData * (currentPage + 1) * DATASLINE);

            if ( limit < sort.GetList().Count)
            {
                currentPage++;
                startShowData = (amounOfData * (currentPage) * DATASLINE);
            }
           
        }

        public void Prev()
        {
            if (currentPage > 0)
            {
                currentPage--;
                startShowData = amounOfData * currentPage * DATASLINE;
            }
            
        }

        /**
         *@param Method what move cursor -->UP,LEFT,RIGHT,DOWN  
         */
        public  void PaginationData()
        {
            bool exit = false;
            ConsoleKeyInfo keyInfo;     
            amountPage = sort.GetList().Count / amounOfData -1;           
            Welcome.HelpList();
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.BackgroundColor = ConsoleColor.White;
                Console.SetCursorPosition(20, 0);
                Console.WriteLine("Total of Page: " + 
                    amountPage + " Current Page: " + (currentPage + 1) + 
                    " Total of Data: " + (sort.GetList().Count) / DATASLINE);
  
                Console.ResetColor();
              
                Console.ForegroundColor = ConsoleColor.Green;
                Console.BackgroundColor = ConsoleColor.Black;
                Draw();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.BackgroundColor = ConsoleColor.White;
                Console.SetCursorPosition(20, 23);
                Console.WriteLine("Total Expense: " +
                    AllExpense + " Total Income " + AllIncome
                    + " Difference: " + (AllIncome - AllExpense));
                Console.ResetColor();
                Console.SetCursorPosition(1, 24);
                keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.Escape)
                    exit = true;

                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    //check that the data are showing greater than 0
                    if (startShowData - DATASLINE > 0)
                        startShowData -= DATASLINE;
                }

                if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    //calculate nextpage to show, when limit is < what maximum
                    int limited = (amounOfData * DATASLINE * (currentPage + 1)) +
                            startShowData + DATASLINE;

                    if ( limited < sort.GetList().Count)
                        startShowData += DATASLINE;
                }

                if (keyInfo.Key == ConsoleKey.PageDown) //avpag
                {
                    Next();
                }

                if (keyInfo.Key == ConsoleKey.PageUp) //repag
                {
                    Prev();
                }

            } while (!exit);
            //change console background color and foreground color
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("Press any key to show Menu...");
        }

    }
}
