using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;


namespace ConsultantCareerWebsite.Models
{
    public class TruongHelper
    {
        private readonly DataProvider dataProvider = new DataProvider();

        public List<Truong> GetTruong()
        {
            string sql = @"SELECT* FROM TRUONG";
            List<Truong> list = new List<Truong>();
            var dataTable = dataProvider.ExecuteQuery(sql);
            foreach (DataRow row in dataTable.Rows)
            {
                Truong truong = new Truong();
                truong.MaTruong = row["MaTruong"].ToString();
                truong.TenTruong = row["TenTruong"].ToString();
                truong.LoaiTruong = row["LoaiTruong"].ToString();
                list.Add(truong);
            }
            return list;
        }

        public List<ChiTietDiemChuan> GetDiemChuan(string matruong, int nam)
        {
            string sql = string.Format("SELECT CN.MANGANH, CN.TENNGANH, DC.KHOITHI, DC.DIEM FROM CHUYENNGANH CN JOIN DIEMCHUAN DC ON (CN.MANGANH = DC.MANGANH AND CN.KHOITHI = DC.KHOITHI) WHERE CN.MATRUONG = '{0}' AND DC.NAM = {1} GROUP BY CN.MANGANH, CN.TENNGANH, DC.KHOITHI, DC.DIEM", matruong, nam);
            List<ChiTietDiemChuan> list = new List<ChiTietDiemChuan>();
            var dataTable = dataProvider.ExecuteQuery(sql);
            foreach (DataRow row in dataTable.Rows)
            {
                ChiTietDiemChuan chiTiet = new ChiTietDiemChuan();
                chiTiet.Diem = float.Parse(row["Diem"].ToString());
                chiTiet.MaNganh = row["MaNganh"].ToString();
                chiTiet.TenNganh = row["TenNganh"].ToString();
                chiTiet.KhoiThi = row["KhoiThi"].ToString();
                list.Add(chiTiet);
            }
            return list;
        }

        public List<Truong> GetTruongByName(Truong truong)
        {
            string matruong = truong.MaTruong;
            string tentruong = truong.TenTruong;
            string loaitruong = truong.LoaiTruong;
            string sql =  string.Format("SELECT* FROM TRUONG WHERE TENTRUONG = N'{0}' OR MATRUONG ='{1}' OR LOAITRUONG = N'{2}'", tentruong, matruong, loaitruong);
            List<Truong> list = new List<Truong>();
            var dataTable = dataProvider.ExecuteQuery(sql);
            foreach (DataRow row in dataTable.Rows)
            {
                Truong truongDh = new Truong();
                truongDh.MaTruong = row["MaTruong"].ToString();
                truongDh.TenTruong = row["TenTruong"].ToString();
                truongDh.LoaiTruong = row["LoaiTruong"].ToString();
                list.Add(truongDh);
            }
            return list;
        }
        public List<SelectListItem> GetTruongs()
        {
            string sql = @"SELECT* FROM TRUONG";
            List<SelectListItem> list = new List<SelectListItem>();
            var dataTable = dataProvider.ExecuteQuery(sql);
            foreach (DataRow row in dataTable.Rows)
            {
                SelectListItem truong = new SelectListItem();
                truong.Value = row["MaTruong"].ToString();
                truong.Text = row["TenTruong"].ToString();
                list.Add(truong);
            }
            return list;
        }

        public TestScore GetTestScore(string matruong, string sbd, string hoTen)
        {
            TestScore testScore = new TestScore();
            testScore.ListTruong = GetTruongs();
            testScore.MaTruong = matruong;
            testScore.Sbd = sbd;
            testScore.HoTen = hoTen;
            string sql = string.Format("SELECT DISTINCT TS.SBD, TS.HOTEN, TS.NGAYSINH, CN.TENNGANH, DT.KHOITHI, DT.DIEM FROM DIEMTHI DT JOIN THISINH TS ON DT.SBD = TS.SBD JOIN CHUYENNGANH CN ON CN.MANGANH = DT.MANGANH WHERE DT.MATRUONG = N'{0}' AND (TS.SBD = '{1}' OR HOTEN = N'{2}')", matruong, sbd, hoTen);
            var dataTableDiemThi = dataProvider.ExecuteQuery(sql);
            foreach (DataRow row in dataTableDiemThi.Rows)
            {
                DiemThi diemThi = new DiemThi();
                diemThi.Sbd = row["Sbd"].ToString();
                diemThi.HoTen = row["HoTen"].ToString();
                diemThi.NgaySinh = Convert.ToDateTime(row["NgaySinh"].ToString());
                diemThi.TenNganh = row["TenNganh"].ToString();
                diemThi.KhoiThi = row["KhoiThi"].ToString();
                diemThi.Diem = float.Parse(row["Diem"].ToString());
                testScore.ListDiem.Add(diemThi);
            }
            return testScore;
        }
    }
}