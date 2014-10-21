using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Moshavit.REST22.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            var myZoneTime = TimeZoneInfo.FindSystemTimeZoneById("Israel Standard Time");
            var serverTime = DateTime.UtcNow;
            var israelTime = TimeZoneInfo.ConvertTimeFromUtc(serverTime, myZoneTime);

            return View(israelTime);
        }
    }
}
