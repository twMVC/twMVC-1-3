using System.Web.Mvc;

namespace ViewDemo.Areas.Hello
{
    public class HelloAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Hello";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Hello_default",
                "Hello/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
