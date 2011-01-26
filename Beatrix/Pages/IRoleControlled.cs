using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beatrix.Pages
{
    public interface IRoleControlled
    {
        IEnumerable<string> RolesCanCreate { get; set; }
        IEnumerable<string> RolesCanRead { get; set; }
        IEnumerable<string> RolesCanUpdate { get; set; }
        IEnumerable<string> RolesCanDelete { get; set; }
        IEnumerable<string> RolesCanPublish { get; set; }
    }
}
