
using Snippets.Snippets.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Snippets.Snippets
{
    public class Example : ApiController
    {

        // GET api/Example/3
        public string Get(int id)
        {
            return "value";
        }

        // POST api/Example
        public void Post([FromBody]string value)
        {
            // Create model with value parameter.
        }

        // PUT api/Example/3
        public void Put(int id, [FromBody] string value)
        {
            // Update model with value parameter.
        }

        // DELETE api/Example/3
        public void Delete(int id)
        {
            // Delete object where id is equal to parameter id.
        }


        private List<Box> boxes = new List<Box>()
        {
            new Box { Id = Guid.NewGuid(), Name = "Blah", Width = 5, Height = 10 },
            new Box { Id = Guid.NewGuid(), Name = "Some Box", Width = 15, Height = 50 },
            new Box { Id = Guid.NewGuid(), Name = "Another Box", Width = 600, Height = 77 }
        };

        public IEnumerable<Box> GetAllBoxes()
        {
            return boxes;
        }

        public IHttpActionResult GetABox(Guid id)
        {
            IHttpActionResult result;

            var box = boxes.FirstOrDefault((x) => x.Id == id);

            if (box == null)
            {
                result = NotFound();
            }
            else
            {
                result = Ok(box);
            }

            return result;
        }

    }
}
