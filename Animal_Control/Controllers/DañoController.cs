using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Animal_Control.Models;
using System.Data.Entity;

namespace Animal_Control.Controllers
{
    public class DañoController : Controller
    {
        public AnimalControl db = new AnimalControl();
        AC_Daño daño = new AC_Daño();

        // GET: Daño
        [Authorize]
        public ActionResult Index()
        {
            var daño = db.AC_Daño.ToList();
            return View(daño);
        }

        [Authorize]
        public ActionResult AgregarDaño()
        {
            return View();
        }

        //Se agrega un nuevo daño
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarDaño(AC_Daño d)
        {
            try
            {
                if (d != null)
                {
                    daño.Nombre = d.Nombre;
                    db.AC_Daño.Add(daño);
                    db.SaveChanges();
                    return RedirectToAction("Index","Daño");
                }
            }
            catch (Exception ex)
            {
                ViewBag.mesage = "No se pudo agregar daño";
            }
            return View();
        }

        [Authorize]
        public ActionResult ModificarDaño(int id)
        {
            try
            {
                daño = db.AC_Daño.Find(id);
                if (daño == null)
                {
                    ViewBag.mesage = "No existe";
                    return View("Error");
                }
            }
            catch (Exception ex)
            {

            }
            return View(daño);
        }

        //Se modifica un nuevo daño
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModificarDaño(AC_Daño d)
        {
            try
            {
                daño = db.AC_Daño.Find(d.D_Id);
                if (daño != null)
                {
                    daño.Nombre = d.Nombre;
                    db.SaveChanges();
                    return RedirectToAction("Index", "Daño");
                }
            }
            catch (Exception ex)
            {
                ViewBag.error = "No se pudo modificar";
                return View("Error");
            }
            return View(daño);
        }

        [Authorize]
        public ActionResult EliminarDaño(int id)
        {
            var model = db.AC_Daño.Find(id);
            if (model != null)
            {
                return View(model);
            }
            return View("Index");
        }

        //Se elimina un daño
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarDaño(int id, AC_Daño d)
        {
            daño = db.AC_Daño.Find(id);
            try
            {
                if (daño != null)
                {
                    db.AC_Daño.Remove(daño);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Daño");
                }
                else
                {
                    ViewBag.mensage = "No existe ese daño, Ingrese un valor valido";
                    return View("Error");
                }
            }
            catch (Exception ex)
            {
                ViewBag.error = "No se pudo Eliminar";
                ViewBag.mensage = "No se puede eliminar este daño, tiene datos ligados";
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