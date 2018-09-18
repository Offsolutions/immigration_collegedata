using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewImmigration.Areas.Admin.Models;
using System.Net;

namespace NewImmigration.Areas.Admin.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Admin/Default
         dbcontext db = new dbcontext();
        public ActionResult Index(int country)
        {
            TempData["country"] = country.ToString();
            return View(db.Colleges.Where(x => x.Countryid == country).ToList());
          //  return View();
        }
        [HttpPost]
        public ActionResult Index(int country, int category, Courses cs)
        {
            return View(db.Courses.Where(x => x.Categoryid == category).ToList());
        }
        //public ActionResult Index()
        //{
        //    // string a = help.EncryptData("FuTureViSion2013");
        //    Courses cs = new Courses();
        //    return View(db.Courses.Where(x = == null).ToList());
        //}
        public ActionResult AllCountries()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AllCountries(int country)
        {
            TempData["country"] = country.ToString();
            return View(db.Colleges.Where(x => x.Countryid == country).ToList());
            
        }
    }
}
