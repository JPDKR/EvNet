using EvNet.Data;
using EvNet.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EvNet.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            var lst = new CiudadAccess().ObtenerTodos();

            ViewBag.Ciudades = lst;

            return View();
        }

        public ActionResult Alta()
        {
            ViewBag.ErrorLog = false;

            CargarCiudades();

            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Alta(Clientes cli)
        {
            ViewBag.ErrorLog = false;

            if (ModelState.IsValid)
            {
                var resultado = new ClienteAccess().Insertar(cli);

                if (resultado > 0)
                    return RedirectToAction("Index");
                else
                    ViewBag.ErrorLog = true;
            }

            return View();
        }

        public ActionResult Baja()
        {
            ViewBag.ErrorLog = false;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Baja(Clientes cli)
        {
            ViewBag.ErrorLog = false;

            if (ModelState.IsValid)
            {
                var resultado = new ClienteAccess().Eliminar(cli.Id);

                if (resultado == 0)
                    return RedirectToAction("Index");
                else
                    ViewBag.ErrorLog = true;
            }

            return View();
        }

        public ActionResult Modificacion()
        {
            ViewBag.ErrorLog = false;

            CargarCiudades();

            var cli = new ClienteAccess().Obtener(4);

            return View(cli);
        }
                
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modificacion(Clientes cli)
        {
            ViewBag.ErrorLog = false;

            if (ModelState.IsValid)
            {
                var resultado = new ClienteAccess().Modificar(cli);

                if (resultado > 0)
                    return RedirectToAction("Index");
                else
                    ViewBag.ErrorLog = true;
            }

            return View();
        }

        private void CargarCiudades()
        {
            var lst = new CiudadAccess().ObtenerTodos();

            ViewBag.Ciudades = lst;
        }
    }
}