using Ex3.Models;
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
        private readonly static Random rnd = new Random();

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
            return ToXml(PointStream.Instance().GetPoint());
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