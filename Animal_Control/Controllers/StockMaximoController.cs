using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Animal_Control.Models;

namespace Animal_Control.Controllers
{
    public class StockMaximoController : Controller
    {
        public AnimalControl db = new AnimalControl();
        AC_Stock_Maximo stockMaximo = new AC_Stock_Maximo();
        // GET: Stock Maximo
        [Authorize]
        public ActionResult Index()
        {
            StringBuilder stock = new StringBuilder();
            stock.AppendLine("SELECT s.SMA_ID ID, a.Nombre Articulo, s.Cantidad " +
                                "from AC_Stock_Maximo s " +
                                "INNER JOIN AC_Articulo a ON "+
                                "s.SMA_ID = a.A_ID");
            var model = db.Database.SqlQuery<QueryStockMaximo>(stock.ToString()).ToList();
            return View(model);
        }

        public ActionResult Agregar()
        {
            var stock = db.AC_Articulo.ToList();
            SelectList list = new SelectList(stock, "A_ID", "Nombre");
            ViewBag.articulo = list;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(AC_Stock_Maximo s)
        {
            try
            {
                if (s != null)
                {
                    stockMaximo.ID_Articulo = s.ID_Articulo;
                    stockMaximo.Cantidad = s.Cantidad;
                    db.AC_Stock_Maximo.Add(stockMaximo);
                    db.SaveChanges();
                    return RedirectToAction("Index", "StockMaximo");
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

        public ActionResult Modificar(int id)
        {
            var stock = db.AC_Stock_Maximo.Find(id);
            return View(stock);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modificar(int id, AC_Stock_Maximo s)
        {
            stockMaximo = db.AC_Stock_Maximo.Find(id);
            if (stockMaximo != null)
            {
                try
                {
                    stockMaximo.Cantidad = s.Cantidad;
                    db.SaveChanges();
                    return RedirectToAction("Index", "StockMaximo");

                }
                catch (Exception ex)
                {
                    ViewBag.mensage = "No existe";
                    return View("Error");
                }
            }
            return View();
        }

        public ActionResult Eliminar(int id)
        {
            var model = db.AC_Stock_Maximo.Find(id);
            if (model != null)
            {
                return View(model);
            }
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(int id, AC_Stock_Maximo s)
        {
            try
            {
                stockMaximo = db.AC_Stock_Maximo.Find(id);
                if (stockMaximo != null)
                {
                    db.AC_Stock_Maximo.Remove(stockMaximo);
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