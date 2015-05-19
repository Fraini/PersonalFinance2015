//Fraini Sánchez V00
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
        private int key;
        private string value;
        public Category()
        {

        }

        public void setNameCategory(int newKey,string newValue)
        {
            this.key = newKey;
            this.value = newValue;
        }

        public string GetName()
        {
            return this.key +" - "+this.value;
        }
    }
}
