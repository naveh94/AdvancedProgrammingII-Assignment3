using Ex3.Models;
using Ex3.Models.FileSystem;
using Ex3.Models.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace Ex3.Controllers
{
    public class DisplayController : Controller
    {

        #region readonly
        private static readonly string FOLDER = @"~\Save\";
        private static readonly string EXTE = ".xml";
        private readonly static Random rnd = new Random();
        #endregion

        // GET: Display
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DisplaySinglePoint(String ip, int port)
        {
            IClient client;
            try
            {
                client = new Client(ip, port);
                client.Connect();
            }
            catch (Exception e)
            {
                ViewBag.Error = e;
                return View("Error", e);
            }
            PointStream.Instance(new PointFromNetwork(client));
            ViewBag.Freq = 0;
            ViewBag.Time = 0;
            return View();
        }

        public ActionResult DisplayFreq(String ip, int port, int freq)
        {
            IClient client;
            try
            {
                client = new Client(ip, port);
                client.Connect();
            } catch(Exception e)
            {
                ViewBag.Error = e;
                return View("Error", e);
            }
            PointStream.Instance(new PointFromNetwork(client));
            ViewBag.Freq = freq;
            ViewBag.Time = 0;
            return View();
        }

        public ActionResult DisplayFile(String filename, int freq)
        {
            PointStream.Instance(new PointFromFile(Path(filename)));
            ViewBag.Freq = freq;
            ViewBag.Time = 0;
            return View();
        }

        // GET: Save
        public ActionResult SaveFile(String ip, int port, int freq, int time, String filename)
        {
            IClient client;
            try
            {
                client = new Client(ip, port);
                client.Connect();
            }
            catch (Exception e)
            {
                ViewBag.Error = e;
                return View("Error", e);
            }
            PointStream.Instance(new PointToFile(new PointFromNetwork(client), Path(filename)));
            ViewBag.Freq = freq;
            ViewBag.Time = time;
            return View();
        }

        [HttpPost]
        public string GetPoint()
        {
            Point p = PointStream.Instance().GetPoint();
            if (p == null)
            {
                return null;
            }
            return ToXml(p);
        }

        private string ToXml(Point point)
        {
            StringBuilder sb = new StringBuilder();
            XmlWriterSettings settings = new XmlWriterSettings();
            XmlWriter writer = XmlWriter.Create(sb, settings);

            writer.WriteStartDocument();
            writer.WriteStartElement("Points");

            point.ToXml(writer);

            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();

            return sb.ToString();
        }

        [HttpPost]
        public void Close()
        {
            PointStream.Instance().Close();
        }

        private string Path(string filename)
        {
            return System.Web.HttpContext.Current.Server.MapPath(FOLDER + filename + EXTE);
        }
    }
}