using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Beatrix.StructureMap;
using Beatrix.Demo.SM;
using Beatrix.Data;
using Beatrix.Demo.PageTypes;

namespace Beatrix.Demo
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            var pageRepository = IoC.Initialize().GetInstance<IPageRepository>();

            pageRepository.Insert(new InfoPage { Id = 1, IsPublished = true, Url = "/", Title = "Beatrix Demo", Headline = "Welcome to the Beatrix Demo", Text = "This is an InfoPage" });
            pageRepository.Insert(new InfoPage { Id = 2, IsPublished = true, Url = "/about", Title = "Beatrix Demo - About", Headline = "About Beatrix CMS", Text = "This is also an InfoPage" });
        }
    }
}