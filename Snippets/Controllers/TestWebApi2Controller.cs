using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Snippets.Controllers
{
    public class TestWebApi2Controller : Controller
    {
        // GET: TestWebApi2
        public ActionResult Index()
        {
            return View("TestModels");
        }


        // GET: TestWebApi2/TestPartial
        public PartialViewResult TestPartial()
        {
            return PartialView();
        }
    }
}