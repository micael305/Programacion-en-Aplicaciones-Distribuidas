using System.Collections.Generic;
using System.Web.Mvc;

namespace Tarea_4___WebApplication.Controllers
{
    public class BlogsController : Controller
    {
        // GET: Blogs
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Listado()
        {
            List<string> lista = new List<string>();
            lista.Add("Blog 1");
            lista.Add("Blog 2");
            lista.Add("Blog 3");
            ViewBag.lista = lista;
            return View();
        }
    }
}