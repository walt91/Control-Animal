using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Animal_Control.Models;
using System.Data.Entity;

namespace Animal_Control.Controllers
{
    public class ArticuloController : Controller
    {
        public AnimalControl db = new AnimalControl();
        AC_Articulo articulo = new AC_Articulo();


        // GET: Articulo

        public ActionResult Index()
        {
            var model = db.AC_Articulo.ToList();
            return View(model);
        }

        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(AC_Articulo a)
        {
            if (a != null)
            {
                try
                {
                    articulo.Nombre = a.Nombre;
                    db.AC_Articulo.Add(articulo);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Articulo");
                }
                catch (Exception ex)
                {
                    ViewBag.error = "No se pudo agregar";
                    ViewBag.mensage = "No se pudo agregar";
                }
            }
            return View();
        }

        public ActionResult Modificar(int id)
        {
            var model = db.AC_Articulo.Find(id);
            if (model != null)
            {
                return View(model);
            }
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modificar(AC_Articulo a)
        {
            articulo = db.AC_Articulo.Find(a.A_ID);
            if (articulo != null)
            {
                try
                {
                    articulo.Nombre = a.Nombre;
                    db.SaveChanges();
                    return RedirectToAction("Index", "Articulo");

                }
                catch (Exception ex)
                {
                    ViewBag.error = "No se pudo eliminar";
                    ViewBag.mensage = "Este articulo no existe";
                    return View("Error");
                }
            }
            return View();
        }

        public ActionResult Eliminar(int id)
        {
            var model = db.AC_Articulo.Find(id);
            if (model != null)
            {
                return View(model);
            }
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(int id, AC_Articulo a)
        {
            articulo = db.AC_Articulo.Find(id);
            try
            {
                db.AC_Articulo.Remove(articulo);
                db.SaveChanges();
                return RedirectToAction("Index", "Articulo");
            }
            catch (Exception ex)
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