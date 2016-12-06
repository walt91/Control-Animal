using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Animal_Control.Models;

namespace Animal_Control.Controllers
{
    public class VacunaController : Controller
    {
        public AnimalControl db = new AnimalControl();
        AC_Vacuna vacuna = new AC_Vacuna();

        // GET: Vacuna
        [Authorize]
        public ActionResult Index()
        {
            var model = db.AC_Vacuna.ToList();
            return View(model);
        }

        [Authorize]
        public ActionResult AgregarVacuna()
        {
            return View();
        }

        //POST : Agregar una Vacuna
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarVacuna(AC_Vacuna a)
        {
            if (a != null)
            {
                try
                {
                    vacuna.Nombre = a.Nombre;
                    db.AC_Vacuna.Add(vacuna);
                    db.SaveChanges();
                    RedirectToAction("Index", "Articulo");
                }
                catch (Exception ex)
                {
                    ViewBag.error = "No se pudo Agregar";
                    ViewBag.mensage = "Faltan Datos";
                    return View("Error");
                }
            }
            return View();
        }

        [Authorize]
        public ActionResult ModificarVacuna(int id)
        {
            var vacuna = db.AC_Vacuna.Find();
            if (vacuna == null)
            {
                return RedirectToAction("Index", "Vacuna");
            }
            return View(vacuna);
        }

        //POST : Modificar una Vacuna
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModificarVacuna( AC_Vacuna v)
        {
            try
            {
                var vacuna = db.AC_Articulo.Find(v.ID);
                if (vacuna != null)
                {
                
                     vacuna.Nombre = v.Nombre;
                     db.SaveChanges();
                     return RedirectToAction("Index", "Vacuna");
                }
            }
            catch (Exception ex)
            {
                ViewBag.error = "No se pudo modificar";
                 ViewBag.mensage = "Este vacuna no existe";
                 return View("Error");
            }
            return View();
        }
        
        [Authorize]
        public ActionResult EliminarVacuna(int id)
        {
            var model = db.AC_Vacuna.Find(id);
            if (model == null)
            {
                return RedirectToAction("Index", "Vacuna");
            }
            return View(model);
        }

        //POST : Eliminar una Vacuna
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(int id, AC_Vacuna a)
        {
            var vacuna = db.AC_Vacuna.Find(id);
            if (vacuna != null)
            {
                try
                {
                    db.AC_Vacuna.Remove(vacuna);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Vacuna");
                }
                catch (Exception ex)
                {
                    ViewBag.error = "No se pudo eliminar este registro";
                    ViewBag.mensage = "Tiene Datos ligados a este registro";
                    return View("Error");
                }
            }
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}