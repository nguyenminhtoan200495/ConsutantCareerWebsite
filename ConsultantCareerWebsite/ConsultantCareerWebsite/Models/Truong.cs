using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConsultantCareerWebsite.Models
{
    public class Truong
    {
        [Display(Name = "Mã Trường")]
        public string MaTruong { get; set; }
        [Display(Name = "Tên Trường")]
        public string TenTruong { get; set; }
        [Display(Name = "Loại Trường")]
        public string LoaiTruong { get; set; }
    }
}