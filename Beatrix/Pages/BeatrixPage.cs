using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Beatrix.Pages;

namespace Beatrix.Pages
{
    public class BeatrixPage : IDateControlled, IRoleControlled, IPublishable
    {
        public BeatrixPage()
        {
            StartDate = DateTime.Now;
            EndDate = DateTime.MaxValue;
        }

        public int Id { get; set; }

        public string Url { get; set; }

        #region IDateControlled

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        #endregion


        #region IRoleControlled

        public IEnumerable<string> RolesCanCreate { get; set; }

        public IEnumerable<string> RolesCanRead { get; set; }

        public IEnumerable<string> RolesCanUpdate { get; set; }

        public IEnumerable<string> RolesCanDelete { get; set; }

        public IEnumerable<string> RolesCanPublish { get; set; }

        #endregion


        #region IPublishable

        public bool IsPublished { get; set; }

        #endregion
    }
}
