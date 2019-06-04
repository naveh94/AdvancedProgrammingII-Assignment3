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

        public FileLoader(string path)
        {
            this._path = path;
      
        }

       public void ReadFromFile()
           
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