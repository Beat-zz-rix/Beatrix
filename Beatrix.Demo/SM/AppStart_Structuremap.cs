using System.Web.Mvc;
using StructureMap;
using Beatrix.Demo.SM;

[assembly: WebActivator.PreApplicationStartMethod(typeof(AppStart_Structuremap), "Start")]

namespace Beatrix.Demo.SM {
    public static class AppStart_Structuremap {
        public static void Start() {
            var container = (IContainer) IoC.Initialize();
            DependencyResolver.SetResolver(new SmDependencyResolver(container));
        }
    }
}