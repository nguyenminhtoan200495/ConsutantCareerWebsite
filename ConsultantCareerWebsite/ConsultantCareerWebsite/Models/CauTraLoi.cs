using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsultantCareerWebsite.Models
{
    public class CauTraLoi
    {
        public int MaCauTraLoi { get; set; }
        public int MaCauHoi { get; set; }
        public string TraLoi { get; set; }
        public DateTime NgayGui{ get; set; }
        public string HoTen { get; set; }
    }
}