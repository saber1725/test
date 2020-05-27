using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 會員資料.Models;

namespace _20200522會員資料寫入方法串接.Controllers
{
    public class newtestController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(cis會員資料 p)
        {
            (new cis會員資料factory()).insert(p);
            return View();
        }
    }
}