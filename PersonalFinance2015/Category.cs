//Fraini Sánchez V14
//Debugging code
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance2015
{
    class Category
    {
        protected string name;
        public Category(string name)
        {
            this.name = name;
        }

        public virtual void SetNameCategory(string newValue)
        {
            this.name = newValue;
        }

        public virtual string GetNameCategory()
        {
            return this.name;
        }
    }
}
