using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppTest.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Display(String ip, int port)
        {
            ViewBag.IP = ip;
            ViewBag.Port = port;
            return View();
        }

        [HttpGet]
        public ActionResult DisplayFreq(String ip, int port, int freq)
        {
            ViewBag.IP = ip; ViewBag.Port = port; ViewBag.Freq = freq;
            return View();
        }

        [HttpGet]
        public ActionResult DisplayFile(String filename, int freq)
        {
            ViewBag.File = filename; ViewBag.freq = freq;
            return View();
        }

        [HttpGet]
        public ActionResult Save(String ip, int port, int freq, int time, String filename)
        {
            ViewBag.IP = ip; ViewBag.Port = port; ViewBag.Freq = freq; ViewBag.Time = time; ViewBag.File = filename;
            return View();
        }
    }
}