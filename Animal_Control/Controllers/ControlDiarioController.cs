using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Animal_Control.Models;
using System.Text;

namespace Animal_Control.Controllers
{
    public class ControlDiarioController : Controller
    {

        public AnimalControl db = new AnimalControl();
        AC_Control_Diario controlDiario = new AC_Control_Diario();
        // GET: ControlDiario
        [Authorize]
        public ActionResult Index()
        {
            StringBuilder gastos = new StringBuilder();
            gastos.AppendLine("SELECT c.CD_ID ID, " +
                                "a.Especie Animal, " +
                                "u.Nombre Usuario, " +
                                "c.Comentario, " +
                                "c.Fecha " +
                                "FROM AC_Control_Diario c " +
                                "INNER JOIN AC_Animal a ON c.ID_Animal = a.ID " +
                                "INNER JOIN AC_Usuario u ON c.ID_Usuario = u.U_ID ");

            var model = db.Database.SqlQuery<QueryControlDiario>(gastos.ToString()).ToList();
            return View(model);
        }

        [Authorize]
        public ActionResult AgregarControl_Diario()
        {
            var animal = db.AC_Animal.ToList();
            SelectList listAnimal = new SelectList(animal, "ID", "Especie");
            ViewBag.animal = listAnimal;
            var medicamento = db.AC_Medicamento.ToList();
            SelectList listMedicamento = new SelectList(medicamento, "M_ID", "Nombre");
            ViewBag.medicamento = listMedicamento;
            var vacuna = db.AC_Vacuna.ToList();
            SelectList listaVacuna = new SelectList(vacuna, "ID", "Nombre");
            ViewBag.vacunas = listaVacuna;
            if (listAnimal.Count() == 0)
            {
                ViewBag.error = "No se puede agregar un control todavia";
                ViewBag.mensage = "Agregue un animal primero";
                return View("Error");
            }
            else if (listaVacuna.Count() == 0)
            {
                ViewBag.error = "No se puede agregar un control todavia";
                ViewBag.mensage = "Agregue una vacuna primero";
                return View("Error");
            }
            else if (listMedicamento.Count() == 0)
            {
                ViewBag.error = "No se puede agregar un control todavia";
                ViewBag.mensage = "Agregue un medicamento primero";
                return View("Error");
            }
            return View();
        }

        //Se agrega un nuevo control diario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarControl_Diario(AC_Control_Diario control)
        {
            try
            {
                if (control != null)
                {
                    AC_Usuario userLog = db.AC_Usuario.SingleOrDefault(x => x.Correo == User.Identity.Name);
                    controlDiario.ID_Animal = control.ID_Animal;
                    controlDiario.ID_Usuario = userLog.U_ID;
                    controlDiario.Comentario = control.Comentario;
                    controlDiario.Fecha = DateTime.Now;
                    controlDiario.ID_Medicamento = control.ID_Medicamento;
                    controlDiario.ID_Vacuna = control.ID_Vacuna;
                    db.AC_Control_Diario.Add(controlDiario);
                    db.SaveChanges();
                    return RedirectToAction("Index","ControlDiario");
                }
            }
            catch (Exception ex)
            {
                ViewBag.errot = "No se pudo agregar";
                return View("Error");
            }
            return View();
        }

        [Authorize]
        public ActionResult ModificarControl_Diario(int id)
        {
            var animal = db.AC_Animal.ToList();
            SelectList listAnimal = new SelectList(animal, "ID", "Especie");
            ViewBag.animal = listAnimal;
            var medicamento = db.AC_Medicamento.ToList();
            SelectList listMedicamento = new SelectList(medicamento, "M_ID", "Nombre");
            ViewBag.medicamento = listMedicamento;
            var vacuna = db.AC_Vacuna.ToList();
            SelectList listaVacuna = new SelectList(vacuna, "ID", "Nombre");
            ViewBag.vacunas = listaVacuna;
            return View();
        }

        //Se modifica un control diario animal
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModificarControl_Diario(int id, AC_Control_Diario control)
        {
            try
            {
                if (control != null)
                {
                    controlDiario.ID_Animal = control.ID_Animal;
                    controlDiario.Comentario = control.Comentario;
                    controlDiario.Fecha = DateTime.Now;
                    controlDiario.ID_Medicamento = control.ID_Medicamento;
                    controlDiario.ID_Vacuna = control.ID_Vacuna;
                    db.SaveChanges();
                    return RedirectToAction("Index", "ControlDiario");
                }
            }
            catch (Exception ex)
            {
                ViewBag.errot = "No se pudo agregar";
                return View("Error");
            }
            return View();
        }

