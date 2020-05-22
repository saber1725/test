using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace 會員資料.Models
{
    public class cDataset
    {
        public void executeBySQL(string sql)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=MVCDB;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public cis會員資料[] getbySQL(string sql)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=MVCDB;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader reader = cmd.ExecuteReader();
            List<cis會員資料> list = new List<cis會員資料>();
            while (reader.Read())
            {
                list.Add(new cis會員資料()
                {
                    is會員資料ID = (int)reader["is會員資料id"],
                    is會員資料姓名 = reader["is會員資料姓名"].ToString(),
                    is會員資料暱稱 = reader["is會員資料暱稱"].ToString(),
                    is會員資料性別 = reader["is會員資料性別"].ToString(),
                    is會員資料連絡電話 = reader["is會員資料連絡電話"].ToString(),
                    is會員資料Email = reader["is會員資料Email"].ToString(),
                    is會員資料密碼 = reader["is會員資料密碼"].ToString(),
                    is會員資料聯絡地址 = reader["is會員資料地址"].ToString(),
                    is會員資料身分證照片 = reader["is會員資料身分證照片"].ToString(),
                    is會員資料會員權限等級 = reader["is會員資料會員權限等級"].ToString(),
                });
            }
            con.Close();
            return list.ToArray();
        }

    }
}