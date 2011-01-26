using StructureMap;
using System.Web.Mvc;
using Beatrix.StructureMap;
using Raven.Client;
using Raven.Client.Document;
using Beatrix.Data;
namespace Beatrix.Demo.SM {
    public static class IoC {
        public static IContainer Initialize() {
            ObjectFactory.Initialize(x =>
                        {
                            x.Scan(scan =>
                                    {
                                        scan.TheCallingAssembly();
                                        scan.WithDefaultConventions();
                                    });

                            x.For<IControllerFactory>().Singleton().Use<BeatrixStructureMapControllerFactory>();

                            x.For<IDocumentStore>().Singleton().Use(d =>
                            {
                                var documentStore = new DocumentStore() { Url = "http://localhost:8080" };
                                return documentStore;
                            });

                            x.For<IPageRepository>().Singleton().Use<RavenPageRepository>();

                            x.For<IPathResolver>().Use<BeatrixPagePathResolver>();
                        });
            return ObjectFactory.Container;
        }
    }
}