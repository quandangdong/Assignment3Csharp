using BusinessObject.Models;
using DataAccess.IRepository;
using DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace eStore.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepo productRepo = null;

        public ProductController() => productRepo = new ProductRepository();

        // GET: ProductController
        public ActionResult Index()
        {
           
            var userRole = HttpContext.Session.GetString("UserRole");
            if (userRole != null)
            {
                var productList = productRepo.GetAllProducts();
                return View(productList);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        public bool checkRole()
        {
            var userRole = HttpContext.Session.GetString("UserRole");
            if (userRole == null)
            {
                RedirectToAction("Index", "Home");
                return false;
            }
            else
            {
                if (userRole == "admin")
                {
                    return true;
                }
                else return false;
            }
        }


        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            if (id < 0)
            {
                return NotFound();
            }
            var product = productRepo.GetProductByProductId(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    productRepo.AddNewProduct(product);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(product);
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id < 0)
            {
                return NotFound();
            }
            var product = productRepo.GetProductByProductId(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product product)
        {
            try
            {
                if (id != product.ProductId)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    productRepo.UpdateProduct(product);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id < 0)
            {
                return NotFound();
            }
            var product = productRepo.GetProductByProductId(id);
            if (product == null)
            {
                return NotFound();
            }
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Product product)
        {
            try
            {
                productRepo.DeleteProduct(product);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }
    }
}
