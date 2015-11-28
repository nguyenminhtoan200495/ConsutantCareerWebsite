using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConsultantCareerWebsite.Models;

namespace ConsultantCareerWebsite.Controllers
{
    public class TruongController : Controller
    {
        // GET: Truong
        private TruongHelper truongHelper = new TruongHelper();

        public ActionResult Index()
        {
            return View(truongHelper.GetTruong());
        }
        [HttpPost]
        public ActionResult Index(Truong truong)
        {
            return View(truongHelper.GetTruongByName(truong));
        }
        public ActionResult Detail(string id, int nam)
        {
            TruongDetailViewModel truongDetail = new TruongDetailViewModel();
            truongDetail.ListDiemChuans = truongHelper.GetDiemChuan(id, nam);
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem {Text = "2013", Value = "2013"});
            list.Add(new SelectListItem { Text = "2014", Value = "2014" });
            list.Add(new SelectListItem { Text = "2015", Value = "2015" });
            truongDetail.ListNam = list;
            return View(truongDetail);
        }

        public ActionResult TestScore()
        {
            TestScore testScore = new TestScore();
            testScore.ListTruong = truongHelper.GetTruongs();
            return View(testScore);
        }
        [HttpPost]
        public ActionResult TestScore(string matruong, string sbd, string hoTen)
        {
            return View(truongHelper.GetTestScore(matruong, sbd, hoTen));
        }
    }

}