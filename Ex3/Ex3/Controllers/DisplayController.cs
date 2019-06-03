using Ex3.Models;
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
        private static Random rnd = new Random();

        // GET: Display
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DisplaySinglePoint(String ip, int port)
        {
            ViewBag.Freq = 0;
            ViewBag.Time = 0;
            return View();
        }

        public ActionResult DisplayFreq(String ip, int port, int freq)
        {
            ViewBag.Freq = freq;
            ViewBag.Time = 0;
            return View();
        }

        public ActionResult DisplayFile(String filename, int freq)
        {
            ViewBag.File = filename;
            ViewBag.Freq = freq;
            ViewBag.Time = 0;
            return View();
        }

        // GET: Save
        public ActionResult SaveFile(String ip, int port, int freq, int time, String filename)
        {
            ViewBag.Freq = freq;
            ViewBag.Time = time;
            ViewBag.File = filename;
            return View();
        }

        [HttpPost]
        public string GetPoint()
        {
            int x = rnd.Next(360) - 180;
            int y = rnd.Next(180) - 90;

            return ToXml(new Point(x,y));
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
    }
}