using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Animal_Control.Models;

namespace Animal_Control.Controllers
{
    public class LiberacionController : Controller
    {
        public AnimalControl db = new AnimalControl();
        AC_Liberacion liberado = new AC_Liberacion();

        // GET: Liberacion
        [Authorize]
        public ActionResult Index()
        {
            var model = db.AC_Liberacion.ToList();
            AC_Usuario userLog = db.AC_Usuario.SingleOrDefault(x => x.Correo == User.Identity.Name);
            ViewBag.Usuario = userLog.Nombre;
            return View(model);
        }

        [Authorize]
        public ActionResult AgregarLiberacion()
        {
            try
            {
                var zona = db.AC_Zona.ToList();
                SelectList listzona = new SelectList(zona, "ID", "Nombre");
                ViewBag.zona = listzona;
                var daño = db.AC_Daño.ToList();
                SelectList listDaño = new SelectList(daño, "D_ID", "Nombre");
                ViewBag.daño = listDaño;
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
            }
            catch (Exception ex)
            {
                ViewBag.mensage = "Error de Conexion";
            }
            return View();
        }

        //POST : Agregar liberacion
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarLiberacion(AC_Liberacion l)
        {
            try
            {
                AC_Usuario userLog = db.AC_Usuario.SingleOrDefault(x => x.Correo == User.Identity.Name);
                liberado.Especie = l.Especie;
                liberado.Edad = l.Edad;
                liberado.Sexo = l.Sexo;
                liberado.Peso = l.Peso;
                liberado.Temperamento = l.Temperamento;
                liberado.Temperatura = l.Temperatura;
                liberado.Frecuencia_Cardiaca = l.Frecuencia_Cardiaca;
                liberado.Frecuencia_Respiratoria = l.Frecuencia_Respiratoria;
                liberado.Comentario = l.Comentario;
                liberado.Coloracion_Mucosa = l.Coloracion_Mucosa;
                liberado.Condicion = l.Condicion;
                liberado.ID_Usuario = userLog.U_ID;
                liberado.ID_Daño = l.ID_Daño;
                liberado.ID_Zona = l.ID_Zona;
                liberado.Fecha = DateTime.Now;
                db.AC_Liberacion.Add(liberado);
                db.SaveChanges();
                return RedirectToAction("Index", "Liberacion");
            }
            catch (Exception ex)
            {
                ViewBag.mensage = "No se pude modificar";
                return RedirectToAction("Error");
            }

            return View();
        }

        [Authorize]
        public ActionResult ModificarLiberacion(int id)
        {
            var model = db.AC_Liberacion.Find(id);
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
                }
                catch (Exception ex)
                {
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

        //POST : Modificar Liberacion
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModificarLiberacion(int id, AC_Liberacion L)
        {
            var liberado = db.AC_Liberacion.Find(id);
            if (liberado != null)
            {
                try
                {
                    liberado.Especie = L.Especie;
                    liberado.Edad = L.Edad;
                    liberado.Sexo = L.Sexo;
                    liberado.Peso = L.Peso;
                    liberado.Temperamento = L.Temperamento;
                    liberado.Temperatura = L.Temperatura;
                    liberado.Frecuencia_Cardiaca = L.Frecuencia_Cardiaca;
                    liberado.Frecuencia_Respiratoria = L.Frecuencia_Respiratoria;
                    liberado.Comentario = L.Comentario;
                    liberado.Coloracion_Mucosa = L.Coloracion_Mucosa;
                    liberado.Condicion = L.Condicion;
                    liberado.ID_Daño = L.ID_Daño;
                    liberado.ID_Zona = L.ID_Zona;
                    db.SaveChanges();
                    return RedirectToAction("Index", "Liberacion");
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
        public ActionResult EliminarLiberacion(int id)
        {
            var model = db.AC_Liberacion.Find(id);
            if (model == null)
            {
                return RedirectToAction("Index", "Liberacion");
            }
            return View(model);
        }

        //POST : Eliminar Liberacion
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarLiberacion(int id, AC_Liberacion l)
        {
            var model = db.AC_Animal.Find(id);
            if (model != null)
            {
                try
                {
                    db.AC_Animal.Remove(model);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Liberacion");
                }
                catch (Exception ex)
                {
                    ViewBag.mensage = "No se pudo eliminar";
                    return View ("Error");
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