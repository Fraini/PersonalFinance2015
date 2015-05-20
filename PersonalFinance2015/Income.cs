//Fraini Sánchez V008
/*
 *Class Income what inherit of Expense with method and get 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance2015
{
    class Income : Expense
    {
        public Income(string description, string date, string quantity, string category) : base(
             description,date,quantity,category )
        {
           
        }

        public override void SetDate(string date)
        {
            base.SetDate(date);
        }

        public override string getDate()
        {
            return base.getDate();
        }

        public override void setDescription(string description)
        {
            base.setDescription(description);
        }

        public override string getDescription()
        {
            return base.getDescription();
        }

        public override void SetQuantity(string value)
        {
            base.SetQuantity(value);
        }

        public override string GetQuantity()
        {
            return base.GetQuantity();
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
