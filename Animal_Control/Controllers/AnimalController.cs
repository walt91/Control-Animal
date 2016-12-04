using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Animal_Control.Models;

namespace Animal_Control.Controllers
{
    public class AnimalController : Controller
    {
        public AnimalControl db = new AnimalControl();
        AC_Animal animal = new AC_Animal();
        // GET: Animal
        [Authorize]
        public ActionResult Index()
        {
            var model = db.AC_Animal.ToList();
            AC_Usuario userLog = db.AC_Usuario.SingleOrDefault(x => x.Correo == User.Identity.Name);
            ViewBag.Usuario = userLog.Nombre;
            return View(model);
        }
        [Authorize]
        public ActionResult AgregarAnimal()
        {
            try
            {
                var zona = db.AC_Zona.ToList();
                SelectList listzona = new SelectList(zona, "ID", "Nombre");
                ViewBag.zona = listzona;
                var daño = db.AC_Daño.ToList();
                SelectList listDaño = new SelectList(daño, "D_ID", "Nombre");
                ViewBag.daño = listDaño;
                var personaReporta = db.AC_Persona_Reporta.ToList();
                SelectList listaPersonaReporta = new SelectList(personaReporta, "PR_ID", "Nombre");
                ViewBag.personaReporta = listaPersonaReporta;
                if (listzona.Count() == 0)
                {
                    ViewBag.error = "No se puede agregar un animal todavia";
                    ViewBag.mensage = "Agregue una zona primero";
                    return View("Error");
                }
                else if (listDaño.Count() == 0)
                {
                    ViewBag.error = "No se puede agregar un animal todavia";
                    ViewBag.mensage = "Agregue un daño primero";
                    return View("Error");
                }
                else if (listaPersonaReporta.Count() == 0)
                {
                    ViewBag.error = "No se puede agregar un animal todavia";
                    ViewBag.mensage = "Agregue una persona primero";
                    return View("Error");
                }
            }
            catch (Exception ex)
            {
                ViewBag.mensage = "Error de Conexion";
            }
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarAnimal(AC_Animal a)
        {
            
            try
            {
                AC_Usuario userLog = db.AC_Usuario.SingleOrDefault(x => x.Correo == User.Identity.Name);
                animal.Especie = a.Especie;
                animal.Edad = a.Edad;
                animal.Sexo = a.Sexo;
                animal.Peso = a.Peso;
                animal.Temperamento = a.Temperamento;
                animal.Temperatura = a.Temperatura;
                animal.Frecuencia_Cardiaca = a.Frecuencia_Cardiaca;
                animal.Frecuencia_Respiratoria = a.Frecuencia_Respiratoria;
                animal.Comentario = a.Comentario;
                animal.Coloracion_Mucosa = a.Coloracion_Mucosa;
                animal.Condicion = a.Condicion;
                animal.ID_Usuario = userLog.U_ID;
                animal.ID_Daño = a.ID_Daño;
                animal.ID_Zona = a.ID_Zona;
                animal.Fecha = DateTime.Now;
                animal.ID_Persona_Reporta = a.ID_Persona_Reporta;
                db.AC_Animal.Add(animal);
                db.SaveChanges();
                ViewBag.mensage = "Animal Registrado";
                return RedirectToAction("Index", "Animal");
            }
            catch (Exception ex)
            {
                ViewBag.mensage = "No se pudó Agregar";
                return RedirectToAction("Error");
            }
        
            return View();
}
        [Authorize]
        public ActionResult ModificarAnimal(int id)
        {
            var model = db.AC_Animal.Find(id);
            if (model != null)
            {
                try
                {
                    var zona = db.AC_Zona.ToList();
                    SelectList listzona = new SelectList(zona, "ID", "Nombre");
                    ViewBag.zona = listzona;
                    var daño = db.AC_Daño.ToList();
                    SelectList listDaño = new SelectList(daño, "D_ID", "Nombre");
                    ViewBag.daño = listDaño;
                    var personaReporta = db.AC_Persona_Reporta.ToList();
                    SelectList listaPersonaReporta = new SelectList(personaReporta, "PR_ID", "Nombre");
                    ViewBag.personaReporta = listaPersonaReporta;
                }
                catch (Exception ex) {                   
                    ViewBag.mensage = "No se puede modificar";
                    return View("Error");
                }
            }
            else
            {
                ViewBag.mensage = "Ese animal no existe";
                return RedirectToAction("Index", "Animal");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModificarAnimal(AC_Animal a)
        {
            var animal = db.AC_Animal.Find(a.ID);
            if (animal != null)
            {
                try
                {
                    AC_Usuario userLog = db.AC_Usuario.SingleOrDefault(x => x.Correo == User.Identity.Name);
                    animal.Especie = a.Especie;
                    animal.Edad = a.Edad;
                    animal.Sexo = a.Sexo;
                    animal.Peso = a.Peso;
                    animal.Temperamento = a.Temperamento;
                    animal.Temperatura = a.Temperatura;
                    animal.Frecuencia_Cardiaca = a.Frecuencia_Cardiaca;
                    animal.Frecuencia_Respiratoria = a.Frecuencia_Respiratoria;
                    animal.Comentario = a.Comentario;
                    animal.Coloracion_Mucosa = a.Coloracion_Mucosa;
                    animal.Condicion = a.Condicion;
                    animal.ID_Daño = a.ID_Daño;
                    animal.ID_Zona = a.ID_Zona;
                    animal.ID_Persona_Reporta = a.ID_Persona_Reporta;
                    db.SaveChanges();
                    return RedirectToAction("Index", "Animal");
                }
                catch (Exception ex)
                {
                    ViewBag.mensage = "No se pude modificar";
                    return RedirectToAction("Index", "Animal");
                }
            }
            else
            {
                ViewBag.mensage = "Ese animal no existe";
                return RedirectToAction("Index", "Animal");
            }
            return View();
        }

        [Authorize]
        public ActionResult EliminarAnimal(int id)
        {
            var model = db.AC_Animal.Find(id);
            if (model == null)
            {
                return RedirectToAction("Index", "Animal");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarAnimal(int id, AC_Animal a)
        {
            var model = db.AC_Animal.Find(id);
            if (model != null)
            {
                try
                {
                    db.AC_Animal.Remove(model);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Animal");
                }
                catch (Exception ex)
                {
                    ViewBag.error = "No se pudo eliminar";
                    ViewBag.mensage = "Posee datos Ligados a este registro";
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