using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Beatrix.Controllers;

namespace Beatrix.Modules
{
    public class BeatrixUrlRewriteModule : IHttpModule
    {
        public void Dispose()
        {
            // don nothing in particular
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(context_BeginRequest);
        }

        void context_BeginRequest(object sender, EventArgs e)
        {
            var application = sender as HttpApplication;
            var context = application.Context;

            var controllerPath = (ControllerBuilder.Current.GetControllerFactory() as IBeatrixControllerFactory)
                .GetControllerPath(new HttpRequestWrapper(context.Request).RequestContext);

            if (controllerPath != null)
                context.RewritePath(controllerPath);
        }
    }
}
