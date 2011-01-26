using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beatrix.Pages
{
    public interface IPublishable
    {
        bool IsPublished { get; set; }
    }
}
