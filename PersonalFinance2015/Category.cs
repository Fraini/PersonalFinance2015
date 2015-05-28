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
        protected int key;
        public Category(string name)
        {
            this.name = name;
        }

        //This constructor for use dictionary
        public Category(int key, string name)
        {
            this.name = name;
            this.key = key;
        }

        public virtual void SetNameCategory(string newValue)
        {
            this.name = newValue;
        }

        public virtual string GetNameCategory()
        {
            return this.name;
        }

        public virtual void  SetKey(int key)
        {
            this.key = key;
        }

        public virtual int GetKey()
        {
            return this.key;
        }
    }
}
