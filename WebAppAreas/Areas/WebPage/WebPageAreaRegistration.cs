using System.Web.Mvc;

namespace WebAppAreas.Areas.WebPage
{
    public class WebPageAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "WebPage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "WebPage_default",
                "WebPage/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}