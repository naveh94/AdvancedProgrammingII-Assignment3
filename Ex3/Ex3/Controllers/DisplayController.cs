using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ex3.Controllers
{
    public class DisplayController : Controller
    {
        // GET: Display
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DisplaySinglePoint(String ip, int port)
        {
            ViewBag.IP = ip;
            ViewBag.Port = port;
            return View();
        }

        public ActionResult DisplayFreq(String ip, int port, int freq)
        {
            ViewBag.IP = ip;
            ViewBag.Port = port;
            ViewBag.Freq = freq;
            return View();
        }

        public ActionResult DisplayFile(String filename, int freq)
        {
            ViewBag.File = filename;
            ViewBag.Freq = freq;
            return View();
        }

        // GET: Save
        public ActionResult SaveFile(String ip, int port, int freq, int time, String filename)
        {
            ViewBag.IP = ip;
            ViewBag.Port = port;
            ViewBag.Freq = freq;
            ViewBag.Time = time;
            ViewBag.File = filename;
            return View();
        }

        public string GetPoint()
        {
            //todo
            return "";
        }
    }
}