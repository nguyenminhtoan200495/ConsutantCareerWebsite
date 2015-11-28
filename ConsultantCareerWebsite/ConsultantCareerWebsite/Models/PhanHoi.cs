using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsultantCareerWebsite.Models
{
    public class PhanHoi
    {
        public int MaCauHoi { get; set; }
        public string TenCauHoi { get; set; }
        public string NoiDung { get; set; }
        public List<CauTraLoi> ListCauTraLoi { get; set; }

        public PhanHoi()
        {
            ListCauTraLoi = new List<CauTraLoi>();
        }
    }
}