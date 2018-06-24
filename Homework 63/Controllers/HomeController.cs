using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Homework_63.Models;

namespace Homework_63.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var mgr = new NewsPostManager();
            return View(mgr.GetAllNews());
        }

    }
}