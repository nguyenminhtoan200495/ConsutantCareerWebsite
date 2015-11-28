using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConsultantCareerWebsite.Models
{
    public class TruongDetailViewModel
    {
        public List<ChiTietDiemChuan> ListDiemChuans { get; set; }
        public List<SelectListItem> ListNam { get; set; }
        public string Nam { get; set; }
    }
}