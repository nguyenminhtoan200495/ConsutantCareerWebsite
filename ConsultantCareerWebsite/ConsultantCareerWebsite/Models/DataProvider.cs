using System;
using System.Data;
using System.Data.SqlClient;

namespace ConsultantCareerWebsite.Models
{
    public class DataProvider
    {
        private string connString = "Data Source=.;Initial Catalog=QuanLyTrangWeb;Integrated Security=True";
        private SqlConnection connection;

        public DataProvider()
        {
            connection = new SqlConnection(connString);
        }

        public DataTable ExecuteQuery(string sql)
        {
            DataTable dataTable = new DataTable();
            try
            {
                connection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, connection);
                sqlDataAdapter.Fill(dataTable);
            }
            catch (Exception e)
            {
                throw new Exception("Can't execute query: " + e);
            }
            finally
            {
                connection.Close();
            }
            return dataTable;
        }

        public void ExcuteNonQuery(string sql)
        {

            try
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand(sql, connection);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Can't execute query: " + e);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}