using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConsultantCareerWebsite.Models;

namespace ConsultantCareerWebsite.Controllers
{
    public class ForumController : Controller
    {
        // GET: Forum
        private ForumHelper forumHelper = new ForumHelper();
        public ActionResult Index()
        {
            return View(forumHelper.GetForum());
        }

        public ActionResult Question(int id)
        {
            return View(forumHelper.GetQuestion(id));
        }
        [HttpPost]
        public ActionResult Question(int maCauHoi, string traLoi, string hoTen)
        {
            forumHelper.AddComment(maCauHoi, traLoi, hoTen);
            return (RedirectToAction("Question", new { id = maCauHoi }));
        }
    }
}