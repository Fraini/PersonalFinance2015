//Fraini Sánchez V0014
//Falla al guardar categoria y al hacer el calculo de total Expenses
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

        public void Load()
        {
            addCategory = userFile.LoadCategory();
            addExpense = userFile.LoadExpenses();
            addIncome = userFile.LoadIncomes();

        }

        public Dictionary<int,Category> SavedCategory(int key,string name)
        {
            Category c = new Category(key,name);
            userFile.SaveCategoryFile(c);
            addCategory.Add(key++,c);
            
            return addCategory;
        }

        public List<Expense> SavedCategory(string d, string dt, string q, string c)
        {
            Expense e = new Expense(d, dt, q, c);
            addExpense.Add(e);
            return addExpense;

        }

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
                    SavedCategory(key,name);

                Console.Write("Name?: ");
                name = Console.ReadLine();

            }

            Console.Write("Press any key to exit....");
            Console.ReadLine();
            //Saving always at the end
            Console.Clear();
        }

        public void AddNewExpense()
        {
            string description;
            string date;
            string quantity;
            string category;

            Console.Clear();
            Console.SetCursorPosition(15, 0);
            Console.Write("Write Description: ");
            description = (Console.ReadLine());

            Console.SetCursorPosition(15, 2);
            Console.Write("Write Amount: ");
            quantity = (Console.ReadLine());

            Console.SetCursorPosition(15, 4);
            Console.Write("Write Date Format YYYY/M/D: [Empty current date]");
            date = (Console.ReadLine());
            //if the user not insert date, automatically get date today
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
                    Console.WriteLine(data.Key +" "+data.Value.GetNameCategory());
                }

                Console.SetCursorPosition(15, top++);
                Console.Write("CHOOSE CATEGORY: ");
                //add loop to choose correct
                category = Console.ReadLine();
                SavedCategory(description, date, quantity, category);
            }
            else
            {
                Console.SetCursorPosition(15, top++);
                Console.WriteLine("No category, we will create a category");
            }

            //Saving always at the end of the file
            userFile.SaveExpenses(addExpense);

            Console.SetCursorPosition(15, top++);
            Console.Write("Press any key to exit....");
            Console.ReadLine();
            Console.Clear();


        }

        public void AddNewIncome()
        {

            string description;
            string date;
            string quantity;
            string category;

            Console.Clear();
            Console.SetCursorPosition(15, 0);
            Console.Write("Write Description: ");
            description = (Console.ReadLine());

            Console.SetCursorPosition(15, 2);
            Console.Write("Write Amount: ");
            quantity = (Console.ReadLine());

            Console.SetCursorPosition(15, 4);
            Console.Write("Write Date Format YYYY/M/D: [Empty current date]");
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
                    Console.WriteLine(data.Key+ " "+data.Value.GetNameCategory());
                }
                Console.SetCursorPosition(15, top++);
                Console.Write("CHOOSE CATEGORY: ");
                //add loop to choose correct
                category = Console.ReadLine();
                Income i = new Income(description, date, quantity, category);
                addIncome.Add(i);
            }
            else
            {
                Console.SetCursorPosition(15, top++);
                Console.WriteLine("No category, we will create a category");
            }

            Console.SetCursorPosition(15, top++);
            Console.Write("Press any key to exit....");
            Console.ReadLine();
            //Saving always at the end of the file
            userFile.SaveIncomes(addIncome);
            Console.Clear();
        }

        public void List()
        {
            ListExpenses list = new ListExpenses();
            Console.SetCursorPosition(15, 5);
            list.DisplayAll();
            Console.ReadLine();
        }


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
                    Console.WriteLine("Error: ", e);
                }

                switch (option)
                {
                    case (int)menu.INCOME:
                        AddNewIncome();
                        break;
                    case (int)menu.EXPENSE:
                        AddNewExpense();
                        break;
                    case (int)menu.CATEGORY:
                        AddNewCategory();
                        break;
                    case (int)menu.LIST:
                        List();
                        break;
                    case (int)menu.SEARCH:
                        Console.WriteLine("NOT IMPLEMENT");
                        //TO DO
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
