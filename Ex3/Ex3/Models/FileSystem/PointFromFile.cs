using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace Ex3.Models.FileSystem
{
    
    public class PointFromFile : IPointSource
    {
        private XmlNodeList _xml;
        private int _index;

        //getting the point values from the file 
        public PointFromFile(string path)
        {
            this._index = 0;
            FileLoader fl = new FileLoader(path);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(fl.ReadFromFile());
            this._xml = doc.DocumentElement.ChildNodes;
        }


        public Point GetPoint()
        {
            if (this._index >= _xml.Count)
            {
                return null;
            }
            double lon = double.Parse(_xml[_index]["Lon"].InnerText);
            double lat = double.Parse(_xml[_index]["Lat"].InnerText);
            this._index++;
            return new Point(lon, lat);
        }

        public void Close() { }
       
    }
}