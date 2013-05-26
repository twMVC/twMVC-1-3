using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;

namespace ViewDemo.Controllers
{
    public class FastDesignController : Controller
    {
        public ActionResult WebGrid()
        {
            //測試資料
            List<Product> products = new List<Product>();

            products.Add(new Product() { Id = 1, Name = "PS3", Price = 10000 });
            products.Add(new Product() { Id = 2, Name = "Wii", Price = 6000 });
            products.Add(new Product() { Id = 3, Name = "Xbox", Price = 10600 });
            products.Add(new Product() { Id = 4, Name = "PSP", Price = 5000 });
            products.Add(new Product() { Id = 5, Name = "NDS", Price = 4600 });
            products.Add(new Product() { Id = 6, Name = "iPhone", Price = 19000 });

            return View(products);
        }

        public ActionResult TraditionWebGrid()
        {
            //測試資料
            List<Product> products = new List<Product>();

            products.Add(new Product() { Id = 1, Name = "PS3", Price = 10000 });
            products.Add(new Product() { Id = 2, Name = "Wii", Price = 6000 });
            products.Add(new Product() { Id = 3, Name = "Xbox", Price = 10600 });
            products.Add(new Product() { Id = 4, Name = "PSP", Price = 5000 });
            products.Add(new Product() { Id = 5, Name = "NDS", Price = 4600 });
            products.Add(new Product() { Id = 6, Name = "iPhone", Price = 19000 });

            return View(products);
        }

        public ActionResult Crypto()
        {
            return View();
        }

        public ActionResult WebImageView()
        {
            return View();
        }

        //此action為示範寫法，並無實際View可操作
        [HttpPost]
        public ActionResult WebImageView(FormCollection formCollection)
        {
            //從post的資料中取得HttpPostedFileBase再轉為WebImage
            var image = WebImage.GetImageFromRequest("file");
            return View();
        }

        public ActionResult GetImage(ImageAction imageaction)
        {
            WebImage image = new WebImage(Server.MapPath("~/images/twmvclogo.png"));


            switch (imageaction)
            {
                case ImageAction.Resize:
                    image = image.Resize(100, 100);
                    break;
                case ImageAction.Flip:
                    image = image.FlipVertical();
                    break;
                case ImageAction.Watermark:
                    image = image.AddTextWatermark("TW MVC");
                    break;
                case ImageAction.Crop:
                    image = image.Crop(50, 50, 50, 50);
                    break;
                default:
                    throw new ArgumentException("尚未實作");
            }

            return File(image.GetBytes(), "image/png");
        }

        public ActionResult ChartView()
        {
            return View();
        }

        public ActionResult GetChart()
        {
            var chartImage = new Chart(600, 400);
            chartImage.AddTitle("TW MVC");
            chartImage.AddSeries(
                    name: "Member",
                    axisLabel: "Name",
                    xValue: new[] { "Demo", "Kevin", "Dino", "Bibby", "Jerry", "Wade" },
                    yValues: new[] { "2", "6", "4", "5", "3", "3" });

            return File(chartImage.GetBytes(), "image/png");
        }

        public ActionResult ServerInfo()
        {
            return View();
        }

        public ActionResult WebCacheView()
        {
            var bigObject = WebCache.Get("TW MVC");
            if (bigObject == null)
            {
                bigObject = new Object();
                WebCache.Set("TW MVC", bigObject);
            }
            return View(bigObject);
        }

        public ActionResult JsonView()
        {
            //測試資料
            List<Product> products = new List<Product>();

            products.Add(new Product() { Id = 1, Name = "PS3", Price = 10000 });
            products.Add(new Product() { Id = 2, Name = "Wii", Price = 6000 });
            products.Add(new Product() { Id = 3, Name = "Xbox", Price = 10600 });
            products.Add(new Product() { Id = 4, Name = "PSP", Price = 5000 });
            products.Add(new Product() { Id = 5, Name = "NDS", Price = 4600 });
            products.Add(new Product() { Id = 6, Name = "iPhone", Price = 19000 });

            return View(products);

            //若只是要提供Json資料，可用
            //return Json(products, JsonRequestBehavior.AllowGet);
        }
    }
}
