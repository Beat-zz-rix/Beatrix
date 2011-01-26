using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beatrix.Pages
{
    public interface IDateControlled
    {
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
    }
}
