using crudMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crudMVC.Services
{
    public class DepartmentService
    {
        private readonly crudMVCContext _context;

        public DepartmentService(crudMVCContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }

    }
}
