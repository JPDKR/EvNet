using EvNet.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EvNet.Data.DataAccess;

namespace EvNet.Controllers
{
    public class HomeController : Controller
    {
        // GET: User
        public ActionResult Login()
        {
            ViewBag.ErrorLog = false;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Clientes usuView)
        {
            if (ModelState.IsValid)
            {
                var usuario = new ClienteAccess().Obtener(usuView.Email, usuView.Password);

                if (usuario != null)
                {
                    Session["UserID"] = usuario.Email.ToString();

                    return RedirectToAction("Index");
                }
                else
                    ViewBag.ErrorLog = true;

            }

            return View(usuView);
        }

        public ActionResult Index()
        {
            if (Session["UserID"] != null)
                return View();
            else
                return RedirectToAction("Login");
        }
    }
}