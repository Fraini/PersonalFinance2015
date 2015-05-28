//Fraini Sánchez V008
//Debugging code
//add Income
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

        public override string GetDate()
        {
            return base.GetDate();
        }

        public override void SetDescription(string description)
        {
            base.SetDescription(description);
        }

        public override string GetDescription()
        {
            return base.GetDescription();
        }

        public override void SetQuantity(string value)
        {
            base.SetQuantity(value);
        }

        public override string GetQuantity()
        {
            return base.GetQuantity();
        }

        public override void SetNameCategory(string newValue)
        {
            base.SetNameCategory(newValue);
        }

        public override string GetNameCategory()
        {
            return base.GetNameCategory();
        }
    }
}
