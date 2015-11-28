using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConsultantCareerWebsite.Models
{
    public class ChiTietDiemChuan
    {
        [Display(Name = "Điểm Chuẩn")]
        public float Diem { get; set; }
        [Display(Name = "Mã Ngành")]
        public string MaNganh { get; set; }
        [Display(Name = "Tên Ngành")]
        public string TenNganh { get; set; }
        [Display(Name = "Khối Thi")]
        public string KhoiThi { get; set; }
    }
}