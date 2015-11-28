using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsultantCareerWebsite.Models
{
    public class CauHoi
    {
        public int MaCauHoi { get; set; }
        public string TenCauHoi { get; set; }
        public string NoiDung { get; set; }
        public DateTime NgayGui { get; set; }
    }
}