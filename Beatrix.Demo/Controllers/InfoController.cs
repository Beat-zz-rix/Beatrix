using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Beatrix.Controllers;
using Beatrix.Demo.PageTypes;

namespace Beatrix.Demo.Controllers
{
    public class InfoController : BeatrixController<InfoPage>
    {
        public InfoController(InfoPage page) : base(page) { }

        //
        // GET: /Info/

        public ActionResult Index()
        {
            return View(Page);
        }

    }
}
