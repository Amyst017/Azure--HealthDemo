using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcDemo.Controllers
{
    public class ErrorController : Controller
    {
        // from global.asax
        // GET: /Error/
        public ActionResult Index()
        {            
           return View("~/Views/Shared/Error.cshtml");
        }

        // from global.asax
        // GET: /Error/
        public ActionResult NotFound() {
            ViewBag.error = 404;
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}


// URL errors to handle: https://visualstudiomagazine.com/articles/2015/06/01/handling-bad-urls.aspx