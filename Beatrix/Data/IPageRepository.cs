using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Beatrix.Pages;

namespace Beatrix.Data
{
    public interface IPageRepository : IRepository<BeatrixPage, int>
    {
        BeatrixPage GetPage(string url);

        IEnumerable<Url> Urls { get; }
    }
}
