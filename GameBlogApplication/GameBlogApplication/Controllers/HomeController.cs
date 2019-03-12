using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameBlogApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Aaaaaaaaaall about us!!!";


            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Um..about contacting us...";

            return View();
        }

        [HttpPost]
        public ViewResult SearchResults()
        {
            return View();
        }
    }
}