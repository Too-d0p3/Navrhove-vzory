using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Lib.DomainLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class LoginController : Controller
    {

        public IActionResult Index()
        {
            ViewBag.isLogged = false;
            string login = HttpContext.Session.GetString("Email");
            if (!string.IsNullOrEmpty(login))
            {
                ViewBag.isLogged = true;
                ViewBag.Email = login;
            }
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginForm logForm)
        {
            if (ModelState.IsValid)
            {
                if (UserAuthentication.Login(logForm.Email, logForm.Password))
                {
                    //HttpContext.Session.SetString("user", logInfo.Login);
                    HttpContext.Session.SetString("Email", logForm.Email);
                    return RedirectToAction("Index", "Home");
                    //return RedirectToAction("Index", new RouteValueDictionary( new { controller = Home, action = "Index", auth = ea }));
                }
                else
                {
                    ModelState.AddModelError("Email", logForm.Email);
                    ModelState.AddModelError("Password", logForm.Password);
                   
                }
                
            }
            return View();
        }


        public IActionResult Register(RegisterForm form)
        {
            if (ModelState.IsValid)
            {
                if (!Regex.IsMatch(form.FirstName, @"^[a-zA-Z]+$"))
                {
                    ModelState.AddModelError("FirstName", "Název může obsahovat pouze znaky");
                }
            }

            if (ModelState.IsValid)
            {
                if (!Regex.IsMatch(form.LastName, @"^[a-zA-Z]+$"))
                {
                    ModelState.AddModelError("LastName", "Název může obsahovat pouze znaky");
                }
            }

            if (ModelState.IsValid)
            {
                if (!Regex.IsMatch(form.Email, @"[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}"))
                {
                    ModelState.AddModelError("Email", "Email není platný");
                }
            }

            if (ModelState.IsValid)
            {

                if (Lib.DomainLayer.User.GetByEmail(form.Email) == null)
                {
                    Lib.DomainLayer.User user = new User()
                    {
                        FirstName = form.FirstName,
                        LastName = form.LastName,
                        Email = form.Email,
                        Password = form.Password
                    };
                    user.Insert();
                }
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}