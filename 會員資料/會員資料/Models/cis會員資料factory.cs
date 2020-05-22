using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace 會員資料.Models
{
    public class cis會員資料factory
    {
        public cis會員資料[] getAll()
        {
            cDataset dataset = new cDataset();
            string sql = "select * from is會員資料";
            return dataset.getbySQL(sql);
        }

        public cis會員資料 getByID(int is會員資料ID)
        {
            string sql = "select * from is會員資料 where is會員資料id = " + is會員資料ID.ToString();
            cDataset myDataset = new cDataset();
            cis會員資料[] users = myDataset.getbySQL(sql);
            if(users.Length > 0)
            {
                return users[0];
            }
            return null;
        }

        internal void insert(cis會員資料 p)
        {
            cDataset data = new cDataset();
            string sql = "insert into is會員資料 (";
            sql += "is會員資料姓名,";
            sql += "is會員資料Email,";
            sql += "is會員資料密碼)";
            sql += "values (";
            sql += "'" + p.is會員資料姓名 + "',";
            sql += "'" + p.is會員資料Email + "',";
            sql += "'" + p.is會員資料密碼 + "')";
            data.executeBySQL(sql);
            
        }
    }
    }