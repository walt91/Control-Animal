using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Animal_Control.Models;

namespace Animal_Control.Controllers
{
    public class ProveedorController : Controller
    {
        public AnimalControl db = new AnimalControl();
        AC_Proveedor proveedor = new AC_Proveedor();

        // GET: Proveedor
        [Authorize]
        public ActionResult Index()
        {
            var model = db.AC_Proveedor.ToList();
            return View(model);
        }

        [Authorize]
        public ActionResult AgregarProveedor()
        {
            return View();
        }

        //POST : Agregar Proveedor
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarProveedor(AC_Proveedor p)
        {
            try
            {
                if (p != null)
                {
                    proveedor.Nombre = p.Nombre;
                    db.AC_Proveedor.Add(proveedor);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Proveedor");
                }               
            }
            catch (Exception ex)
            {
                ViewBag.mensage = "Ingrese los datos requeridos";
                return View("Error");
            }
            return View();
        }

        [Authorize]
        public ActionResult ModificarProveedor(int id)
        {
            var model = db.AC_Proveedor.Find(id);
            return View(model);
        }

        //POST : Modificar Proveedor
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModificarProveedor(int id, AC_Proveedor p)
        {
            proveedor = db.AC_Proveedor.Find(p.P_ID);
            if (proveedor != null)
            {
                try
                {
                    proveedor.Nombre = p.Nombre;
                    db.SaveChanges();
                    return RedirectToAction("Index", "Proveedor");

                }
                catch (Exception ex)
                {
                    ViewBag.mensage = "Este proveedor no existe";
                    return View("Error");
                }
            }
            return View();
        }

        [Authorize]
        public ActionResult EliminarProveedor(int id)
        {
            var model = db.AC_Proveedor.Find(id);
            if (model != null)
            {
                return View(model);
            }
            return View("Index");
        }

        //POST : Eliminar Proveedor
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarProveedor(int id, AC_Proveedor p)
        {
            proveedor = db.AC_Proveedor.Find(id);
            try
            {
                if (proveedor != null)
                {
                    db.AC_Proveedor.Remove(proveedor);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Proveedor");
                }
            }
            catch(Exception ex)
            {
                ViewBag.error = "No se pudo eliminar";
                ViewBag.mensage = "Tiene datos ligados a este registro";
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