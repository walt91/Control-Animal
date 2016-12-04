using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Animal_Control.Models;
using System.Text;

namespace Animal_Control.Controllers
{
    public class IngresosController : Controller
    {

        private AnimalControl db = new AnimalControl();
        AC_Ingresos ingresos = new AC_Ingresos();

        // GET: Ingresos
        [Authorize]
        public ActionResult Index()
        {
            StringBuilder ingresos = new StringBuilder();
            ingresos.AppendLine("SELECT i.I_ID, " +
                                "i.Dinero, " +
                                "u.Nombre Usuario, " +
                                "i.Comentario, " +
                                "i.Fecha " +
                                "FROM AC_Ingresos i " +
                                "INNER JOIN AC_Usuario u ON i.ID_Usuario = u.U_ID ");

            var model = db.Database.SqlQuery<QueryIngresos>(ingresos.ToString()).ToList();
            return View(model);
        }

        // Cargar vista para agregar Ingresos
        [Authorize]
        public ActionResult AgregarIngresos()
        {
            var Articulo = db.AC_Articulo.ToList();
            SelectList list = new SelectList(Articulo, "A_ID", "Nombre");
            ViewBag.articulo = list;
            var usuario = db.AC_Usuario.ToList();
            SelectList listUser = new SelectList(usuario, "U_ID", "Nombre");
            ViewBag.usuario = listUser;
            return View();
        }

        // POST : Agregar nuevo Ingreso
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarIngresos(AC_Ingresos ingreso)
        {
            try
            {
                if (ingreso != null)
                {
                    ingresos.Dinero = ingreso.Dinero;
                    ingresos.ID_Usuario = ingreso.ID_Usuario;
                    ingresos.Comentario = ingreso.Comentario;
                    ingresos.Fecha = DateTime.Now;
                    db.AC_Ingresos.Add(ingresos);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Ingresos");
                }
            }
            catch (Exception ex)
            {
                ViewBag.mensage = "Ingrese los datos requeridos";
                return View("Error");
            }
            return View();
        }

        // Cargar Vista para modificar Ingresos
        [Authorize]
        public ActionResult ModificarIngresos(int id)
        {
            var ingreso = db.AC_Ingresos.Find(id);
            return View(ingreso);
        }

        // POST : Modificar Ingreso
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModificarIngresos(int id, AC_Ingresos ingreso)
        {
            ingresos = db.AC_Ingresos.Find(id);
            if (ingresos != null)
            {
                try
                {
                    ingresos.Dinero = ingreso.Dinero;
                    ingresos.Comentario = ingreso.Comentario;
                    db.SaveChanges();
                    return RedirectToAction("Index", "Ingresos");
                }
                catch (Exception ex)
                {
                    ViewBag.mensage = "Este Ingreso no existe";
                    return View("Error");
                }
            }
            return View();
        }

        // Cargar vista para eliminar ingreso
        [Authorize]
        public ActionResult EliminarIngresos(int id)
        {
            var model = db.AC_Ingresos.Find(id);
            if (model == null)
            {
                return RedirectToAction("Index","Ingresos");              
            }
            return View(model);
        }

        // POST : Eliminar Ingreso
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarIngresos(int id, QueryIngresos ingreso)
        {
            try
            {
                ingresos = db.AC_Ingresos.Find(id);
                if (ingresos != null)
                {
                    db.AC_Ingresos.Remove(ingresos);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Ingresos");
                }
            }
            catch (Exception ex)
            {
                ViewBag.error = "No se pudo eliminar este ingreso";
                ViewBag.mensage = "No existe ese Ingreso, Ingrese un valor valido";
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