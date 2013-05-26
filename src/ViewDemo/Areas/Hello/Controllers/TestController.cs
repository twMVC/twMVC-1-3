using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ViewDemo.Areas.Hello.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Hello/Test/

        public ActionResult Index()
        {
            return View();
        }

    }
}
