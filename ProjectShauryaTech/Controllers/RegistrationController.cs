using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectShauryaTech.DAL;
using ProjectShauryaTech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectShauryaTech.Controllers
{
    public class RegistrationController : Controller
    {
        RegistrationDAL db = new RegistrationDAL();
        // GET: RegistrationController
        public ActionResult Index()
        {
            return View();
        }

        // GET: RegistrationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RegistrationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegistrationController/Create
        [HttpPost]
      
        public ActionResult Create(Registration registration)
        {
            try
            {
                int result = db.Registration(registration);
                if (result==1)
                return RedirectToAction("SignIn","Registration");
                else
                    return View();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignIn(Registration registration)
        {
            Registration user = db.LogIn(registration);

            if (user.Password == registration.Password)
            {
                HttpContext.Session.SetString("username", user.Email.ToString());
                HttpContext.Session.SetString("userid", user.Uid.ToString());
                if (user.RId == Roles.Customer)
                {


                    return RedirectToAction("Products", "Product");
                }
                else if (user.RId == Roles.Admin)
                {
                    return RedirectToAction("Index", "Product");
                }
                else
                    return View();
            }
            else
                return RedirectToAction("Create","Registration");
        }

        // GET: RegistrationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RegistrationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RegistrationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RegistrationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
