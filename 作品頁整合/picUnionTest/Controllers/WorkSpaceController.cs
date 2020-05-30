using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 期末專題_圖片平台.Models;

namespace 期末專題_圖片平台.Controllers
{
    public class WorkSpaceController : Controller
    {
        // GET: WorkSpace
        public ActionResult Index()
        {
            CWorkSpace_Factory factory = new CWorkSpace_Factory();
            return View(factory.wGet所有作品());
        }
        
        public ActionResult w新增作品()
        {
            return View();
        }
        [HttpPost]
        public ActionResult w新增作品(HttpPostedFileBase 圖片檔案, CWorkSpace w)
        {
            string fileName = "";
            string filePath = "";
            if (圖片檔案 != null)
            {
                if (圖片檔案.ContentLength > 0)
                {
                    fileName = Path.GetFileName(圖片檔案.FileName);
                    var fileExtension = Path.GetExtension(圖片檔案.FileName);
                    var fileWithoutExtension = Path.GetFileNameWithoutExtension(圖片檔案.FileName);
                    filePath = Path.Combine(Server.MapPath("~/Upload_image"),圖片檔案.FileName);
                    圖片檔案.SaveAs(filePath);
                    
                    w.圖片名稱 = fileName;
                    w.圖片路徑 = "~/Upload_image/" + 圖片檔案.FileName;
                    w.上傳日期 = (new CWorkSpace_Factory()).w上傳時間();
                    if (string.IsNullOrEmpty(w.姓名))
                        w.姓名 = "未填寫";
                    if (string.IsNullOrEmpty(w.作品名稱))
                        w.作品名稱 = "未填寫";
                    if (string.IsNullOrEmpty(w.作品描述))
                        w.作品描述 = "未填寫";
                    if (string.IsNullOrEmpty(w.分類))
                        w.分類 = "未填寫";
                    if (string.IsNullOrEmpty(w.勾選項目分類))
                        w.勾選項目分類 = "未填寫";
                    (new CWorkSpace_Factory()).w新增作品(w);
                }
            }
            return RedirectToAction("Index");
        }
        public ActionResult w瀏覽作品()
        {
            CWorkSpace_Factory factory = new CWorkSpace_Factory();
            return View(factory.wGet所有作品());
        }
        public ActionResult w我的作品(string name)
        {
            CWorkSpace_Factory factory = new CWorkSpace_Factory();
            return View(factory.wGetBy姓名(name));
        }
        public ActionResult w搜尋我的作品(string keyword)
        {
            CWorkSpace_Factory factory = new CWorkSpace_Factory();

            return View(factory.wGetBy關鍵字(keyword));
        }

        public ActionResult w搜尋作品(string keyword)
        {
            CWorkSpace_Factory factory = new CWorkSpace_Factory();
            return View(factory.wGetBy關鍵字(keyword));
        }
        [HttpGet]
        public ActionResult w修改作品資料(int id)
        {
            CWorkSpace myWork = (new CWorkSpace_Factory()).wGetBy編號(id);
            if(myWork == null)
            {
                return RedirectToAction("Index");
            }
            return View(myWork);
        }
        [HttpPost]
        public ActionResult w修改作品資料(HttpPostedFileBase 圖片檔案, CWorkSpace w ,int id)
        {
            CWorkSpace_Factory factory = new CWorkSpace_Factory();
            if (圖片檔案 != null)
            {
                if (圖片檔案.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(圖片檔案.FileName);
                    var fileExtension = Path.GetExtension(圖片檔案.FileName);
                    var fileWithoutExtension = Path.GetFileNameWithoutExtension(圖片檔案.FileName);
                    var filePath = Path.Combine(Server.MapPath("~/Upload_image"), 圖片檔案.FileName);
                    圖片檔案.SaveAs(filePath);

                    w.圖片名稱 = fileName;
                    w.圖片路徑 = "~/Upload_image/"+圖片檔案.FileName;
                    w.上傳日期 = (new CWorkSpace_Factory()).w上傳時間();

                    factory.w修改作品資料(w, id);
                }
            }

            return RedirectToAction("Index");
        }


        public ActionResult w刪除作品(int id)
        {
            CWorkSpace_Factory factory = new CWorkSpace_Factory();
            factory.w刪除作品By編號(id);
            return RedirectToAction("Index");
        }
    }
}