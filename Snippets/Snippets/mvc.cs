
using Snippets.Snippets.Models;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Web;
using System.Web.Mvc;

namespace Kungfoowiz
{
    // Update RouteConfig.cs
    //routes.MapRoute(
    //    name: "ExampleRoute",
    //    url: "{controller}/{action}/{id}",
    //    defaults: new { controller = "Example", action = "Index", id = UrlParameter.Optional }
    //);

    public class ExampleController : Controller
    {

        [HttpGet]
        public string Index()
        {
            return "Index test";
        }

        [HttpGet]
        public ActionResult ExampleAction(string testParameter)
        {
            var result = Server.HtmlEncode(testParameter);

            var contentResult = new ContentResult();
            contentResult.Content = result;

            // return Content(result);
            return contentResult;
        }

        [HttpGet]
        public string ActionReturnHtml()
        {
            return @"<ul>
                <li>Joe</li>
                <li>Jack</li>
                <li>Jill</li>
                <li>Whatever</li>
                </ul>";
        }

        [HttpGet]
        public ActionResult ExampleRedirectToAction()
        {
            return RedirectToAction("ExampleAction", "Example", new { testParameter = "testParamValue" } );
        }

        [HttpGet]
        public ActionResult ExampleView()
        {
            return View();
        }


        // CRUD examples.

        [HttpGet]
        public ActionResult Index2()
        {
            return View();
        }

        // GET: Example/Details/3
        [HttpGet]
        public ActionResult Details(int id)
        {
            // Logic to get object by id here.

            var model = new Object();

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            // Return form view for creating new object.
            return View();
        }

        // POST: Example/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // Logic to create new object.

                var createdId = 0;

                return RedirectToAction("Details", "Example", new { id = createdId });
            }
            catch
            {
                return View();
            }
        }

        // GET: Example/Edit/3
        [HttpGet]
        public ActionResult Edit(int id)
        {
            // Logic to get existing object and pass to the Edit view.

            var model = new Object();

            return View(model);
        }

        // POST: Example/Edit/3
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // Logic to update existing object.

                // return RedirectToAction("Index", "Example");
                return RedirectToAction("Details", "Example", new { id });
            }
            catch
            {
                return RedirectToAction("Edit", "Example", new { id });
            }
        }

        // GET: Example/Delete/3
        public ActionResult Delete(int id)
        {
            // Logic to get existing object and pass to Delete view.

            var model = new Object();

            return View(model);
        }

        // POST: Example/Delete/3
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // Logic to delete existing object.

                return RedirectToAction("Index", "Example");
            }
            catch
            {
                return RedirectToAction("Delete", "Example", new { id });
            }
        }


        // Data Models.

        [NonAction]
        public List<Box> GetBoxes()
        {
            return new List<Box>(){
                new Box(){
                    Id = Guid.NewGuid(),
                    Name = "Billy Box",
                    Created = new DateTimeOffset().DateTime,
                    Width = 100,
                    Height = 200
                },
                new Box(){
                    Id = Guid.NewGuid(),
                    Name = "Silly Box",
                    Created = new DateTimeOffset().DateTime,
                    Width = 300,
                    Height = 700
                },
                new Box(){
                    Id = Guid.NewGuid(),
                    Name = "Happy Box",
                    Created = new DateTimeOffset().DateTime,
                    Width = 500,
                    Height = 500
                },
                new Box(){
                    Id = Guid.NewGuid(),
                    Name = "Sad Box",
                    Created = new DateTimeOffset().DateTime,
                    Width = 1,
                    Height = 99
                }
            };
        }


        [HttpGet]
        public ActionResult IndexHappyBoxes()
        {
            // var box = GetBoxes().Select(x => x.Name.ToLowerInvariant() == "happy box").FirstOrDefault();
            var boxes = GetBoxes().Select(x => x.Name.ToLowerInvariant() == "happy box");

            return View(boxes);
        }


        // GET: Example/CreateBox
        [HttpGet]
        [ActionName("CreateBox")]
        public ActionResult CreateBoxForm()
        {
            return View();
        }

        // POST: Example/CreateBox
        [HttpPost]
        public ActionResult CreateBox(FormCollection collection)
        {
            try
            {
                var newBox = new Box();
                TryUpdateModel(newBox, collection);

                // var collectionValues = collection.Cast<FormCollection>().ToList();

                newBox.Name = collection["Name"];

                DateTimeOffset dateResult;
                DateTimeOffset.TryParse(collection["Created"], out dateResult);
                newBox.Created = dateResult;

                int width;
                Int32.TryParse(collection["Width"], out width);
                newBox.Width = width;

                int height;
                Int32.TryParse(collection["Height"], out height);
                newBox.Height = height;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }




        // Entity Framework.

        private BoxDBContext db = new BoxDBContext();
        
        // GET: Example/IndexAllBoxes
        [HttpGet]
        public ActionResult IndexAllBoxes()
        {
            // LINQ SQL.
            //var boxes = from y in db.Boxes
            //            select y;

            // LINQ.
            var boxes = db.Boxes.ToList();

            return View(boxes);
        }

        [HttpGet]
        public ActionResult IndexSadBoxes()
        {
            // LINQ SQL.
            //var boxes = from y in db.Boxes
            //            where y.Name.ToLowerInvariant().Contains("sad")
            //            select y;

            // LINQ.
            var sadBoxes = db.Boxes.Where(x => x.Name.ToLowerInvariant().Contains("sad"));

            return View(sadBoxes);
        }

        // GET: Example/CreateBox
        [HttpGet]
        public ActionResult CreateBox()
        {
            return View();
        }

        // POST: Example/CreateBoxes
        [HttpPost]
        public ActionResult CreateBoxes(Box box)
        {
            try
            {
                db.Boxes.Add(box);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Example/EditBox/3
        [HttpGet]
        public ActionResult EditBox(Guid id)
        {
            // LINQ SQL.
            // var box = db.Boxes.Single(x => x.Id == id);

            // LINQ.
            var box = db.Boxes.Where(x => x.Id == id).Single();

            return View(box);
        }

        // POST: Example/EditBoxes/3
        [HttpPost]
        public ActionResult EditBoxes(Guid id, FormCollection collection)
        {
            try
            {
                var box = db.Boxes.Single(x => x.Id == id);

                if (TryUpdateModel(box))
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(box);
            }
            catch
            {
                return View();
            }
        }


    }

}