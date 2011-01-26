using System;
using System.Web.Mvc;
using Beatrix.Data;
using System.Web;
using System.Web.Routing;
namespace Beatrix.Controllers
{
    public interface IBeatrixControllerFactory : IControllerFactory
    {
        string GetControllerPath(RequestContext requestContext);
    }
}
