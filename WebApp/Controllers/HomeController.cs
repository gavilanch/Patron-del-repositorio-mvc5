using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApp.Data;
using WebApp.Data.Contratos;
using WebApp.Data.Repositorios;
using WebApp.Models;
using WebApp.ServiceReference1;
using WebApp.Servicios;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private RepositorioDePersonas _repositorio;

        public HomeController(RepositorioDePersonas repositorio)
        {
            _repositorio = repositorio;
        }

        public ActionResult Index()
        {
            var persona = new Persona() { Edad = 95, Nombre = "Pascual" };
            _repositorio.Agregar(persona);


            var parametros1 = new ParametrosDeQuery<Persona>(1, 5);
            parametros1.OrderBy = x => x.Edad;
            parametros1.Where = x => x.Edad > 50;

            var personas1 = _repositorio.EncontrarPor(parametros1);

            return View();
        }

        public ActionResult About()
        {
            string path = Url.Action("index", "Home");
            Response.RemoveOutputCacheItem(path);

            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
