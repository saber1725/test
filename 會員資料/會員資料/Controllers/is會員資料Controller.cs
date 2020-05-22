using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 會員資料.Models;

namespace 會員資料.Controllers
{
    public class is會員資料Controller : Controller
    {
        public ActionResult list()
        {
            cis會員資料factory factory = new cis會員資料factory();
            return View(factory.getAll());
        }

        public ActionResult New()
        {
            return View();
        }
        [HttpPost]
        public ActionResult New(cis會員資料 p)
        {
            new cis會員資料factory().insert(p);
            return RedirectToAction("list");
        }


        // GET: is會員資料
        public ActionResult Index()
        {
            return View();
        }
    }
}