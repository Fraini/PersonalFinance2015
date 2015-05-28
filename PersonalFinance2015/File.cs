//Amiel Lopez Galvez
//V014
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
//I made a load and save method for Income,Expense and Category
//I putted the 3 save methods in the interface and it seems to work
namespace PersonalFinance2015
{
    class DataFile
    {
        private StreamReader sr;
        private StreamWriter sw,sw2,sw3;
        private string description;
        private string date;
        private string amount;
        private string category;

        public List<Income> LoadIncomes()
        {
            List<Income> LoadedIncomes = new List<Income>();


            if (!File.Exists("Incomes.txt"))
            {
                StreamWriter createFile = new StreamWriter("Incomes.txt");
                createFile.Close();
            }
            
            sr = new StreamReader("Incomes.txt", false);
            string line ="";
            do
            {
                line = sr.ReadLine();

                if (line != "" && line != null  )
                {
                    description = line.Substring(13);
                }

                line = sr.ReadLine();

                if (line != null)
                {
                    date = line.Substring(6);
                }

                line = sr.ReadLine();

                if (line != null)
                {
                    amount = line.Substring(8);
                }

                line = sr.ReadLine();
                if (line != null)
                    category = line.Substring(10);

                if (line != null)
                {
                    Income LoadingIncome = new Income(description, date, amount, category);
                    LoadedIncomes.Add(LoadingIncome);
                }
                    
            } while (line != null);

            sr.Close();
            return LoadedIncomes;
        }

        public List<Expense> LoadExpenses()
        {
            List<Expense> LoadedExpenses = new List<Expense>();
     
            if (!File.Exists("Expenses.txt"))
            {
                StreamWriter createFile = new StreamWriter("Expenses.txt");
                createFile.Close();
            }

            sr = new StreamReader("Expenses.txt",false);
           
            string line ="";

            do
            {
                line = sr.ReadLine();

                if (line != "" && line != null)
                {
                    description = line.Substring(12);
                }

                line = sr.ReadLine();

                if (line != null)
                {
                    date = line.Substring(5);
                }
                
                line = sr.ReadLine();

                if (line != null)
                {
                    amount = line.Substring(7);
                }
                
                line = sr.ReadLine();
                if (line != null)
                    category = line.Substring(9);

                if (line != null)
                {
                    Expense LoadingExpense = new Expense(description, date, amount, category);
                    LoadedExpenses.Add(LoadingExpense);
                }
                

            } while (line != null);

            sr.Close();
            return LoadedExpenses;
        }

        public List<Category> LoadCategory()
        {
            List<Category> LoadedCategory = new List<Category>();

            if (!File.Exists("Category.txt"))
            {
                StreamWriter createFile = new StreamWriter("Category.txt");
                createFile.Close();
            }

            sr = new StreamReader("Category.txt", true);
            string line;

            do
            {
                line = sr.ReadLine();
                if (line != null)
                {
                    Category LoadingCategory = new Category(line);
                    LoadedCategory.Add(LoadingCategory);
                }

            } while (line != null);

            sr.Close();
            return LoadedCategory;
        }

        public void SaveExpenses(List<Expense> Expenses)
        {
            //If exists not overwrite
            if ((File.Exists("Expenses.txt")))
            {
                sw = File.CreateText("Expenses.txt");
            }
            //If not exist
            else
            {
                sw = new StreamWriter("Expenses.txt");
                sw.Close();
            }

            foreach (Expense searchingExpenses in Expenses)
            {
                sw.WriteLine("Description: " + searchingExpenses.GetDescription());
                sw.WriteLine("Date: " + searchingExpenses.GetDate());
                sw.WriteLine("Amount: " + searchingExpenses.GetQuantity());
                sw.WriteLine("Category: " + searchingExpenses.GetNameCategory());
            }
            sw.Close();
            
        }
        public void SaveIncomes(List<Income> Incomes)
        {
             //Saving all parts of the incomes
            if ((File.Exists("Incomes.txt")))
            {
                sw2 = File.CreateText("Incomes.txt");
            }
            //If not exist
            else
            {
                sw2 = new StreamWriter("Incomes.txt");
            }

            foreach (Income searchingIncomes in Incomes)
            {
                sw2.WriteLine("Description: " + searchingIncomes.GetDescription());
                sw2.WriteLine("Date: " + searchingIncomes.GetDate());
                sw2.WriteLine("Amount: " + searchingIncomes.GetQuantity());
                sw2.WriteLine("Category: " + searchingIncomes.GetNameCategory());
            }

            sw2.Close();
        }
        public void SaveCategory(List<Category> Categories)
        {
            //Saving category names
            if ((File.Exists("Category.txt")))
            {
                sw3 = File.CreateText("Category.txt");
            }
            //If not exist
            else
            {
                sw3 = new StreamWriter("Category.txt",false);
            }
            
            foreach (Category searchingCategories in Categories)
            {
                sw3.WriteLine("Category name: " + searchingCategories.GetNameCategory().Substring(15));

            }
            sw3.Close();
        }
    }
}
