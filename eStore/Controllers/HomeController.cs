using BusinessObject.Models;
using DataAccess.Repository;
using eStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace eStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MemberRepository memberRepo = new MemberRepository();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Member member)
        {
            try
            {
               if(member.Email.Equals("admin@fstore.com") && member.Password.Equals("admin@@"))
                {
                    HttpContext.Session.SetString("Email", member.Email);
                    HttpContext.Session.SetString("UserRole", "admin");
                } else
                {
                    var logginUser = memberRepo.CheckLogin(member.Email, member.Password);
                    if(logginUser != null)
                    {
                        HttpContext.Session.SetString("Email", logginUser.Email);
                        HttpContext.Session.SetString("UserRole", "member");
                        HttpContext.Session.SetInt32("MemberId", logginUser.MemberId);
                    }
                    else
                    {
                        ViewBag.Messgae = "Invalid email or password";
                        return View();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Home");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
