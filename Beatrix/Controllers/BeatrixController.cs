using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Beatrix.Pages;

namespace Beatrix.Controllers
{
    public abstract class BeatrixController<T> : BeatrixController
        where T : BeatrixPage, new()
    {
        public BeatrixController(T page) : base()
        {
            Page = page;
        }

        public T Page { get; private set; }
    }

    public abstract class BeatrixController : Controller
    {
    }
}
