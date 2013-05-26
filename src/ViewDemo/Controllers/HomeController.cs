using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ViewDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "歡迎參加 TW MVC 活動!";

            List<Product> products = new List<Product>();
            products.Add(new Product() { Id = 1, Name = "PS3", Price = 10000 });
            products.Add(new Product() { Id = 2, Name = "Wii", Price = 6000 });
            products.Add(new Product() { Id = 3, Name = "Xbox", Price = 10600 });

            return View(products);
        }

        public ActionResult Notify()
        {
            if (DateTime.Now > new DateTime(2012, 4, 26))
            {
                ViewBag.Message = "今天是第一次TW MVC的活動，大家盡量吃儘量喝";
            }
            else
            {
                ViewBag.Message = "活動還沒開始，加緊準備吧";
            }

            return View();
        }

        public ActionResult Jmpress()
        {
            return View();
        }

        public ActionResult Highcharts()
        {
            return View();
        }
    }
}
