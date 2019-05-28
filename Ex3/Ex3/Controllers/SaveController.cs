using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ex3.Controllers
{
    public class SaveController : Controller
    {
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
    }
}