using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raven.Client;
using Raven.Client.Util;
using Beatrix.Pages;

namespace Beatrix.Data
{
    public class RavenPageRepository : IPageRepository
    {
        private IDocumentStore store;

        public RavenPageRepository(IDocumentStore store)
        {
            this.store = store;
            Init();
        }

        private void Init()
        {
            store.Initialize();
            using (var session = store.OpenSession())
            {
                session.Advanced.Conventions.FindTypeTagName = t => typeof(BeatrixPage).IsAssignableFrom(t)
                    ? "pages"
                    : Inflector.Pluralize(t.Name);
                RebuildUrlCache(session);
            }
        }

        private void RebuildUrlCache(IDocumentSession session)
        {
            Urls = session
                .Query<BeatrixPage>()
                .Select(p => new Url(p.Url))
                .OrderByDescending(u => u.SegmentCount);
        }

        public BeatrixPage GetPage(string rawUrl)
        {
            using (var session = store.OpenSession())
            {
                var url = Urls
                    .FirstOrDefault(u => rawUrl.StartsWith(u.UrlString));
                if (url == null) return null;

                return session
                    .Query<BeatrixPage>()
                    .FirstOrDefault(p => p.Url == url.UrlString);
            }
        }

        public IEnumerable<Url> Urls { get; private set; }

        public BeatrixPage SingleOrDefault(Func<BeatrixPage, bool> predicate)
        {
            using (var session = store.OpenSession())
            {
                return session
                    .Query<BeatrixPage>()
                    .SingleOrDefault(predicate);
            }
        }

        public IEnumerable<BeatrixPage> GetList(Func<BeatrixPage, bool> predicate)
        {
            using (var session = store.OpenSession())
            {
                return session
                    .Query<BeatrixPage>()
                    .Where(predicate);
            }
        }

        public BeatrixPage Insert(BeatrixPage entity)
        {
            using (var session = store.OpenSession())
            {
                session.Store(entity);
                session.SaveChanges();
                RebuildUrlCache(session);

                return entity;
            }
        }

        public BeatrixPage Update(BeatrixPage entity)
        {
            return Insert(entity);
        }

        public void Delete(BeatrixPage entity)
        {
            using (var session = store.OpenSession())
            {
                session.Delete<BeatrixPage>(entity);
                RebuildUrlCache(session);
            }
        }

        public void Delete(int id)
        {
            using (var session = store.OpenSession())
            {
                var page = session.Load<BeatrixPage>(id.ToString());
                if (page != null)
                {
                    session.Delete<BeatrixPage>(page);
                    RebuildUrlCache(session);
                }
            }
        }
    }
}
