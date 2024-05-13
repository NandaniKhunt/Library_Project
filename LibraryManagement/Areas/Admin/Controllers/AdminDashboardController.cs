using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace LibraryManagement.Areas.Admin.Controllers
{
    [RoutePrefix("Admin")]
    public class AdminDashboardController : Controller
    {
        [Route("Dashboard")]
        // GET: Admin/AdminDashboard
        public ActionResult Index()
        {
            return View();
        }
       

    }
}