using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Beatrix.Pages;

namespace Beatrix
{
    public interface IPathResolver
    {
        string ResolvePath(BeatrixPage page, string rawUrl);
    }
}
