using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsultantCareerWebsite.Models
{
    public class TuVan
    {
        public int Id { get; set; }
        public string SoThich { get; set; }
        public string MonHocYeuThich { get; set; }
        public string DiemManh { get; set; }
        public string DiemYeu { get; set; }
        public string KyNang { get; set; }
        public string CongViec { get; set; }
        public string TraLoi { get; set; }
    }
}