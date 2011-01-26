using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Beatrix.Pages;
using Beatrix.Conventions;
using Beatrix.Controllers;

namespace Beatrix
{
    public class BeatrixPagePathResolver : IPathResolver
    {
        public string ResolvePath(BeatrixPage page, string rawUrl)
        {
            var controllerAttribute = page
                .GetType()
                .GetCustomAttributes(true)
                .SingleOrDefault(x => typeof(ControllerAttribute).IsAssignableFrom(x.GetType())) as ControllerAttribute;

            var controllerName = (controllerAttribute != null)
                ? controllerAttribute.ControllerType.Name
                : BeatrixConventions.Instance.GetControllerNameFromPage(page);

            return string.Concat(
                "/",
                BeatrixConventions.Instance.GetRouteFromControllerName(controllerName),
                rawUrl.Substring(page.Url.Length)
                ).ToLower();
        }
    }
}
