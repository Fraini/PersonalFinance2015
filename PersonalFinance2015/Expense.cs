//Fraini Sánchez V007
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance2015
{
    class Expense 
    {
        private string description;
        private string date;
        private ArrayList addExpense;

        public Expense()
        {
            addExpense = new ArrayList();
        }

        public virtual void setDescription(string description){
            this.description = description;
            addExpense.Add(".¬"+description);
        }

        public virtual string getDescription()
        {
            return this.description;
        }

        public virtual void SetDate(string date)
        {
            this.date = date;
            addExpense.Add(";¬" + description);
        }

        public virtual string getDate()
        {
            return this.date;
        }
    }
}
