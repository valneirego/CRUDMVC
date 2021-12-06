using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace crudMVC.Models
{
    public class crudMVCContext : DbContext
    {
        public crudMVCContext (DbContextOptions<crudMVCContext> options)
            : base(options)
        {
        }

        public DbSet<crudMVC.Models.Department> Department { get; set; }
    }
}
