using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Ajax.Utilities;

namespace ConsultantCareerWebsite.Models
{
    public class ForumHelper
    {
        private readonly DataProvider dataProvider = new DataProvider();
        public List<CauHoi> GetForum()
        {
            string sql = string.Format("SELECT* FROM CAUHOI");
            List<CauHoi> list = new List<CauHoi>();
            var dataTable = dataProvider.ExecuteQuery(sql);
            foreach (DataRow row in dataTable.Rows)
            {
                CauHoi cauHoi = new CauHoi();
                cauHoi.MaCauHoi = Int32.Parse(row["MaCauHoi"].ToString());
                cauHoi.TenCauHoi = row["TenCauHoi"].ToString();
                cauHoi.NoiDung = row["NoiDung"].ToString();
                cauHoi.NgayGui = Convert.ToDateTime(row["NgayGui"].ToString());
                list.Add(cauHoi);
            }
            return list;
        }
        public PhanHoi GetQuestion(int id)
        {
            string sql = string.Format("SELECT * FROM CAUHOI WHERE MACAUHOI = {0}", id);
            PhanHoi phanHoi = new PhanHoi();
            var dataTable = dataProvider.ExecuteQuery(sql);
            foreach (DataRow row in dataTable.Rows)
            {
                phanHoi.MaCauHoi = Int32.Parse(row["MaCauHoi"].ToString());
                phanHoi.TenCauHoi = row["TenCauHoi"].ToString();
                phanHoi.NoiDung = row["NoiDung"].ToString();
            }
            sql = string.Format("SELECT * FROM CAUTRALOI WHERE MACAUHOI = {0}", id);
            var dataTableTraLoi = dataProvider.ExecuteQuery(sql);
            foreach (DataRow row in dataTableTraLoi.Rows)
            {
                CauTraLoi cauTraLoi = new CauTraLoi();
                cauTraLoi.MaCauHoi = Int32.Parse(row["MaCauHoi"].ToString());
                cauTraLoi.MaCauTraLoi = Int32.Parse(row["MaCauTraLoi"].ToString());
                cauTraLoi.TraLoi = row["TraLoi"].ToString();
                cauTraLoi.NgayGui = Convert.ToDateTime(row["NgayGui"].ToString());
                cauTraLoi.HoTen = row["HoTen"].ToString();
                phanHoi.ListCauTraLoi.Add(cauTraLoi);
            }
            return phanHoi;
        }

        public void AddComment(int MaCauHoi, string TraLoi, string HoTen)
        {
            string sql = string.Format("INSERT INTO CAUTRALOI VALUES({0}, N'{1}', GETDATE(), N'{2}')", MaCauHoi, TraLoi, HoTen);
            dataProvider.ExcuteNonQuery(sql);
        }
    }
}