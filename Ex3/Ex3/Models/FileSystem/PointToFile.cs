using Ex3.Models.Network;
using System;
using System.Text;
using System.Web;
using System.Xml;

namespace Ex3.Models.FileSystem
{
    public class PointToFile : IPointSource
    {
        private PointFromNetwork _client;
        private FileSaver _fileSaver;
        private string _path;
        private StringBuilder _sb;
        private XmlWriter _writer;

        public PointToFile(PointFromNetwork client, string path)
        {
            this._path = path;
            this._fileSaver = new FileSaver(this._path);
            this._client = client;

            this._sb = new StringBuilder();
            XmlWriterSettings settings = new XmlWriterSettings();
            this._writer = XmlWriter.Create(this._sb, settings);
            this._writer.WriteStartDocument();
            this._writer.WriteStartElement("SavedData");
        }

        public Point GetPoint()
        {
            Quadple quad = this._client.GetQuadple();
            quad.ToXML(this._writer);
            return new Point(quad.Lon, quad.Lat);
        }

        public void Close()
        {
            this._writer.WriteEndElement();
            this._writer.WriteEndDocument();
            this._writer.Flush();
            _fileSaver.CreateFile();
            _fileSaver.WriteToFile(this._sb.ToString());
            this._client.Close();
        }
    }
}
