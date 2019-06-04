using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace Ex3.Models.FileSystem
{
    public class FileSaver
    {
        private string _path;
        //constructor
        public FileSaver(string path)
        {
            this._path = path;
        }
        //create file to save the values the simulator sent
    public void CreateFile()
        {
            var fs = File.Create(_path);
            fs.Close();
        }
        //after creating the file- writing the values to file
        public void WriteToFile(string input)
        {
            using(StreamWriter writer= File.CreateText(_path))
            {
                writer.Write(input);
            }
        }

    }
}