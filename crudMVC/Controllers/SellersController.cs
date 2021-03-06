using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using crudMVC.Services;

using crudMVC.Models.ViewModels;

using crudMVC.Controllers;
using crudMVC.Models;
using crudMVC.Services.Exceptions;
using System.Diagnostics;

namespace crudMVC.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;

        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;

            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            var list = _sellerService.FindAll();

            return View(list);
        }

        public IActionResult Create()
        {
            var departments = _departmentService.FindAll();

            var viewModel = new SellerFormViemModel { Departments = departments };

            return View(viewModel);

        }

        [HttpPost]

        [ValidateAntiForgeryToken]

        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID não fornecido" });
            }

            var obj = _sellerService.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID não encontrado" });
            }

            return View(obj);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sellerService.Remove(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {

            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID não encontrado" }); 
            }

            var obj = _sellerService.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID não encontrado" }); 
            }

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID não Provided" });
            }

            var obj = _sellerService.FindById(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID não encontrado" }); 
            }

            List<Department> departments = _departmentService.FindAll();

            SellerFormViemModel viemModel = new SellerFormViemModel { Seller = obj, Departments = departments };

            return View(viemModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Seller seller)
        {
            if (id != seller.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não corresponde" });
            }
            try
            {
                _sellerService.Update(seller);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });

            }

            catch (DbConcurrencyException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public IActionResult Error(string message)
        { 
        var viewModel = new ErrorViewModel
        {
            Message = message,
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier

        };            
        return View(viewModel);

    }
    }
}