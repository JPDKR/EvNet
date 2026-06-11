using EvNet.Data;
using EvNet.Data.DataAccess;
using System.Web.Mvc;

namespace EvNet.Controllers
{
    public class ClienteController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["UserID"] == null)
                filterContext.Result = RedirectToAction("Login", "Home");
            else
                base.OnActionExecuting(filterContext);
        }

        public ActionResult Index()
        {
            var clientes = new ClienteAccess().ObtenerTodos();
            return View(clientes);
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

            CargarCiudades();
            return View(cli);
        }

        public ActionResult Baja(int id = 0)
        {
            ViewBag.ErrorLog = false;
            var cli = id > 0 ? new ClienteAccess().Obtener(id) : new Clientes();
            return View(cli);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Baja(Clientes cli)
        {
            ViewBag.ErrorLog = false;

            if (ModelState.IsValid)
            {
                var resultado = new ClienteAccess().Eliminar(cli.Id);

                if (resultado > 0)
                    return RedirectToAction("Index");
                else
                    ViewBag.ErrorLog = true;
            }

            return View(cli);
        }

        public ActionResult Modificacion(int id)
        {
            ViewBag.ErrorLog = false;
            CargarCiudades();
            var cli = new ClienteAccess().Obtener(id);
            if (cli == null)
                return RedirectToAction("Index");
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

            CargarCiudades();
            return View(cli);
        }

        private void CargarCiudades()
        {
            ViewBag.Ciudades = new CiudadAccess().ObtenerTodos();
        }
    }
}
