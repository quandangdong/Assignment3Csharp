using BusinessObject.Models;
using DataAccess.IRepository;
using DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace eStore.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepo orderRepo = null;
        private IMemberRepo memberRepo = new MemberRepository();
        public OrderController() => orderRepo = new OrderRepository();
        // GET: OrderController
        public ActionResult Index()
        {
            var userRole = HttpContext.Session.GetString("UserRole");
            if (userRole != null)
            {
                var orderList = orderRepo.GetAllOrder();
                return View(orderList);
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

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            bool isAdmin = checkRole();
            if (isAdmin == true)
            {
                if (id < 0)
                {
                    return NotFound();
                }
                var order = orderRepo.GetOrderByOrderId(id);
                if (order == null)
                {
                    return NotFound();
                }
                return View(order);
            }
            else return RedirectToAction("Index", "Order");
        }



        // GET: OrderController/Create
        public ActionResult Create()
        {
            bool isAdmin = checkRole();
            if (isAdmin == true)
            {

                List<Member> memberList = memberRepo.GetAllMembers();
                ViewBag.MemberList = memberList;
                return View();
            }
            else return RedirectToAction("Index", "Order");
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order order)
        {
            bool isAdmin = checkRole();
            if (isAdmin == true)
            {

                try
                {
                    if (ModelState.IsValid)
                    {
                        orderRepo.AddNewOrder(order);
                    }
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ViewBag.Message = ex.Message;
                    return View();
                }
            }
            else return RedirectToAction("Index", "Order");
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            bool isAdmin = checkRole();
            if (isAdmin == true)
            {
                if (id < 0)
                {
                    return NotFound();
                }
                var order = orderRepo.GetOrderByOrderId(id);
                if (order == null)
                {
                    return NotFound();
                }
                return View(order);
            }
            else return RedirectToAction("Index", "Order");
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Order order)
        {
            try
            {
                if (id != order.OrderId)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    orderRepo.UpdateOrder(order);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }

        }

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            bool isAdmin = checkRole();
            if (isAdmin == true)
            {
                if (id < 0)
                {
                    return NotFound();
                }
                var order = orderRepo.GetOrderByOrderId(id);
                if (order == null)
                {
                    return NotFound();
                }
                return View(order);
            }
            else return RedirectToAction("Index", "Order");
        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Order order)
        {
            try
            {
                orderRepo.DeleteOrder(order);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
