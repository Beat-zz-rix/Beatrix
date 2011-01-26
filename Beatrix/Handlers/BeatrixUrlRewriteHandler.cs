using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Beatrix.Data;
using System.Web.Mvc;
using Beatrix.Controllers;
using Beatrix.Conventions;

namespace Beatrix.Handlers
{
    public class BeatrixUrlRewriteHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            var controllerPath = (ControllerBuilder.Current.GetControllerFactory() as IBeatrixControllerFactory)
                .GetControllerPath(new HttpRequestWrapper(context.Request).RequestContext);
            if (controllerPath != null)
                context.RewritePath(controllerPath);
        }
    }
}
