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
        public Income()
        {
            //TODO
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
    }
}
