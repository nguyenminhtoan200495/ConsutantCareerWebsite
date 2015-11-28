using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;
using ConsultantCareerWebsite.Models;

namespace ConsultantCareerWebsite.Controllers
{
    public class WebsiteController : Controller
    {
        // GET: Website
        private WebsiteHelper websiteHelper = new WebsiteHelper();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TuVan tuvan)
        {
            websiteHelper.AddTuVan(tuvan);
            return View();
        }
        public ActionResult Reply()
        {
            return View(websiteHelper.GetListTuVan());
        }
        public ActionResult DetailReply(int id)
        {
            return View(websiteHelper.GetTuVan(id));
        }
        [HttpPost]
        public ActionResult DetailReply(TuVan tuVan)
        {
            websiteHelper.Update(tuVan);
            return (RedirectToAction("Reply"));
        }
    }
}