using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConsultantCareerWebsite.Models
{
    public class TestScore
    {
        public string MaTruong { get; set; }
        [Display(Name = "Tên Trường")]
        public List<SelectListItem> ListTruong { get; set; }
        [Display(Name = "Số Báo Danh")]
        public string Sbd { get; set; }
        [Display(Name = "Họ Tên")]
        public string HoTen { get; set; }
        public List<DiemThi> ListDiem { get; set; }
        public TestScore()
        {
            ListDiem = new List<DiemThi>();
            ListTruong = new List<SelectListItem>();
        }
    }
}