using Snippets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Snippets.Controllers
{
    public class TestWebApiController : ApiController
    {
        private static List<string> data = new List<string>() { "Edward", "Johara", "Test", "Test2" };

        // GET: api/TestWebApi
        // public IEnumerable<string> Get()
        // public IEnumerable<TestModel> Get()
        // public List<string> Get()
        [HttpGet] // Can use custom method name then.
        // public HttpResponseMessage Get()
        public HttpResponseMessage Get(string search = "")
        {
            // return new string[] { "value1", "value2" };


            //var db = new TestModelContext();

            //var models = db.TestModels.ToList();

            //return models;


            // return data;


            HttpResponseMessage result;

            var db = new TestModelContext();

            var models = search == "" || search == null ?
                db.TestModels.ToList() : db.TestModels.Where(x => x.Name.StartsWith(search)).ToList();

            if (models != null)
            {
                result = Request.CreateResponse(HttpStatusCode.OK, models);
            }
            else
            {
                result = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No TestModels were found.");
            }

            return result;
        }

        // GET: api/TestWebApi/4
        // public string Get(int id)
        // public TestModel Get(int id)
        // public string Get(int id)
        [HttpGet] // Can use custom method name then.
        public HttpResponseMessage Get(int id)
        {
            // return "value";


            //var db = new TestModelContext();

            //var model = db.TestModels.Where(x => x.Id == id).FirstOrDefault();

            //return model;


            // return data[id];


            HttpResponseMessage result;

            var db = new TestModelContext();

            var model = db.TestModels.Where(x => x.Id == id).FirstOrDefault();

            if( model != null)
            {
                result = Request.CreateResponse(HttpStatusCode.OK, model);
            }
            else
            {
                result = Request.CreateErrorResponse(HttpStatusCode.NotFound, "TestModel id = [" + id.ToString() + "] was not found.");
            }

            return result;
        }

        // POST: api/TestWebApi
        // public void Post([FromBody]string value)
        // public void Post([FromBody] TestModel testModel)
        [HttpPost] // Can use custom method name then.
        public HttpResponseMessage Post([FromBody] TestModel testModel)
        {
            // data.Add(value);


            HttpResponseMessage result;

            try
            {
                var db = new TestModelContext();

                db.TestModels.Add(testModel);
                db.SaveChanges();

                result = Request.CreateResponse(HttpStatusCode.Created, testModel);
                result.Headers.Location = new Uri(Request.RequestUri + "/" + testModel.Id.ToString());
            }
            catch(Exception exception)
            {
                result = Request.CreateErrorResponse(HttpStatusCode.BadRequest, exception);
            }

            return result;
        }

        // PUT: api/TestWebApi/4
        // public void Put(int id, [FromBody]string value)
        // public void Put(int id, [FromBody] TestModel testModel)
        [HttpPut] // Can use custom method name then.
        public HttpResponseMessage Put(int id, [FromBody] TestModel testModel)
        {
            // data[id] = value;


            //var db = new TestModelContext();

            //var oldTestModel = db.TestModels.Where(x => x.Id == id).FirstOrDefault();

            //oldTestModel.Name = testModel.Name;
            //oldTestModel.Location = testModel.Location;

            //db.SaveChanges();


            HttpResponseMessage result;

            var db = new TestModelContext();

            var updateTestModel = db.TestModels.Where(x => x.Id == id).FirstOrDefault();

            if (updateTestModel != null)
            {
                updateTestModel.Name = testModel.Name;
                updateTestModel.Location = testModel.Location;

                db.SaveChanges();

                result = Request.CreateResponse(HttpStatusCode.OK, updateTestModel);
                result.Headers.Location = new Uri(Request.RequestUri.ToString());
            }
            else
            {
                result = Request.CreateErrorResponse(HttpStatusCode.NotFound, "TestModel id = [" + id.ToString() + "] was not found.");
            }

            return result;
        }

        // DELETE: api/TestWebApi/4
        // public void Delete(int id)
        [HttpDelete] // Can use custom method name then.
        public HttpResponseMessage Delete(int id)
        {
            // data.RemoveAt(id);


            //var db = new TestModelContext();

            //var oldTestModel = db.TestModels.Where(x => x.Id == id).FirstOrDefault();

            //db.TestModels.Remove(oldTestModel);
            //db.SaveChanges();


            HttpResponseMessage result;

            try
            {
                var db = new TestModelContext();

                var oldTestModel = db.TestModels.Where(x => x.Id == id).FirstOrDefault();

                if (oldTestModel != null)
                {
                    db.TestModels.Remove(oldTestModel);
                    db.SaveChanges();

                    result = Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    result = Request.CreateErrorResponse(HttpStatusCode.NotFound, "TestModel id = [" + id.ToString() + "] was not found.");
                }
            }
            catch(Exception exception)
            {
                result = Request.CreateErrorResponse(HttpStatusCode.BadRequest, exception);
            }

            return result;
        }

        // PATCH: api/TestWebApi/4
        [HttpPatch] // Can use custom method name then.
        public void Patch(int id)
        {
        }
    }
}
