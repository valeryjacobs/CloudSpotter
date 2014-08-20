using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CloudExperienceWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welkom bij de Microsoft Cloud Experience demo website!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
