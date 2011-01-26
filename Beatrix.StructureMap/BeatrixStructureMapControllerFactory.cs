using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Beatrix.Controllers;
using StructureMap;
using Beatrix.Data;
using System.Web.Mvc;
using System.Web.Routing;
using Beatrix.Pages;
using StructureMap.Pipeline;

namespace Beatrix.StructureMap
{
    public class BeatrixStructureMapControllerFactory : BeatrixControllerFactory
    {
        public BeatrixStructureMapControllerFactory(IContainer container)
            : base(container.GetInstance<IPageRepository>(), container.GetInstance<IPathResolver>())
        {
            Container = container;
        }

        public IContainer Container { get; private set; }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType, BeatrixPage page)
        {
            return Container.With(page.GetType(), page).GetInstance(controllerType) as IController;
        }
    }
}
