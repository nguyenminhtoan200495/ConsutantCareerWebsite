using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConsultantCareerWebsite.Models;

namespace ConsultantCareerWebsite.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        private AdminHelper adminHelper = new AdminHelper();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            if (adminHelper.IsAdmin(admin))
            {
                ;
            }
            return View();
        }
    }
}