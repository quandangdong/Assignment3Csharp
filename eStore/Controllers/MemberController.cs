using BusinessObject.Models;
using DataAccess.IRepository;
using DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace eStore.Controllers
{
    public class MemberController : Controller
    {
        private IMemberRepo memberRepo = null;

        public MemberController() => memberRepo = new MemberRepository();

        // GET: MemberController
        public ActionResult Index()
        {
            var userRole = HttpContext.Session.GetString("UserRole"); 
            if(userRole != null)
            {
                var memberList = memberRepo.GetAllMembers();
                return View(memberList);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
            
        }

        // GET: MemberController/Details/5
        public ActionResult Details(int id)
        {
            if(id < 0)
            {
                return NotFound();
            }
            var member = memberRepo.GetMemberByMemberId(id);
            if(member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        public bool checkRole()
        {
            var userRole = HttpContext.Session.GetString("UserRole");
            if(userRole == null)
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

        // GET: MemberController/Create
        public ActionResult Create()
        {
            bool isAdmin = checkRole();
            if (isAdmin == true)
            {
                return View();
            }
            else {
                return RedirectToAction("Index", "Member");
            } 
            
        }

        // POST: MemberController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Member member)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    memberRepo.AddNewMember(member);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(member);
            }
        }

        // GET: MemberController/Edit/5
        public ActionResult Edit(int id)
        {
            bool isAdmin = checkRole();
            if (isAdmin == true)
            {
                if (id < 0)
                {
                    return NotFound();
                }
                var member = memberRepo.GetMemberByMemberId(id);
                if (member == null)
                {
                    return NotFound();
                }
                return View(member);
            }
            else return RedirectToAction("Index", "Member");
            
        }

        // POST: MemberController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Member member)
        {
            try
            {
                if(id != member.MemberId)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    memberRepo.UpdateMember(member);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }

        // GET: MemberController/Delete/5
        public ActionResult Delete(int id)
        {
            bool isAdmin = checkRole();
            if (isAdmin == true)
            {
                if (id < 0)
                {
                    return NotFound();
                }
                var member = memberRepo.GetMemberByMemberId(id);
                if (member == null)
                {
                    return NotFound();
                }
                return View(member);
            }
            else return RedirectToAction("Index", "Member");
        }

        // POST: MemberController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Member member)
        {
            try
            {
                memberRepo.DeleteMember(member);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }
    }
}
