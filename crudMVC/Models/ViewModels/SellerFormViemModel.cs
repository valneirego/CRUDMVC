using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crudMVC.Models.ViewModels
{
    public class SellerFormViemModel
    {

        public Seller Seller { get; set; }
        public ICollection <Department> Departments { get; set; }
    }
}
