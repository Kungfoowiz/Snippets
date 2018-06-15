using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Snippets.Snippets.Models
{
    public class Box
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset Created { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }
    }

    public class BoxDBContext : DbContext
    {
        public BoxDBContext()
        {

        }

        public DbSet<Box> Boxes { get; set; }
    }

}