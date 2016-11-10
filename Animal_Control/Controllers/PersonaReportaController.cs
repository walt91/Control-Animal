using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Animal_Control.Models;

namespace Animal_Control.Controllers
{
    public class PersonaReportaController : Controller
    {
        public AnimalControl db = new AnimalControl();
        AC_Persona_Reporta PReporta = new AC_Persona_Reporta();

        // GET: PersonaReporta
        public ActionResult Index()
        {
            var model = db.AC_Persona_Reporta.ToList();
            return View(model);
        }

        public ActionResult AgregarPersona()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarPersona(AC_Persona_Reporta persona)
        {
            try
            {
                if (persona != null)
                {
                    PReporta.Nombre = persona.Nombre;
                    PReporta.Cedula = persona.Cedula;
                    PReporta.Telefono = persona.Telefono;
                    db.AC_Persona_Reporta.Add(PReporta);
                    db.SaveChanges();
                    return RedirectToAction("Index", "PersonaReporta");
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

        public ActionResult ModificarPersona(int id)
        {
            PReporta = db.AC_Persona_Reporta.Find(id);
            return View(PReporta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModificarPersona(int id, AC_Persona_Reporta usuario)
        {
            PReporta = db.AC_Persona_Reporta.Find(id);
            if (PReporta != null)
            {
                try
                {
                    PReporta.Nombre = usuario.Nombre;
                    PReporta.Cedula = usuario.Cedula;
                    PReporta.Telefono = usuario.Telefono;
                    db.SaveChanges();
                    return RedirectToAction("Index", "PersonaReporta");
                }
                catch (Exception ex)
                {
                    ViewBag.mensage = "Este usuario no existe";
                    return RedirectToAction("Index", "PersonaReporta");
                }
            }
            return View();
        }

        public ActionResult EliminarPersona(int id)
        {
            var model = db.AC_Persona_Reporta.Find(id);
            if (model != null)
            {
                return View(model);
            }
            return View("Index");
        }

        [HttpPost]
        public ActionResult EliminarPersona(int id, AC_Usuario usuario)
        {
            try
            {
                PReporta = db.AC_Persona_Reporta.Find(id);
                if (PReporta != null)
                {
                    db.AC_Persona_Reporta.Remove(PReporta);
                    db.SaveChanges();
                    return RedirectToAction("Index", "PersonaReporta");
                }
                else
                {
                    ViewBag.mensage = "No existe esta persona, Ingrese un valor valido";
                    return View("Error");
                }
            }
            catch (Exception ex)
            {
                ViewBag.mensage = "No se puede eliminar este usuario, tiene datos ligados a el";
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