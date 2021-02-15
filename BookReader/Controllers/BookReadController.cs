using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookReader.Controllers
{
    public class BookReadController : Controller
    {
        // GET: BookRead
        public ActionResult Index()
        {
            return View();
        }
    }
}