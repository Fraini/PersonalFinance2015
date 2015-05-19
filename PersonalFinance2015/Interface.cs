//Fraini Sánchez V0012
//IMPLEMENT CASE INCOME V010 
//IMPLEMENT CASE EXPENSE V11
//IMPLEMENT CASE CATEGORY V12
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
        private int index;
        ArrayList addData;
        List<Category> addCategory;
        public Interface()
        {
            addData = new ArrayList();
            addCategory = new List<Category>();
        }

        public void Load()
        {
            Expense e = new Expense();
            
        }

        public void AddNewCategory()
        {
            Console.Clear();
            string name;
            index = addCategory.Count;
            do
            {
                Category c = new Category();
                Console.Write("Name: ");
                name = Console.ReadLine();
                if (name != "")
                {
                    c.setNameCategory(index, name);
                    addCategory.Add(c);
                    index++;
                }

            } while (name != "");
            Console.Write("Press any key to exit....");
            Console.ReadLine();
                        
        }

        public void AddNewExpense()
        {
            string catNumber;
            Expense e = new Expense();
            Console.Clear();
            Console.SetCursorPosition(15, 0);
            Console.Write("Description: ");
            e.setDescription(Console.ReadLine());
            addData.Add(e.getDescription());

            Console.SetCursorPosition(15, 2);
            Console.Write("Date: ");
            e.SetDate(Console.ReadLine());
            addData.Add(e.getDate());

            Console.SetCursorPosition(15, 4);
            int top = 5;
            Console.WriteLine("CATEGORY: ");

            if (addCategory.Count > 0)
            {

                foreach (Category value in addCategory)
                {
                    Console.SetCursorPosition(15, top++);
                    Console.WriteLine(value.GetName());
                }
                Console.SetCursorPosition(15, top++);
                Console.Write("CHOOSE CATEGORY: ");
                //add loop to choose correct
                catNumber = Console.ReadLine();
                addData.Add(catNumber);
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
            Income i = new Income();
            string catNumber = "";
            Console.Clear();
            Console.SetCursorPosition(15, 0);
            Console.Write("Description: ");
            Console.SetCursorPosition(15, 1);
            i.setDescription(Console.ReadLine());
            addData.Add(i.getDescription());

            Console.SetCursorPosition(15, 2);
            Console.Write("Date: ");
            Console.SetCursorPosition(15, 3);
            i.SetDate(Console.ReadLine());
            addData.Add(i.getDate());
            int topCursor = 4;
            if (addCategory.Count > 0)
            {

                foreach (Category value in addCategory)
                {
                    Console.SetCursorPosition(15, topCursor++);
                    Console.WriteLine(value.GetName());
                }
                Console.SetCursorPosition(15, topCursor++);
                Console.Write("Choose category: ");
                catNumber = Console.ReadLine();
                addData.Add(catNumber);
            }
            else
                Console.WriteLine("No category, we will create a category");

            Console.SetCursorPosition(15, topCursor++);
            Console.Write("Press any key to exit....");
            Console.ReadLine();
        }

        public void Menu()
        {
            do{
                Console.SetCursorPosition(10,40);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
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
                   //TO DO
                    break;
                case (int)menu.SEARCH:
                    //TO DO
                    break;
                case (int)menu.EXIT:
                    break;
            }

            }while( (option != (int) menu.EXIT));
            
        }

    }
}
