using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace 期末專題_圖片平台.Models
{
    public class CWorkSpace_Factory
    {
        public string w新增作品(CWorkSpace w)
        {
            string strSql = @"Insert into wWorkTable(""姓名"",""分類"",""作品名稱"",""作品描述"",""圖片名稱"",""圖片路徑"",""上傳日期"",""勾選項目分類"")
                                                values(@姓名,@分類,@作品名稱,@作品描述,@圖片名稱,@圖片路徑,@上傳日期,@勾選項目分類)";
            SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=期末專題;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(strSql, conn);
            cmd.CommandType = CommandType.Text;

            SqlParameter p姓名 = new SqlParameter("@姓名", SqlDbType.NVarChar, 50);
            p姓名.Direction = ParameterDirection.Input;
            p姓名.Value = w.姓名;
            cmd.Parameters.Add(p姓名);

            SqlParameter p分類 = new SqlParameter("@分類", SqlDbType.NVarChar, 50);
            p分類.Direction = ParameterDirection.Input;
            p分類.Value = w.分類;
            cmd.Parameters.Add(p分類);

            SqlParameter p作品名稱 = new SqlParameter("@作品名稱", SqlDbType.NVarChar, 50);
            p作品名稱.Direction = ParameterDirection.Input;
            p作品名稱.Value = w.作品名稱;
            cmd.Parameters.Add(p作品名稱);

            SqlParameter p作品描述 = new SqlParameter("@作品描述", SqlDbType.NVarChar, 255);
            p作品描述.Direction = ParameterDirection.Input;
            p作品描述.Value = w.作品描述;
            cmd.Parameters.Add(p作品描述);

            SqlParameter p圖片名稱 = new SqlParameter("@圖片名稱", SqlDbType.NVarChar, 50);
            p圖片名稱.Direction = ParameterDirection.Input;
            p圖片名稱.Value = w.圖片名稱;
            cmd.Parameters.Add(p圖片名稱);

            SqlParameter p圖片路徑 = new SqlParameter("@圖片路徑", SqlDbType.NVarChar, 255);
            p圖片路徑.Direction = ParameterDirection.Input;
            p圖片路徑.Value = w.圖片路徑;
            cmd.Parameters.Add(p圖片路徑);

            SqlParameter p上傳日期 = new SqlParameter("@上傳日期", SqlDbType.Char, 14);
            p上傳日期.Direction = ParameterDirection.Input;
            p上傳日期.Value = w.上傳日期;
            cmd.Parameters.Add(p上傳日期);

            SqlParameter p勾選項目分類 = new SqlParameter("@勾選項目分類", SqlDbType.NVarChar, 255);
            p勾選項目分類.Direction = ParameterDirection.Input;
            p勾選項目分類.Value = w.勾選項目分類;
            cmd.Parameters.Add(p勾選項目分類);


            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            cmd.Dispose();
            conn.Dispose();
            return "作品新增成功";
        }


        public CWorkSpace[] wGet所有作品()
        {
            string strSql = "select * from wWorkTable";
            return getbySql(strSql);
        }
        public CWorkSpace wGetBy編號(int id)
        {
            string strSql = $"select * from wWorkTable where 編號 = {id}";
            SqlConnection conn =new SqlConnection(@"Data Source=.;Initial Catalog=期末專題;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand(strSql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<CWorkSpace> list = new List<CWorkSpace>();
            while (reader.Read())
            {
                list.Add(new CWorkSpace()
                {
                    編號 = (int)reader["編號"],
                    姓名 = reader["姓名"].ToString(),
                    分類 = reader["分類"].ToString(),
                    作品名稱 = reader["作品名稱"].ToString(),
                    作品描述 = reader["作品描述"].ToString(),
                    圖片名稱 = reader["圖片名稱"].ToString(),
                    圖片路徑 = reader["圖片路徑"].ToString(),
                    上傳日期 = reader["上傳日期"].ToString(),
                    勾選項目分類 = reader["勾選項目分類"].ToString(),
                });
            }
            conn.Close();
            if (list.Count > 0)
            {
                return list[0];
            }
            else
            {
                return null;
            }
        }
        public CWorkSpace[] wGetBy姓名(string name)
        {
            string strSql = $"select * from wWorkTable where 姓名 = '{name}'";
            return getbySql(strSql);
        }
        public CWorkSpace[] wGetBy關鍵字(string keyword)
        {
            string strSql = "select * from wWorkTable where ";
            strSql += $"姓名 like N'%{keyword}%' or ";
            strSql += $"分類 like N'%{keyword}%' or ";
            strSql += $"作品名稱 like N'%{keyword}%' or ";
            strSql += $"圖片名稱 like N'%{keyword}%' or ";
            strSql += $"勾選項目分類 like N'%{keyword}%' or ";
            strSql += $"作品描述 like N'%{keyword}%'";
            return getbySql(strSql);
        }
        public void w修改作品資料(CWorkSpace w,int id)
        {
            string strSql = "update wWorkTable set ";
            strSql += $"分類 = N'{w.分類}', ";
            strSql += $"作品名稱 = N'{w.作品名稱}', ";
            strSql += $"作品描述 = N'{w.作品描述}', ";
            strSql += $"圖片名稱 = N'{w.圖片名稱}', ";
            strSql += $"圖片路徑 = N'{w.圖片路徑}',";
            strSql += $"勾選項目分類 =N'{w.勾選項目分類}'";
            strSql += $"where 編號={id}";
            executeNonQuery(strSql);
        }
        public void w刪除作品By編號(int id)
        {
            string strSql = "Delete from wWorkTable where ";
            strSql += $"編號 = {id}";
            executeNonQuery(strSql);

        }

        private static void executeNonQuery(string strSql)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=期末專題;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(strSql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            cmd.Dispose();
            conn.Dispose();
        }

        private static CWorkSpace[] getbySql(string strSql)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=期末專題;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand(strSql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<CWorkSpace> list = new List<CWorkSpace>();
            while (reader.Read())
            {
                list.Add(new CWorkSpace()
                {
                    編號 = (int)reader["編號"],
                    姓名 = reader["姓名"].ToString(),
                    分類 = reader["分類"].ToString(),
                    作品名稱 = reader["作品名稱"].ToString(),
                    作品描述 = reader["作品描述"].ToString(),
                    圖片名稱 = reader["圖片名稱"].ToString(),
                    圖片路徑 = reader["圖片路徑"].ToString(),
                    上傳日期 = reader["上傳日期"].ToString(),
                    勾選項目分類 = reader["勾選項目分類"].ToString(),
                });
            }
            conn.Close();
            cmd.Dispose();
            return list.ToArray();
        }

        //public string w圖片名稱(HttpPostedFileBase file)
        //{
        //    string filename = "";
        //    if (file.ContentLength > 0)
        //    {
        //        filename = Path.GetFileName(file.FileName);
        //    }
        //    return filename;

        //}
        //public string w圖片路徑資料夾(HttpPostedFileBase file)
        //{
        //    string filename = "";
        //    string filepath = "";
        //    if (file.ContentLength > 0)
        //    {
        //        filename = Path.GetFileName(file.FileName);
        //        filepath = Path.Combine(@"C:\Users\leo10\documents\visual studio 2017\Projects\期末專題_圖片平台\期末專題_圖片平台\App_Data\Upload_image\", filename);//儲存位置
        //    }
        //    return filepath;
        //}
        public string w上傳時間()
        {
            DateTime current = DateTime.Now;
            string currentTostring = current.ToString("yyyy") + current.ToString("MM") + current.ToString("dd") + current.ToString("HH") + current.ToString("mm") + current.ToString("ss");
            return currentTostring;
        }

    }
}