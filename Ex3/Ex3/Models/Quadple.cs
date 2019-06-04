using System.Xml;

namespace Ex3.Models {

    public class Quadple

    {
        public double Lon { get; set; }
        public double Lat { get; set; }
        public double Throttle { get; set; }
        public double Rudder { get; set; }

        //constructor
        public Quadple(double lon, double lat, double rudder, double throttle)
        {
            this.Lon = lon;
            this.Lat = lat;
            this.Rudder = rudder;
            this.Throttle = throttle;
        }
        public void ToXML(XmlWriter writer)
        {
            writer.WriteStartElement("Quadple");
            writer.WriteElementString("Lon", this.Lon.ToString());
            writer.WriteElementString("Lat", this.Lat.ToString());
            writer.WriteElementString("Rudder", this.Rudder.ToString());
            writer.WriteElementString("Throttle", this.Throttle.ToString());
            writer.WriteEndElement();
        }
    }


}
