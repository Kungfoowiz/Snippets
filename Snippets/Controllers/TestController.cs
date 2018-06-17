using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Snippets.Models;

namespace Snippets.Controllers
{
    public class TestController : Controller
    {

        // GET: Test/TestString
        public string TestString()
        {
            return "This is a string test...";
        }

        // GET: Test/TestContentResult
        public ActionResult TestContentResult()
        {
            var result = new ContentResult();

            result.Content = "This is a content result test...";

            return result;
        }

        // GET: Test/TestParameters?Id=3&Name=Edward
        public ActionResult TestParameters(int Id, string Name)
        {
            var result = new ContentResult();

            result.Content = String.Format("Your parameters are Id = [{0}] and Name = [{1}]...", Id, Name);

            return result;
        }

        // GET: Test/TestView
        public ActionResult TestView()
        {
            return View();
        }


        // Todo: ViewResult example.

        // GET: Test/TestList
        public ActionResult TestList()
        {
            var result = new List<string>()
            {
                "Edward",
                "Cardiff",
                "UK"
            };

            ViewBag.Details = result;

            return View();
        }

        // GET: Test/TestModel
        public ActionResult TestModel()
        {
            var testModel = new TestModel()
            {
                Id = 007,
                Name = "Edward",
                Location = "Cardiff"
            };

            return View(testModel);
        }

    }
}