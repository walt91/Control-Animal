using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Animal_Control.Models;
using System.Text;

namespace Animal_Control.Controllers
{
    public class StockMinimoController : Controller
    {
        public AnimalControl db = new AnimalControl();
        AC_Stock_Minimo stockMinimo = new AC_Stock_Minimo();
        // GET: Gastos
        [Authorize]
        public ActionResult Index()
        {
            StringBuilder stock = new StringBuilder();
            stock.AppendLine("SELECT s.SMI_ID ID, a.Nombre Articulo, s.Cantidad " +
                                "from AC_Stock_Minimo s " +
                                "INNER JOIN AC_Articulo a ON " +
                                "s.SMI_ID = a.A_ID");
            var model = db.Database.SqlQuery<QueryStockMinimo>(stock.ToString()).ToList();
            return View(model);
        }

        [Authorize]
        public ActionResult Agregar()
        {
            var stock = db.AC_Articulo.ToList();
            SelectList list = new SelectList(stock, "A_ID", "Nombre");
            ViewBag.articulo = list;
            return View();
        }

        //POST : Agregar Stock Minimo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(AC_Stock_Minimo s)
        {
            try
            {
                if (s != null)
                {
                    stockMinimo.ID_Articulo = s.ID_Articulo;
                    stockMinimo.Cantidad = s.Cantidad;
                    db.AC_Stock_Minimo.Add(stockMinimo);
                    db.SaveChanges();
                    return RedirectToAction("Index", "StockMinimo");
                }
                else
                {
                    ViewBag.mensage = "Ingrese los datos requeridos";
                }
            }
            catch (Exception ex)
            {
                ViewBag.error = "Ya existe un Stock Minimo para este articulo";
                return View("Error");
            }
            return View();
        }

        [Authorize]
        public ActionResult Modificar(int id)
        {
            var stock = db.AC_Stock_Minimo.Find(id);
            return View(stock);
        }

        //POST : Modificar Stock Minimo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modificar(int id, AC_Stock_Maximo s)
        {
            stockMinimo = db.AC_Stock_Minimo.Find(id);
            if (stockMinimo != null)
            {
                try
                {
                    stockMinimo.Cantidad = s.Cantidad;
                    db.SaveChanges();
                    return RedirectToAction("Index", "StockMinimo");

                }
                catch (Exception ex)
                {
                    ViewBag.mensage = "No existe";
                    return View("Error");
                }
            }
            return View();
        }

        [Authorize]
        public ActionResult Eliminar(int id)
        {
            var model = db.AC_Stock_Minimo.Find(id);
            if (model != null)
            {
                return View(model);
            }
            return View("Index");
        }

        //POST : Eliminar Stock Minimo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(int id, AC_Stock_Maximo s)
        {
            try
            {
                stockMinimo = db.AC_Stock_Minimo.Find(id);
                if (stockMinimo != null)
                {
                    db.AC_Stock_Minimo.Remove(stockMinimo);
                    db.SaveChanges();
                    return RedirectToAction("Index", "StockMaximo");
                }
                else
                {
                    ViewBag.mensage = "No existe, Ingrese un valor valido";
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