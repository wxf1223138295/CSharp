using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserLoginDemo.Models;

namespace UserLoginDemo.Controllers
{
    public class GurdController : Controller
    {
        Model1Container dbcontext = new Model1Container();
        // GET: Gurd
        public ActionResult Index(int pageIndex=1,int pageSize=10)
        {
            //ViewData.Model = dbcontext.代码_电子住院证.ToList();
            ViewData["pageIndex"] = pageIndex;
            ViewData["pageSize"] = pageSize;
            ViewData["total"] = dbcontext.代码_电子住院证.Count();

            ViewData.Model = dbcontext.代码_电子住院证.OrderBy(u => u.就诊ID).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();


            return View();
        }
        public ActionResult Details(int id)
        {
            ViewData.Model = dbcontext.代码_电子住院证.Find(id);
            return View();
        }
        public ActionResult Edit(int id)
        {
            ViewData.Model = dbcontext.代码_电子住院证.Find(id);
            return View();
        }
    }
}