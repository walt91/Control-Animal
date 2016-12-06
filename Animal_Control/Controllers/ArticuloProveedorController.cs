using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Animal_Control.Models;
using System.Text;

namespace Animal_Control.Controllers
{
    public class ArticuloProveedorController : Controller
    {
        public AnimalControl db = new AnimalControl();
        AC_Articulo_Proveedor proveedor = new AC_Articulo_Proveedor();

        // GET: ArticuloProveedor
        [Authorize]
        public ActionResult Index()
        {
            StringBuilder articulo = new StringBuilder();
            articulo.AppendLine("SELECT P.AP_ID ID, " +
                                "a.Nombre Articulo, " +
                                "u.Nombre Proveedor " +
                                "FROM AC_Articulo_Proveedor p " +
                                "INNER JOIN AC_Articulo a ON p.ID_Articulo = a.A_ID " +
                                "INNER JOIN AC_Proveedor u ON p.AP_ID = u.P_ID ");

            var model = db.Database.SqlQuery<QueryArticuloProveedor>(articulo.ToString()).ToList();
            return View(model);
        }

        [Authorize]
        public ActionResult Agregar()
        {
            var Articulo = db.AC_Articulo.ToList();
            SelectList listArticulo = new SelectList(Articulo, "A_ID", "Nombre");
            ViewBag.articulo = listArticulo;
            var Proveedor = db.AC_Proveedor.ToList();
            SelectList listProveedor = new SelectList(Proveedor, "P_ID", "Nombre");
            ViewBag.proveedor = listProveedor;
            return View();
        }

        //Se agrega un nuevo articulo a un proveedor
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(AC_Articulo_Proveedor p)
        {
            if (p != null)
            {
                try
                {
                    proveedor.ID_Articulo = p.ID_Articulo;
                    proveedor.ID_Proveedor = p.ID_Proveedor;
                    db.AC_Articulo_Proveedor.Add(proveedor);
                    db.SaveChanges();
                    return RedirectToAction("Index", "ArticuloProveedor");
                }
                catch (Exception ex)
                {
                    ViewBag.mensage = "No se pudo agregar";
                    return View("Error");
                }
            }
            return View();
        }

        [Authorize]
        public ActionResult Modificar(int id)
        {
            var model = db.AC_Articulo_Proveedor.Find(id);
            var Articulo = db.AC_Articulo.ToList();
            SelectList listArticulo = new SelectList(Articulo, "A_ID", "Nombre");
            ViewBag.articulo = listArticulo;
            var Proveedor = db.AC_Proveedor.ToList();
            SelectList listProveedor = new SelectList(Proveedor, "P_ID", "Nombre");
            ViewBag.proveedor = listProveedor;
            return View(model);
        }

        //Se modifica un nuevo articulo Proveedor
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modificar(int id, AC_Articulo_Proveedor p)
        {
            proveedor = db.AC_Articulo_Proveedor.Find(id);
            if (proveedor != null)
            {
                try
                {
                    proveedor.ID_Articulo = p.ID_Articulo;
                    proveedor.ID_Proveedor = p.ID_Proveedor;
                    db.SaveChanges();
                    return RedirectToAction("Index", "ArticuloProveedor");

                }
                catch (Exception ex)
                {
                    ViewBag.mensage = "Este articulo no existe";
                    return View("Error");
                }
            }
            return View();
        }

        [Authorize]
        public ActionResult Eliminar(int id)
        {
            var model = db.AC_Articulo_Proveedor.Find(id);
            if (model == null)
            {
                return RedirectToAction("Index","ArticuloProveedor");
            }
            return View(model);
        }

        //Se elimina un articulo de un proveedor
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(int id, AC_Articulo a)
        {
            proveedor = db.AC_Articulo_Proveedor.Find(id);
            try
            {
                db.AC_Articulo_Proveedor.Remove(proveedor);
                db.SaveChanges();
                return RedirectToAction("Index", "ArticuloProveedor");
            }
            catch (Exception ex)
            {
                ViewBag.mensage = "No se pudo eliminar este registro";
                return View("Error");
            }
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}