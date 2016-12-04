using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Animal_Control.Models;
using System.Data.Entity;
using System.Text;

namespace Animal_Control.Controllers
{
    public class GastosController : Controller
    {

        public AnimalControl db = new AnimalControl();
        AC_Gastos gasto = new AC_Gastos();
        // GET: Gastos
        [Authorize]
        public ActionResult Index()
        {
            StringBuilder gastos = new StringBuilder();
            gastos.AppendLine("SELECT g.G_ID, " +
                                "a.Nombre Articulo, " +
                                "g.Costo, " +
                                "u.Nombre Usuario, " +
                                "g.Fecha " +
                                "FROM AC_Gastos g " +
                                "INNER JOIN AC_Articulo a ON g.ID_Articulo = a.A_ID " +
                                "INNER JOIN AC_Usuario u ON g.ID_Usuario = u.U_ID ");

            var model = db.Database.SqlQuery<QueryGastos>(gastos.ToString()).ToList();
            return View(model);
        }

        [Authorize]
        public ActionResult Agregar()
        {
            var Articulo = db.AC_Articulo.ToList();
            SelectList list = new SelectList(Articulo, "A_ID", "Nombre");
            ViewBag.articulo = list;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(AC_Gastos g)
        {
            try
            {
                if (g != null)
                {
                    AC_Usuario userLog = db.AC_Usuario.SingleOrDefault(x => x.Correo == User.Identity.Name);
                    gasto.ID_Articulo = g.ID_Articulo;
                    gasto.Costo = g.Costo;
                    gasto.ID_Usuario = userLog.U_ID;
                    gasto.Fecha = DateTime.Now;
                    db.AC_Gastos.Add(gasto);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Gastos");
                }
                else
                {
                    ViewBag.mensage = "Ingrese los datos requeridos";
                }
            }
            catch(Exception ex)
            {

            }
            return View();
        }

        [Authorize]
        public ActionResult Modificar(int id)
        {
            var gasto = db.AC_Gastos.Find(id);
            return View(gasto);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modificar(int id, AC_Gastos g)
        {
            gasto = db.AC_Gastos.Find(id);
            if (gasto != null)
            {
                try
                {
                    gasto.Costo = g.Costo;
                    db.SaveChanges();
                    return RedirectToAction("Index", "Gastos");

                }
                catch (Exception ex)
                {
                    ViewBag.mensage = "Este Gasto no existe";
                    return View("Error");
                }
            }
            return View();
        }

        [Authorize]
        public ActionResult Eliminar(int id)
        {
            var model = db.AC_Gastos.Find(id);
            if (model != null)
            {
                return View(model);
            }
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(int id, QueryGastos gastos)
        {
            try
            {
                gasto = db.AC_Gastos.Find(id);
                if (gasto != null)
                {
                    db.AC_Gastos.Remove(gasto);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Gastos");
                }
                else
                {
                    ViewBag.mensage = "No existe ese gasto, Ingrese un valor valido";
                    return View("Error");
                }
            }
            catch (Exception ex)
            {
                ViewBag.mensage = "No se pudo eliminar";
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