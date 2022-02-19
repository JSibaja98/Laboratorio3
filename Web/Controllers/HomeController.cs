using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {

        Metodos metodos = new Metodos();

        public HomeController()
        {
            ViewBag.Message = "Your application description page.";
        }
        public ActionResult Index()
        {
            return View();
        }

       

    }
}