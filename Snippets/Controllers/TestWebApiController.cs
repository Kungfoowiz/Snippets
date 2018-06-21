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
        public List<string> Get()
        {
            // return new string[] { "value1", "value2" };


            //var db = new TestModelContext();

            //var models = db.TestModels.ToList();

            //return models;


            return data;
        }

        // GET: api/TestWebApi/4
        // public string Get(int id)
        // public TestModel Get(int id)
        public string Get(int id)
        {
            // return "value";


            //var db = new TestModelContext();

            //var model = db.TestModels.Where(x => x.Id == id).FirstOrDefault();

            //return model;


            return data[id];
        }

        // POST: api/TestWebApi
        public void Post([FromBody]string value)
        {
            data.Add(value);
        }

        // PUT: api/TestWebApi/4
        public void Put(int id, [FromBody]string value)
        {
            data[id] = value;
        }

        // DELETE: api/TestWebApi/4
        public void Delete(int id)
        {
            data.RemoveAt(id);
        }

        // PATCH: api/TestWebApi/4
        public void Patch(int id)
        {
        }
    }
}
