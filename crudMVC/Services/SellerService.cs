using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crudMVC.Models;

namespace crudMVC.Services
{
    public class SellerService
    {
        private readonly crudMVCContext _context;

        public SellerService(crudMVCContext context)
        {
            _context = context;
        }


        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }


        public void Insert(Seller obj)
        {
            obj.Department = _context.Department.First();
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
