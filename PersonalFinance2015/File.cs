//Fraini Sánchez V007
/*
 *Class manage file of all class 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PersonalFinance2015
{
    class DataFile
    {
        private StreamReader sr;
        private StreamWriter sw;
        private string nameFile;
        private List<string> data;
        public DataFile()
        {
        }

        //METHOD LOAD FILE DEPENDING OF NUMBER [ 1--> Class Income, 2-->Class Expense, 3--> class Category ]
        public List<string> Load(int num)
        {
            string text = "";
            data = new List<string>();
            if(num == 1 ){
                nameFile = "Income.txt";
                if ((File.Exists(nameFile)))
                    sr = new StreamReader(nameFile, true);
                    
            }

            if (num == 2)
            {
                nameFile = "Expense.txt";
                if ((File.Exists(nameFile)))
                    sr = new StreamReader(nameFile, true);

            }

            if (num == 3)
            {
                nameFile = "Category.txt";
                if ((File.Exists(nameFile)))
                    sr = new StreamReader(nameFile, true);

            }

            //num 4 planned expenditures
            do{
                text = sr.ReadLine();
                if (text != null)
                    data.Add(text);

            }while(text != null);
            sr.Close();

            return data;
        }

        public void SavedExpense(List<Expense> data)
        {
    
           if (!(File.Exists(nameFile)))
                  nameFile = "Expense.txt";
         
            sw = new StreamWriter(nameFile);
            foreach(Expense e in data){
                sw.WriteLine(e);
            }
            sw.Close();
        }

        public void SavedIncome(List<Income> data)
        {

            if (!(File.Exists(nameFile)))
                nameFile = "Income.txt";

            sw = new StreamWriter(nameFile);
            foreach (Income i in data)
            {
                sw.WriteLine(i);
            }
            sw.Close();
        }

        public void SavedCategory(List<Category> data)
        {

            if (!(File.Exists(nameFile)))
                nameFile = "Category.txt";

            sw = new StreamWriter(nameFile);
            foreach (Category c in data)
            {
                sw.WriteLine(c);
            }
            sw.Close();
        }
    }
}
