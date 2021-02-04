using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookReader.Controllers
{
    public class ReadController : Controller
    {
        // GET: Read
        public ActionResult Index()
        {
            return View();
        }
    }
}