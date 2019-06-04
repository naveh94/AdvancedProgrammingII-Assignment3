using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ex3.Models.FileSystem
{
    public class FileSaver
    {
        IPointSource pointSource = new IPointSource();
        string fileName = "flight1";
        //string filePath= "C:\Users\Noa\Source\Repos\noazoulay\Exercise3\Ex3\Ex3\Models\Saved\flight1.txt";
        
        public void SaveToFile(string input, string fileName)
        {
            System.IO.File.WriteAllText(@"C:\Users\Noa\Source\Repos\noazoulay\Exercise3\Ex3\Ex3\Models\Saved\flight1.txt", input);
          //  using (Stream destination = File.Create("flight1")) ;
          //      Write(stream, destination);

        }

        public void Write(Stream from, Stream to)
        {
            for (int a = from.ReadByte(); a != -1; a = from.ReadByte())
                to.WriteByte((byte)a);
        }

        

    }
}