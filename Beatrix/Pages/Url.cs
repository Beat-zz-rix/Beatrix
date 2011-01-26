using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beatrix.Pages
{
    public class Url
    {
        public Url(string url=null)
        {
            UrlString = url;
        }

        public static implicit operator Url(string url)
        {
            return new Url(url);
        }

        public static implicit operator string(Url url)
        {
            return url.UrlString;
        }

        private string urlString { get; set; }

        public string UrlString
        {
            get { return urlString; }
            set
            {
                urlString = value;
                rebuildSegments();
            }
        }

        private void rebuildSegments()
        {
            Segments = (urlString != null)
                ? urlString.Split('/').Where(s => !string.IsNullOrWhiteSpace(s))
                : new string[0];
            SegmentCount = Segments.Count();
        }
        public IEnumerable<string> Segments { get; private set; }
        public int SegmentCount { get; private set; }
    }
}
