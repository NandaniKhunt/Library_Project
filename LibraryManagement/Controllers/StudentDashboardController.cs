using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryManagement.Logic.Implementation;
using LibraryManagement.Logic.Interface;
using LibraryManagement.Models;
using LibraryManagement.Models.Custom;

namespace LibraryManagement.Controllers
{
    public class StudentDashboardController : Controller
    {
        IBorrowedBook BorrowedBookServices = new BorrowedBookServices();
     
        // GET: StudentDashboard
        public ActionResult Index()
        {
            var currentUser = ProjectSession.User;
            if (currentUser != null && currentUser.Role.RoleName == "student")
            {
                var borrowedBooks = BorrowedBookServices.GetBorrowedBooksByStudentId(currentUser.UserId);
                return View(borrowedBooks);
           }
            return RedirectToAction("Index", "StudentDashboard");
        }
    }
}
