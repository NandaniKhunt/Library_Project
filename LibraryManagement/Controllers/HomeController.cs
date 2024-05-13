using LibraryManagement.Logic.Implementation;
using LibraryManagement.Logic.Interface;
using LibraryManagement.Models.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagement.Models;
using LibraryManagement.Models.Database;

namespace LibraryManagement.Controllers
{
    public class HomeController : Controller
    {
        IUserServices userServices = new UserServices();

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
            public ActionResult Login(LoginModel model)
            {
                var user = userServices.Authentication(model.UserName, model.Password);
                if (user != null)
                {
                    ProjectSession.User = user;
                    if (user.Role.RoleName == "admin")
                    {
                    return View("~/Areas/Admin/Views/AdminDashboard/Index.cshtml");
                   
                    }
                    else if (user.Role.RoleName == "student")
                    {
                        return RedirectToAction("Index", "StudentDashboard");
                    }
                }
                ViewBag.ErrorMessage = "Incorrect username or password.";
                return View("Index");
            }
        public ActionResult Result()
        {
            return View();
        }
        public ActionResult Logout()
        {
            ProjectSession.User = null;
            return RedirectToAction("Index");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}