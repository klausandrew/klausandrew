using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bootstrap.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }

        public ActionResult ViewLyubomir() {
            return PartialView("_Lyubomir");
        }

        [HttpPost]
        public ActionResult Lyubomir() {
            var info = ViewBag.Info;
            return RedirectToAction("Index");
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}