using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;

namespace ConsultantCareerWebsite.Models
{
    public class AdminHelper
    {
        private readonly DataProvider dataProvider = new DataProvider();

        public bool IsAdmin(Admin admin)
        {
            string sql = @"SELECT* FROM ADMIN";
            var dataTable = dataProvider.ExecuteQuery(sql);
            foreach (DataRow row in dataTable.Rows)
            {
                Admin ad = new Admin();
                ad.Matkhau = row["Matkhau"].ToString();
                ad.TaiKhoan = row["TaiKhoan"].ToString();
                if (ad.Matkhau == admin.Matkhau && ad.TaiKhoan == admin.TaiKhoan)
                {
                    return true;
                }
            }
            return false;
        }
    }
}