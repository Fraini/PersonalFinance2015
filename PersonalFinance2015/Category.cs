//Fraini Sánchez V00
/*
 *Class category with method and get 
 */
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

        public virtual void setNameCategory(string newValue)
        {
            this.name = newValue;
        }

        public virtual string GetNameCategory()
        {
            return this.name;
        }
    }
}
