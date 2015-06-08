//Fraini Sánchez V0014
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace PersonalFinance2015
{
    class Interface
    {
        private enum menu { INCOME, EXPENSE, CATEGORY, LIST, SEARCH,HELP,EXIT };
        private int option;
        DataFile userFile;
        Dictionary<int,Category> addCategory;
        List<Expense> addExpense;
        List<Income> addIncome;
        public Interface()
        {
            addCategory = new Dictionary<int,Category>();
            addExpense = new List<Expense>();
            addIncome = new List<Income>();
            userFile = new DataFile();
        }

        //load data generated in the class DataFile
        public void Load()
        {
            addCategory = userFile.LoadCategory();
            addExpense = userFile.LoadExpenses();
            addIncome = userFile.LoadIncomes();

        }

        //save a new category in the dictionary and class category
        public Dictionary<int,Category> SavedCategory(int key,string name)
        {
            Category c = new Category(key, name);
            userFile.SaveCategoryFile(c);
            addCategory.Add(key, c);
            
            return addCategory;
        }

        
        //method that handles Add categories
        public void AddNewCategory()
        {
            Console.Clear();
            int key = addCategory.Count;
            string name = null;
            Console.Write("Name?: ");
            name = Console.ReadLine();

            while (name != "")
            {
                if (name != "")
                {
                    if(key ==  0)
                        SavedCategory(++key, name); 
                    else
                        SavedCategory(++key, name);  
                }

                name = Console.ReadLine();
                if (name != "")
                    Console.Write("Name?: ");
            }

            Console.Write("Press any key to exit....");
            Console.ReadLine();
            Console.Clear();
        }

        //methods adding expense and income
        public void Add(int num)
        {
            string description;
            string date;
            int amount = 0;
            int category = -1;

            Console.Clear();
            Console.SetCursorPosition(15, 0);
            Console.Write("Write Description: ");
            description = (Console.ReadLine());

            Console.SetCursorPosition(15, 2);
            Console.Write("Write Amount Example [ 100 ]: ");
            try
            {
                amount = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException )
            {
                Console.WriteLine("the chain does not have the correct format");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error", e);
            }
            
            Console.SetCursorPosition(15, 4);
            Console.Write("Write Date Format YYYY/M/D [Empty current date]: ");
            date = (Console.ReadLine());

            if (date == "")
            {
                string datePatt = @"yyyy/M/d";
                DateTime d = DateTime.Now;
                date = d.ToString(datePatt);
            }

            Console.SetCursorPosition(15, 6);
            int top = 7;
            Console.WriteLine("Write CATEGORY: ");

            if (addCategory.Count > 0)
            {

                foreach (KeyValuePair<int, Category> data in addCategory)
                {
                    Console.SetCursorPosition(15, top++);
                    Console.WriteLine(data.Key + " " + data.Value.GetNameCategory());
                }
                Console.SetCursorPosition(15, top++);
                Console.Write("CHOOSE CATEGORY: ");
           
                try
                {
                    category = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Error: " + e);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error", e);
                }

                if (num == 1)
                {
                    Income i = new Income(description, date, amount, category);
                    addIncome.Add(i);
                    userFile.SaveIncomes(addIncome);
                }

                if(num == 2)
                {
                    Expense e = new Expense(description, date, amount, category);
                    addExpense.Add(e);
                    userFile.SaveExpenses(addExpense);
                }
            }
            else
            {
                Console.SetCursorPosition(15, top++);
                Console.WriteLine("No category, we will create a category");
            }

            Console.SetCursorPosition(15, top++);
            Console.Write("Press any key to exit....");
            Console.ReadLine();
            Console.Clear();
        }

        //calls the method that shows all income and expense data
        public void List()
        {
            ListExpenses list = new ListExpenses();
            list.DisplayAll();
        }

        public void search()
        {
            Console.Clear();
            string text = "";
           
            do
            {
                Console.SetCursorPosition(23, 0);
                Console.WriteLine("0-SEARCH BY CATEGORY");
                Console.SetCursorPosition(23, 1);
                Console.WriteLine("1-SEARCH BY TWO DATE");
                Console.SetCursorPosition(23, 2);
                Console.WriteLine("2-SEARCH EXPENSE");
                Console.SetCursorPosition(23, 3);
                Console.WriteLine("3-SEARCH INCOME");
                Console.SetCursorPosition(23, 4);
                text = Console.ReadLine();
            } while (text == " ");
            Console.Clear();
            
            bool exit = false;
            ConsoleKeyInfo keyInfo;
            do
            {
                Console.Clear();
                if (text == "0")
                    Search(text);
                else if (text == "1")
                    SearchBetweenTwoDates();
                else if (text == "2")
                    SearchExpenseOrIncome(text);
                else if (text == "3")
                    SearchExpenseOrIncome(text);
                    
                keyInfo = Console.ReadKey();
                Console.SetCursorPosition(0, 24); //END CONSOLE

                if (keyInfo.Key == ConsoleKey.Escape)
                    exit = true;

                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    //TODO
                }

                if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    //TODO
                }



            } while (!exit);
            Console.Clear();
            Console.WriteLine("Press any key to show Menu...");
            
            
        }

        public void SearchExpenseOrIncome(string text)
        {
            if (text == "2")
            {
                bool found = false;
                text = "";
                Console.WriteLine("Enter text to search in expense");
                text = Console.ReadLine();

                foreach (Expense value in addExpense)
                {
                    if (value.GetDescription().Contains(text) ||
                        value.GetDate().Contains(text) ||
                        value.GetAmount().Equals(text) ||
                        value.GetNameCategory().Contains(text))
                    {
                        Console.WriteLine(value.GetDescription()
                             + value.GetAmount() + value.GetDate());
                        found = true;
                    }
                }

                if (!found)
                {
                    Console.WriteLine("Error Not data Found!!");
                }
            }

            if (text == "3")
            {
                bool found = false;
                text = "";
                Console.WriteLine("Enter text to search in expense");
                text = Console.ReadLine();

                foreach (Income value in addIncome)
                {
                    if (value.GetDescription().Contains(text) ||
                        value.GetDate().Contains(text) ||
                        value.GetAmount().Equals(text) ||
                        value.GetNameCategory().Contains(text))
                    {
                        Console.WriteLine(value.GetDescription()
                             + value.GetAmount() + value.GetDate());
                        found = true;
                    }
                }

                if (!found)
                {
                    Console.WriteLine("Error Not data Found!!");
                }
            }

        }

        public void SearchBetweenTwoDates()
        {
            string dateFirst = "";
            string dateSecond = "";
            bool found = false; 
            Console.WriteLine("From: first date Example 2015/5/26 ");
            dateFirst = Console.ReadLine();

            Console.WriteLine("To: Example 2015/5/27");
            dateSecond = Console.ReadLine();
            Console.Clear();

            foreach(Expense value in addExpense){

                if (dateFirst.CompareTo(value.GetDate().Trim()) > 0 
                    || dateSecond.CompareTo(value.GetDate().Trim()) > 0 )
                {
                    Console.WriteLine(value.GetDate() + value.GetDescription());
                    found = true;
                }
            }

            foreach (Income value in addIncome)
            {

                if (dateFirst.CompareTo(value.GetDate().Trim()) > 0
                    || dateSecond.CompareTo(value.GetDate().Trim()) > 0)
                {
                    Console.WriteLine(value.GetDate() + 
                                value.GetDescription());
                    found = true;
                }
            }

            if(!found)
                Console.WriteLine("NO DATA FOUND");

        }
        public void Search(string text)
        {
            Console.Clear();
            int top = 4;
            Console.SetCursorPosition(23, 3);
            Console.WriteLine("Enter Number of category : ");
            Console.Write("");
            if (addCategory.Count > 0)
            {

                foreach (KeyValuePair<int, Category> data in addCategory)
                {
                    Console.SetCursorPosition(23, top++);
                    Console.WriteLine(data.Key + " " + 
                            data.Value.GetNameCategory());
                }
            }
            Console.SetCursorPosition(23, top++);
            text = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("ESC- EXIT");
            Console.WriteLine("###################INCOME####################");
            foreach (Expense exp in addExpense)
            {
                if (addCategory.ContainsKey(Convert.ToInt32(text)))
                {
                    Console.WriteLine("Date:" + exp.GetDate() + " Amount:" +
                        exp.GetAmount() + " Category:" +
                         addCategory[Convert.ToInt32(text)].
                         GetNameCategory());
                    Console.WriteLine("Description:" + exp.GetDescription());
                    Console.WriteLine("----------------------------------------");
                }
            }

            Console.WriteLine("###################INCOME####################");
            foreach (Income income in addIncome)
            {
                if (addCategory.ContainsKey(Convert.ToInt32(text)))
                {
                    Console.WriteLine("Date:" + income.GetDate() + " Amount:" +
                        income.GetAmount() + " Category:" +
                         addCategory[Convert.ToInt32(text)].
                         GetNameCategory());
                    Console.WriteLine("Description:" + income.GetDescription());
                    Console.WriteLine("----------------------------------------");
                }
            }
        }

        //method displays the main menu of the application
        public void Menu()
        {
            Welcome w = new Welcome();
            w.WelcomeScreen();
            Console.Clear();
            ListExpenses l = new ListExpenses();
            l.ListAll();
            Load();
            do
            {
                l.ListAll();
                Console.SetCursorPosition(10, 25);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("1-Income 2-Expense 3-Add category 4-List " +
                            "5-Search 6-Help 7-Exit  ");
                try
                {
                    option = Convert.ToInt32(Console.ReadLine()) - 1;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Format Exception: ", e);
                }
                catch(Exception e){
                    Console.WriteLine("Error",e);
                }

                switch (option)
                {
                    case (int)menu.INCOME:
                        Add(1);
                        break;
                    case (int)menu.EXPENSE:
                        Add(2);
                        break;
                    case (int)menu.CATEGORY:
                        AddNewCategory();
                        break;
                    case (int)menu.LIST:
                        List();
                        break;
                    case (int)menu.SEARCH:
                        search();
                        break;
                    case (int)menu.HELP:
                        w.Help();
                        break;
                    case (int)menu.EXIT:
                        Console.Clear();
                        break;
                }

            } while ((option != (int)menu.EXIT));

        }

    }
}
