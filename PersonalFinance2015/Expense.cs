//Fraini Sánchez v13
/*
 *Class Income  with method and get 
 */
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance2015
{
    class Expense : Category
    {
        private string description;
        private string date;
        private string quantity;
       
        public Expense(string description,string date,string quantity,string category) : base(category)
        {
            this.description = description;
            this.date = date;
            this.quantity = quantity; 
        }

        public virtual void setDescription(string description){
            this.description = description;
        }

        public virtual string getDescription()
        {
            return this.description;
        }

        public virtual void SetDate(string date)
        {
            this.date = date;
        }

        public virtual string getDate()
        {
            return this.date;
        }

        public virtual void SetQuantity(string value)
        {
            this.quantity = value;
        }

        public virtual string GetQuantity()
        {
            return this.quantity;
        }

        public override void setNameCategory(string newValue)
        {
            base.setNameCategory(newValue);
        }

        public override string GetNameCategory()
        {
            return base.GetNameCategory();
        }

    }
}
