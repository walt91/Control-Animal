using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Animal_Control.Models;

namespace Animal_Control.Controllers
{
    public class ZonaController : Controller
    {
        public AnimalControl db = new AnimalControl();
        AC_Zona zona = new AC_Zona();

        // GET: Zona
        [Authorize]
        public ActionResult Index()
        {
            var model = db.AC_Zona.ToList();
            return View(model);
        }

        [Authorize]
        public ActionResult AgregarZona()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarZona(AC_Zona zone)
        {
            try
            {
                if (zone != null)
                {
                    zona.Nombre = zone.Nombre;
                    db.AC_Zona.Add(zona);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Zona");
                }
                else
                {
                    ViewBag.mensage = "Ingrese los datos requeridos";
                }
            }
            catch (Exception ex)
            {

            }

            return View();
        }

        [Authorize]
        public ActionResult ModificarZona(int id)
        {
            var model = db.AC_Zona.Find(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModificarZona(int id, AC_Zona zone)
        {
            zona = db.AC_Zona.Find(zone.ID);
            if (zona != null)
            {
                try
                {
                    zona.Nombre = zone.Nombre;
                    db.SaveChanges();
                    return RedirectToAction("Index", "Zona");

                }
                catch (Exception ex)
                {
                    ViewBag.mensage = "Esta zona no existe";
                    return RedirectToAction("Index", "Zona");
                }
            }
            return View();
        }

        [Authorize]
        public ActionResult EliminarZona(int id)
        {
            var model = db.AC_Zona.Find(id);
            if (model != null)
            {
                return View(model);
            }
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarZona(int id, AC_Zona zone)
        {
            zona = db.AC_Zona.Find(id);
            try
            {
                if (zona != null)
                {
                    db.AC_Zona.Remove(zona);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Zona");
                }
            } catch (Exception ex)
            {
                ViewBag.error = "No se pudo Eliminar";
                ViewBag.mensage = "Tiene Datos Ligados";
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