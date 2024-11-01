using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace K22_TranDuyVu_2210900138.Controllers
{
    public class TDVHomeController : Controller
    {
        public ActionResult TDVIndex()
        {
            return View();
        }

        public ActionResult TDVAbout()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult TDVContact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}