        [Authorize]
        public ActionResult AplicarVacuna()
        {
            var animal = db.AC_Animal.ToList();
            SelectList listAnimal = new SelectList(animal, "ID", "Especie");
            ViewBag.animal = listAnimal;
            var vacuna = db.AC_Vacuna.ToList();
            SelectList listaVacuna = new SelectList(vacuna, "ID", "Nombre");
            ViewBag.vacunas = listaVacuna;
            if (listAnimal.Count() == 0)
            {
                ViewBag.error = "No se puede agregar un control todavia";
                ViewBag.mensage = "Agregue un animal primero";
                return View("Error");
            }
            else if (listaVacuna.Count() == 0)
            {
                ViewBag.error = "No se puede agregar un control todavia";
                ViewBag.mensage = "Agregue una vacuna primero";
                return View("Error");
            }
            return View();
        }

        //Se aplica una nueva vacuna
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AplicarVacuna(AC_Control_Diario vacuna)
        {
            try
            {
                if (vacuna != null)
                {
                    AC_Usuario userLog = db.AC_Usuario.SingleOrDefault(x => x.Correo == User.Identity.Name);
                    controlDiario.ID_Animal = vacuna.ID_Animal;
                    controlDiario.ID_Usuario = userLog.U_ID;
                    controlDiario.Comentario = vacuna.Comentario;
                    controlDiario.Fecha = DateTime.Now;
                    controlDiario.ID_Vacuna = vacuna.ID_Vacuna;
                    db.AC_Control_Diario.Add(controlDiario);
                    db.SaveChanges();
                    return RedirectToAction("Index", "ControlDiario");
                }
            }
            catch (Exception ex)
            {
                return View("Error");
            }
            return View();
        }

        [Authorize]
        public ActionResult AplicarMedicamento()
        {
            var animal = db.AC_Animal.ToList();
            SelectList listAnimal = new SelectList(animal, "ID", "Especie");
            ViewBag.animal = listAnimal;
            var medicamento = db.AC_Medicamento.ToList();
            SelectList listMedicamento = new SelectList(medicamento, "M_ID", "Nombre");
            ViewBag.medicamento = listMedicamento;
            if (listAnimal.Count() == 0)
            {
                ViewBag.error = "No se puede agregar un control todavia";
                ViewBag.mensage = "Agregue un animal primero";
                return View("Error");
            }
            else if (listMedicamento.Count() == 0)
            {
                ViewBag.error = "No se puede agregar un control todavia";
                ViewBag.mensage = "Agregue un medicamento primero";
                return View("Error");
            }
            return View();
        }

        //Se aplica un medicamento
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AplicarMedicamento(AC_Control_Diario medicamento)
        {
            try
            {
                if (medicamento != null)
                {
                    AC_Usuario userLog = db.AC_Usuario.SingleOrDefault(x => x.Correo == User.Identity.Name);
                    controlDiario.ID_Animal = medicamento.ID_Animal;
                    controlDiario.ID_Usuario = userLog.U_ID;
                    controlDiario.Comentario = medicamento.Comentario;
                    controlDiario.Fecha = DateTime.Now;
                    controlDiario.ID_Medicamento = medicamento.ID_Medicamento;
                    db.AC_Control_Diario.Add(controlDiario);
                    db.SaveChanges();
                    return RedirectToAction("Index", "ControlDiario");
                }
            }
            catch (Exception ex)
            {
                return View("Error");
            }
            return View();
        }

        [Authorize]
        public ActionResult EliminarControl_Diario(int id)
        {
            controlDiario = db.AC_Control_Diario.Find(id);
            return View(controlDiario);
        }

        //Se elimina un control diario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarControl_Diario(int id, AC_Control_Diario a)
        {
            try
            {
                controlDiario = db.AC_Control_Diario.Find(id);
                db.AC_Control_Diario.Remove(controlDiario);
                db.SaveChanges(); 
            }
            catch(Exception ex)
            {
                ViewBag.error = "No se pudo Eliminar";
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