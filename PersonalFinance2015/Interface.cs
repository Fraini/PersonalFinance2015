//Fraini Sánchez V0012
/*
 *Class Interface manage all class and method
 */
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
        private enum menu {INCOME,EXPENSE,CATEGORY,LIST,SEARCH,EXIT};
        private int option;
        List<Category> addCategory;
        List<Expense> addExpense;
        List<Income> addIncome;
        public Interface()
        {
            addCategory = new List<Category>();
            addExpense = new List<Expense>();
            addIncome = new List<Income>();
        }

        //Add Income and Add Expense using delimiter "x¬" where x is number 0 -->Description ...
        public void AddNewCategory()
        {
            Console.Clear();
            string name;
            do
            {
                Console.Write("Name: ");
                name = Console.ReadLine();
                if (name != "")
                {
                    Category c = new Category(name);
                    addCategory.Add(c);
                }

            } while (name != "");
            Console.Write("Press any key to exit....");
            Console.ReadLine();
                        
        }

        public void AddNewExpense()
        {
            string description;
            string date;
            string quantity;
            string category;
            
            Console.Clear();
            Console.SetCursorPosition(15, 0);
            Console.Write("Description: ");
            description = "0¬"+(Console.ReadLine());

            Console.SetCursorPosition(15, 2);
            Console.Write("Quantity: ");
            quantity = "1¬"+(Console.ReadLine());

            Console.SetCursorPosition(15, 4);
            Console.Write("Date: ");
            date = "2¬"+(Console.ReadLine());
           
            Console.SetCursorPosition(15, 6);
            int top = 7;
            Console.WriteLine("CATEGORY: ");

           if (addCategory.Count > 0)
            {

                foreach (Category value in addCategory)
                {
                    Console.SetCursorPosition(15, top++);
                    Console.WriteLine(value.GetNameCategory());
                }
                Console.SetCursorPosition(15, top++);
                Console.Write("CHOOSE CATEGORY: ");
                //add loop to choose correct
                category = "3¬"+ Console.ReadLine();
                Expense e = new Expense(description, date, quantity, category);
                addExpense.Add(e);
             
            }
            else
            {
                Console.SetCursorPosition(15, top++);
                Console.WriteLine("No category, we will create a category");
            }

            Console.SetCursorPosition(15, top++);
            Console.Write("Press any key to exit....");
            Console.ReadLine();
        }

        public void AddNewIncome()
        {
            string description;
            string date;
            string quantity;
            string category;

            Console.Clear();
            Console.SetCursorPosition(15, 0);
            Console.Write("Description: ");
            description ="0¬"+ (Console.ReadLine());

            Console.SetCursorPosition(15, 2);
            Console.Write("Quantity: ");
            quantity = "1¬"+(Console.ReadLine());

            Console.SetCursorPosition(15, 4);
            Console.Write("Date: ");
            date = "2¬"+(Console.ReadLine());

            Console.SetCursorPosition(15, 6);
            int top = 7;
            Console.WriteLine("CATEGORY: ");

            if (addCategory.Count > 0)
            {

                foreach (Category value in addCategory)
                {
                    Console.SetCursorPosition(15, top++);
                    Console.WriteLine(value.GetNameCategory());
                }
                Console.SetCursorPosition(15, top++);
                Console.Write("CHOOSE CATEGORY: ");
                //add loop to choose correct
                category = "3¬"+ Console.ReadLine();
                Income i = new Income (description, date, quantity, category);
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
        }

        public void Menu()
        {
            Welcome w = new Welcome();
            w.WelcomeScreen();
            do{
                Console.SetCursorPosition(10,40);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("1-Income 2-Expense 3-Add category 4-List "+  
                            "5-Search 6-Exit  ");
                try{
                option = Convert.ToInt32(Console.ReadLine()) -1;
            }
            catch(FormatException e){
                Console.WriteLine("Error: ",e);
            }

            switch (option)
            {
                case (int) menu.INCOME:
                        AddNewIncome();   
                    break;
                case (int)menu.EXPENSE:
                    AddNewExpense();
                    break;
                case (int)menu.CATEGORY:
                        AddNewCategory();
                    break;
                case (int)menu.LIST:
                    Console.Clear();
                    foreach(Category v in addCategory){
                       Console.WriteLine(v);
                   }
                    break;
                case (int)menu.SEARCH:
                    //TO DO
                    break;
                case (int)menu.EXIT:
                    Console.Clear();
                    break;
            }

            }while( (option != (int) menu.EXIT));  
        }
    }
}
