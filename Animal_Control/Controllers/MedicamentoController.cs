using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Animal_Control.Models;

namespace Animal_Control.Controllers
{
    public class MedicamentoController : Controller
    {
        public AnimalControl db = new AnimalControl();
        AC_Medicamento medicamento = new AC_Medicamento();

        // GET: Medicamento
        public ActionResult Index()
        {
            var model = db.AC_Medicamento.ToList();
            return View(model);
        }

        public ActionResult AgregarMedicamento()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarMedicamento(AC_Medicamento medicamentos)
        {
            try
            {
                if (medicamento != null)
                {
                    medicamento.Nombre = medicamentos.Nombre;
                    db.AC_Medicamento.Add(medicamento);
                    db.SaveChanges();
                    return RedirectToAction("Index","Medicamento");
                }
            }
            catch (Exception ex)
            {
                ViewBag.mensage = "No se pudo agregar medicamento";
                return View("Error");
            }
            return View();
        }

        public ActionResult ModificarMedicamento(int id)
        {
            var model = db.AC_Medicamento.Find(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModificarMedicamento(int id, AC_Medicamento model)
        {
            try
            {
                medicamento = db.AC_Medicamento.Find(id);
                if (medicamento != null)
                {
                    medicamento.Nombre = model.Nombre;
                    db.SaveChanges();
                    return RedirectToAction("Index", "Medicamento");
                }
            }
            catch (Exception ex)
            {
                ViewBag.error = "No se pudo modificar";
                ViewBag.mensage = "Este medicamento no existe";
                return View("Error");
            }
            return View(model.M_ID);
        }

        public ActionResult EliminarMedicamento(int id)
        {
            var model = db.AC_Medicamento.Find(id);
            if (model == null)
            {
                return RedirectToAction("Index", "Vacuna");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarMedicamento(int id, AC_Medicamento m)
        {
            try
            {
                medicamento = db.AC_Medicamento.Find(id);
                if (medicamento != null)
                {               
                     db.AC_Medicamento.Remove(medicamento);
                     db.SaveChanges();
                     return RedirectToAction("Index", "Medicamento");
                }                
            }catch (Exception ex)
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