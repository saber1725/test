using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 會員資料.Models;

namespace _20200522會員資料寫入方法串接.Controllers
{
    public class clsmemberfunctionController : Controller
    {
        // GET: clsmemberfunction
        public ActionResult membersignon()
        {
            return View();
        }
        [HttpPost]
        public ActionResult membersignon(cis會員資料 p)
        {
           
            (new cis會員資料factory()).insert(p);
        
             return RedirectToAction("list");
        }


    }
}