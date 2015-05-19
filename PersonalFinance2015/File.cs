//Fraini Sánchez V007
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
        public DataFile()
        {
            if (! (File.Exists(nameFile)))
                nameFile = "Bd.txt";
        }

        public void Load()
        {
            sr = new StreamReader(nameFile,true);

            sr.Close();
        }

        public void Saved()
        {
            sw = new StreamWriter(nameFile);

            sw.Close();
        }
    }
}
