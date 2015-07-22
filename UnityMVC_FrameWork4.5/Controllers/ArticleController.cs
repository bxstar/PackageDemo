using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnityMVCDemo.Models;

namespace UnityMVCDemo.Controllers
{
    public class ArticleController : Controller
    {
        //static Boolean isInitdata = false;

        readonly IArticleRepository repository;

        //属性注入
        [Microsoft.Practices.Unity.Dependency]
        public IArticleRepository repositoryImp2 { get; set; }

        //构造器注入
        public ArticleController(IArticleRepository repository)
        {
            //if (!isInitdata)
            //{
                this.repository = repository;
                //isInitdata = true;
            //}
        }

        #region 基本视图
        public ActionResult Index()
        {
            var data = repository.GetAll();
            return View(data);
        }

        public ActionResult Edit(int id)
        {
            var data = repository.Get(id);
            return View(data);
        }

        public ActionResult Details(int id)
        {
            var data = repository.Get(id);
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        } 
        #endregion



        public ActionResult UpdateItem(Article item)
        {
            repository.Update(item);
            return View("Index",repository.GetAll());
        }

        public ActionResult DeleteItem(int id)
        {
            repository.Delete(id);
            return View("Index", repository.GetAll());
        }

        public ActionResult CreateItem(Article item)
        {
            //repository.Add(item);
            repositoryImp2.Add(item);
            return View("Index", repository.GetAll());
        }
    }
}
