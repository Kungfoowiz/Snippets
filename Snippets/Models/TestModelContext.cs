using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Snippets.Models
{

    public class TestModelContext : DbContext
    {
        public DbSet<TestModel> TestModels { get; set; }
    }

}