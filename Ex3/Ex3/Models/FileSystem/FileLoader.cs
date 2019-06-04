using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace Ex3.Models.FileSystem
{
    public class FileLoader
   
    {
        private string _path;

//loadinf file from the path
        public FileLoader(string path)
        {
            this._path = path;
      
        }
// reading the values from file
       public string ReadFromFile()
           
        {
            using (StreamReader reader = File.OpenText(_path))
            {
                string s = "", buffer;
                while((buffer= reader.ReadLine()) != null)
                {
                    s += buffer;
                }
                return s;
            }

        }
    }
}