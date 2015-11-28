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

        public List<TuVan> GetListTuVan()
        {
            string sql = @"SELECT* FROM TUVAN WHERE TRALOI IS NULL";
            List<TuVan> list = new List<TuVan>();
            var dataTable = dataProvider.ExecuteQuery(sql);
            foreach (DataRow row in dataTable.Rows)
            {
                TuVan tuVan = new TuVan();
                tuVan.Id = Int32.Parse(row["Id"].ToString());
                tuVan.SoThich = row["SoThich"].ToString();
                tuVan.MonHocYeuThich = row["MonHocYeuThich"].ToString();
                tuVan.DiemManh = row["DiemManh"].ToString();
                tuVan.DiemYeu = row["DiemYeu"].ToString();
                tuVan.KyNang = row["KyNang"].ToString();
                tuVan.CongViec = row["CongViec"].ToString();
                tuVan.TraLoi = row["TraLoi"].ToString();
                list.Add(tuVan);
            }
            return list;
        }

        public TuVan GetTuVan(int id)
        {
            string sql = string.Format("SELECT* FROM TUVAN WHERE ID = {0}", id);
            var dataTable = dataProvider.ExecuteQuery(sql);
            TuVan tuVan = new TuVan();
            foreach (DataRow row in dataTable.Rows)
            {
                tuVan.Id = Int32.Parse(row["Id"].ToString());
                tuVan.SoThich = row["SoThich"].ToString();
                tuVan.MonHocYeuThich = row["MonHocYeuThich"].ToString();
                tuVan.DiemManh = row["DiemManh"].ToString();
                tuVan.DiemYeu = row["DiemYeu"].ToString();
                tuVan.KyNang = row["KyNang"].ToString();
                tuVan.CongViec = row["CongViec"].ToString();
                tuVan.TraLoi = row["TraLoi"].ToString();
            }
            return tuVan;
        }

        public void Update(TuVan tuVan)
        {
            string sql = string.Format("UPDATE TUVAN SET TRALOI = N'{0}' WHERE ID = {1}", tuVan.TraLoi,tuVan.Id);
            dataProvider.ExecuteQuery(sql);
        }
    }
}