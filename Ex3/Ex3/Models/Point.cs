using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace Ex3.Models
{
    public class Point
    {
        int X { get; set; }
        int Y { get; set; }

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public void ToXml(XmlWriter writer)
        {
            writer.WriteStartElement("Point");
            writer.WriteElementString("Lat", this.X.ToString());
            writer.WriteElementString("Lon", this.Y.ToString());
            writer.WriteEndElement();
        }
    }
}