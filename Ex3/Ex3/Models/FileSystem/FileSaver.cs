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

        public FileSaver(string path)
        {
            this._path = path;
        }

    public void CreateFile()
        {
            var fs = File.Create(_path);
            fs.Close();
        }

        public void WriteToFile(string input)
        {
            using(StreamWriter writer= File.CreateText(_path))
            {
                writer.Write(input);
            }
        }

    }
}