﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UnityMVCDemo.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ServerMethod()
        {
            return Content("Hello ajax" + DateTime.Now.ToString("HH:mm:ss") + "\n");
        }
    }
}
