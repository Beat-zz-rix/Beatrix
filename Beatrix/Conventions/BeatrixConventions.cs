using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Beatrix.Pages;

namespace Beatrix.Conventions
{
    public class BeatrixConventions
    {
        static readonly BeatrixConventions instance = new BeatrixConventions();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static BeatrixConventions()
        {
        }

        BeatrixConventions()
        {
            GetControllerNameFromPage = GetDefaultControllerNameFromPage;
            GetRouteFromControllerName = GetDefaultRouteFromControllerName;
            GetRouteFromControllerType = GetDefaultRouteFromControllerType;
            PageKey = "BeatrixPage";
        }

        public static BeatrixConventions Instance
        {
            get
            {
                return instance;
            }
        }

        public string PageKey { get; set; }

        public Func<BeatrixPage, string> GetControllerNameFromPage { get; set; }

        public string GetDefaultControllerNameFromPage(BeatrixPage page)
        {
            var name = page.GetType().Name;
            return string.Concat(name.Substring(0, name.LastIndexOf("Page")), "Controller");
        }


        public Func<Type, string> GetRouteFromControllerType { get; set; }

        public string GetDefaultRouteFromControllerType(Type controllerType)
        {
            return GetDefaultRouteFromControllerName(controllerType.Name);
        }


        public Func<string, string> GetRouteFromControllerName { get; set; }

        public string GetDefaultRouteFromControllerName(string controllerName)
        {
            return controllerName.Substring(0, controllerName.LastIndexOf("Controller"));
        }
    }
}
