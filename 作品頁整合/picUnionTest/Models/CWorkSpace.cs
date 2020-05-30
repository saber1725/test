using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 期末專題_圖片平台.Models
{
    public class CWorkSpace
    {
        public int 編號 { get; set; }
        public string 姓名 { get; set; }
        public string 分類 { get; set; }
        public string 作品名稱 { get; set; }
        public string 作品描述 { get; set; }
        public string 圖片名稱 { get; set; }
        public string 圖片路徑 { get; set; }
        public string 上傳日期 { get; set; }
        public string 勾選項目分類 { get; set; }
        public HttpPostedFileBase 圖片檔案 { get; set; }
    }
}