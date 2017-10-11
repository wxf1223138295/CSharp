using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UserLoginDemo.Controllers
{
    public class UserLoginController : Controller
    {
        // GET: UserLogin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UserRegist()
        {
            return View();
        }
        public ActionResult ProcessRegist(string txtName,string txtPassword)
        {
            //string userName = Request["txtName"];
            //string str = Collection["txtName"];
            return Content("ok"+txtName+""+txtPassword);
        }
        public class myclass
        {
            public string txtName { get; set; }
            public string txtPassword { get; set; }
        }
    }
}