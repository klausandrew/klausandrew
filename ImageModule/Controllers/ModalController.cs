using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImageModule.Controllers
{
    //IEnumerable<T> record set 
    
    public class ModalController : Controller
    {
        //
        // GET: /Modal/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UpdateRecord()
        {
            return PartialView();        
        }

        [HttpPost]
        public ActionResult UpdateRecord(FormCollection record) {
            return View();
        }

    }
}
