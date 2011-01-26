using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Beatrix.Data;
using System.Web.Routing;
using Beatrix.Pages;
using System.Web;
using Beatrix.Conventions;

namespace Beatrix.Controllers
{
    public class BeatrixControllerFactory : DefaultControllerFactory, Beatrix.Controllers.IBeatrixControllerFactory
    {
        private IEnumerable<Type> beatrixControllerTypes;
        private IPageRepository pageRepository;
        private IPathResolver pathResolver;

        public BeatrixControllerFactory(IPageRepository pageRepository, IPathResolver pathResolver) : base()
        {
            this.pageRepository = pageRepository;
            this.pathResolver = pathResolver;
            this.beatrixControllerTypes = ReflectBeatrixControllers();
        }

        public virtual string GetControllerPath(RequestContext requestContext)
        {
            var rawUrl = requestContext.HttpContext.Request.RawUrl;
            var page = pageRepository.GetPage(rawUrl);
            
            if (page == null)
                return null;

            requestContext.HttpContext.Items[BeatrixConventions.Instance.PageKey] = page;

            return pathResolver.ResolvePath(page, rawUrl);
        }

        protected virtual IEnumerable<Type> ReflectBeatrixControllers()
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
                foreach (var type in assembly.GetTypes().Where(t => typeof(BeatrixController).IsAssignableFrom(t)))
                    yield return type;
        }

        protected override Type GetControllerType(RequestContext requestContext, string controllerName)
        {
            return
                beatrixControllerTypes.SingleOrDefault(t => t.Name == string.Concat(controllerName, "Controller"))
                ?? base.GetControllerType(requestContext, controllerName);
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (!typeof(BeatrixController).IsAssignableFrom(controllerType))
                return base.GetControllerInstance(requestContext, controllerType);

            var page = requestContext.HttpContext.Items[BeatrixConventions.Instance.PageKey] as BeatrixPage;

            return GetControllerInstance(requestContext, controllerType, page);
        }

        protected virtual IController GetControllerInstance(RequestContext requestContext, Type controllerType, BeatrixPage page)
        {
            var constructor = controllerType.GetConstructor(new Type[] { page.GetType() });
            return constructor.Invoke(new [] { page }) as IController;
        }
    }
}
