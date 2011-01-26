using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raven.Client.Indexes;
using Raven.Database.Indexing;
using Beatrix.Pages;

namespace Beatrix.Data.Indexes
{
    public class Pages_ByUrl : AbstractIndexCreationTask
    {
        public override IndexDefinition CreateIndexDefinition()
        {
            return new IndexDefinition<BeatrixPage>
            {
                Map = pages => from page in pages
                               select new { Url = page.Url }
            }.ToIndexDefinition(DocumentStore.Conventions);
        }
    }
}
