using System;
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
            return Content("Hello ajax" + ",时间:" + DateTime.Now.ToString("HH:mm:ss") + "\n");
        }

        public ActionResult ServerMethodWithParam(int id, string name)
        {

            string result = "客户端传递过来的id:" + id + ",名字:" + name;

            return Content(result + ",时间:" + DateTime.Now.ToString("HH:mm:ss"));

        }

        public ActionResult ServerMethodLoading()
        {
            System.Threading.Thread.Sleep(2000);

            return Content("Hello ajax" + ",时间:" + DateTime.Now.ToString("HH:mm:ss") + "\n");

        }
    }
}
