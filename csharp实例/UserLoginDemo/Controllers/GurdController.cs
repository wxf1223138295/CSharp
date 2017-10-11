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
        public ActionResult Index()
        {
            ViewData.Model = dbcontext.代码_电子住院证.ToList().Skip(4).Take(5);
            return View();
        }
        public ActionResult Details(int id)
        {
            ViewData.Model = dbcontext.代码_电子住院证.Find(id);
            return View();
        }
    }
}