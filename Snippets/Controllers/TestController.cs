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
        [HttpGet]
        public string TestString()
        {
            return "This is a string test...";
        }

        // GET: Test/TestContentResult
        [HttpGet]
        public ActionResult TestContentResult()
        {
            var result = new ContentResult();

            result.Content = "This is a content result test...";

            return result;
        }

        // GET: Test/TestParameters?Id=3&Name=Edward
        [HttpGet]
        public ActionResult TestParameters(int Id, string Name)
        {
            var result = new ContentResult();

            result.Content = String.Format("Your parameters are Id = [{0}] and Name = [{1}]...", Id, Name);

            return result;
        }

        // GET: Test/TestView
        [HttpGet]
        public ActionResult TestView()
        {
            return View();
        }

        // GET: Test/TestViewResult
        [HttpGet]
        public ViewResult TestViewResult()
        {
            var result = new List<string>()
            {
                "Edward",
                "Cardiff",
                "UK",
                "Web Developer"
            };

            ViewBag.Details = result;

            return View();
        }

        // GET: Test/TestList
        [HttpGet]
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
        [HttpGet]
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

        // GET: Test/TestModelEntity
        [HttpGet]
        public ActionResult TestModelEntity(int Id)
        {
            var db = new TestModelContext();

            var model = db.TestModels.FirstOrDefault(x => x.Id == Id);

            return View(model);
        }

        // GET: Test/TestModelEntityGetAll
        [HttpGet]
        public ActionResult TestModelEntityGetAll()
        {
            var db = new TestModelContext();

            var model = db.TestModels.ToList();

            return View(model);
        }

        // GET: Test/TestModelEntityGetAll2
        [HttpGet]
        public ActionResult TestModelEntityGetAll2()
        {
            var db = new TestModelContext();

            var model = db.TestModels.ToList();

            return View(model);
        }

        // GET: Test/CreateNewTestModelEntity
        [HttpGet]
        public ActionResult CreateNewTestModelEntity()
        {
            return View();
        }

        // POST: Test/CreateNewTestModelEntity
        [HttpPost]
        public ActionResult CreateNewTestModelEntity(FormCollection formCollection)
        //public ActionResult CreateNewTestModelEntity(string Name, string Location)
        {
            //foreach(string key in formCollection.AllKeys)
            //{
            //    Response.Write("Key [" + key + "]");
            //    Response.Write(formCollection[key]);
            //    Response.Write("<br />");
            //}
            //return View();

            var newTestModel = new TestModel();

            // newTestModel.Name = formCollection["Name"];
            // newTestModel.Location = formCollection["Location"];

            // newTestModel.Name = Name;
            // newTestModel.Location = Location;

            TryUpdateModel(newTestModel, formCollection);

            var db = new TestModelContext();

            db.TestModels.Add(newTestModel);
            db.SaveChanges();

            return RedirectToAction("TestModelEntityGetAll2");
        }

        // GET: Test/EditTestModelEntity
        [HttpGet]
        public ActionResult EditTestModelEntity(int Id)
        {
            var db = new TestModelContext();

            var model = db.TestModels.FirstOrDefault(x => x.Id == Id);

            return View(model);
        }

        // POST: Test/EditTestModelEntity
        [HttpPost]
        public ActionResult EditTestModelEntity(int Id, FormCollection formCollection)
        {
            var db = new TestModelContext();

            var model = db.TestModels.FirstOrDefault(x => x.Id == Id);

            TryUpdateModel(model, formCollection);
            db.SaveChanges();

            return RedirectToAction("TestModelEntityGetAll2");
        }

        // GET: Test/DeleteTestModelEntity
        [HttpGet]
        public ActionResult DeleteTestModelEntity(int Id)
        {
            var db = new TestModelContext();

            var model = db.TestModels.FirstOrDefault(x => x.Id == Id);

            return View(model);
        }

        // POST: Test/DeleteTestModelEntity
        [HttpPost]
        public ActionResult DeleteTestModelEntity(int Id, FormCollection formCollection)
        {
            var db = new TestModelContext();

            var model = db.TestModels.FirstOrDefault(x => x.Id == Id);

            db.TestModels.Remove(model);
            db.SaveChanges();

            return RedirectToAction("TestModelEntityGetAll2");
        }

        // GET: Test/DetailsTestModelEntity
        [HttpGet]
        public ActionResult DetailsTestModelEntity(int Id)
        {
            var db = new TestModelContext();

            var model = db.TestModels.FirstOrDefault(x => x.Id == Id);

            return View(model);
        }

    }
}