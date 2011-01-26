using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Beatrix.Pages;

namespace Beatrix.Demo.PageTypes
{
    public class InfoPage : BeatrixPage
    {
        public string Title { get; set; }
        public string Headline { get; set; }
        public string Text { get; set; }
    }
}