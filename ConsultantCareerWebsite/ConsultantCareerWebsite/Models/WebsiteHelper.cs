using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;

namespace ConsultantCareerWebsite.Models
{
    public class WebsiteHelper
    {
        private readonly DataProvider dataProvider = new DataProvider();

        public void AddTuVan(TuVan tuvan)
        {
            string sql = string.Format("INSERT TUVAN VALUES(N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', null)", tuvan.SoThich, tuvan.MonHocYeuThich, tuvan.DiemManh, tuvan.DiemYeu, tuvan.KyNang, tuvan.CongViec);
            dataProvider.ExecuteQuery(sql);
        }
    }
}