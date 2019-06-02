using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ex3.Models
{
    public class FileSaver
    {
        string fileName = "flight1";
        //not sure there is need of properties
        public string FileName { get => fileName; set => fileName = value; }
        public void SaveToFile(string input, string fileName)
        {
            this.fileName = fileName;
        }
        
    }
}