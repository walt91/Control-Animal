using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Animal_Control.Models;
using System.Text;
using System.Text.RegularExpressions;
using Rotativa;

namespace Animal_Control.Controllers
{
    public class ReportesController : Controller
    {
        AnimalControl db = new AnimalControl(); 

        // GET: Reportes
        public ActionResult ReporteGasto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PDFGasto(QueryFechas rango)
        {
            var date1 = rango.fecha1.ToString();
            var date2 = rango.fecha2.ToString();
            try
            {
                date1 = Regex.Replace(date1, "/ a . m", "", RegexOptions.None, TimeSpan.FromSeconds(2.5));
                date2 = Regex.Replace(date2, "/ a . m", "", RegexOptions.None, TimeSpan.FromSeconds(2.5));
            }
            catch (RegexMatchTimeoutException)
            {
                return RedirectToAction("Error", "Reportes"); 
            }
            StringBuilder gastos = new StringBuilder();
            gastos.AppendLine("SELECT g.G_ID, " +
                                "a.Nombre Articulo, " +
                                "g.Costo, " +
                                "u.Nombre Usuario, " +
                                "g.Fecha " +
                                "FROM AC_Gastos g " +
                                "INNER JOIN AC_Articulo a ON g.ID_Articulo = a.A_ID " +
                                "INNER JOIN AC_Usuario u ON g.ID_Usuario = u.U_ID " +
                                "WHERE g.Fecha BETWEEN " + date1 + " AND " + date2);

            var model = db.Database.SqlQuery<QueryGastos>(gastos.ToString()).ToList();
            return View(model);
        }
        public ActionResult DescargarPDFGasto(string fecha1, string fecha2)
        {
            var date1 = "";
            var date2 = "";
            try
            {
                date1 = Regex.Replace(fecha1, "-", "", RegexOptions.None, TimeSpan.FromSeconds(2.5));
                date2 = Regex.Replace(fecha2, "-", "", RegexOptions.None, TimeSpan.FromSeconds(2.5));
            }
            catch (RegexMatchTimeoutException)
            {
                return RedirectToAction("Error", "Reportes");
            }
            StringBuilder gastos = new StringBuilder();
            gastos.AppendLine("SELECT g.G_ID, " +
                                "a.Nombre Articulo, " +
                                "g.Costo, " +
                                "u.Nombre Usuario, " +
                                "g.Fecha " +
                                "FROM AC_Gastos g " +
                                "INNER JOIN AC_Articulo a ON g.ID_Articulo = a.A_ID " +
                                "INNER JOIN AC_Usuario u ON g.ID_Usuario = u.U_ID " +
                                "WHERE g.Fecha BETWEEN " + date1 + " AND " + date2);

            var model = db.Database.SqlQuery<QueryGastos>(gastos.ToString()).ToList();
            return View(model);
        }



        public ActionResult ReporteIngreso()
        {
            return View();
        }

        public ActionResult PDFIngreso(string fecha1, string fecha2)
        {
            var date1 = "";
            var date2 = "";
            try
            {
                date1 = Regex.Replace(fecha1, "-", "", RegexOptions.None, TimeSpan.FromSeconds(2.5));
                date2 = Regex.Replace(fecha2, "-", "", RegexOptions.None, TimeSpan.FromSeconds(2.5));
            }
            catch (RegexMatchTimeoutException)
            {
                return RedirectToAction("Error", "Reportes");
            }

            StringBuilder gastos = new StringBuilder();
            gastos.AppendLine("SELECT g.G_ID, " +
                                "a.Nombre Articulo, " +
                                "g.Costo, " +
                                "u.Nombre Usuario, " +
                                "g.Fecha " +
                                "FROM AC_Ingresos g " +
                                "INNER JOIN AC_Articulo a ON g.ID_Articulo = a.A_ID " +
                                "INNER JOIN AC_Usuario u ON g.ID_Usuario = u.U_ID " +
                                "WHERE g.Fecha BETWEEN " + date1 + " AND " + date2);

            var model = db.Database.SqlQuery<QueryIngresos>(gastos.ToString()).ToList();
            return View(model);
        }




        public ActionResult ReporteAnimal()
        {
            return View();
        }

        public ActionResult ReporteLiberacion()
        {
            return View();
        }

        public ActionResult ReporteRiesgos()
        {
            var model = db.AC_Daño.ToList();
            return View(model);
        }
        public ActionResult ReporteRiesgosPDF()
        {
            var model = db.AC_Daño.ToList();
            return View(model);
        }


        public ActionResult ReporteZonas()
        {
            var model = db.AC_Zona.ToList();
            return View(model);
        }
        public ActionResult ReporteZonasPDF()
        {
            var model = db.AC_Zona.ToList();
            return View(model);
        }


        public ActionResult ReporteVacunas()
        {
            var model = db.AC_Vacuna.ToList();
            return View(model);
        }
        public ActionResult ReporteVacunasPDF()
        {
            var model = db.AC_Vacuna.ToList();
            return View(model);
        }


        public ActionResult DescargarVacunasPDF()
        {
            return new ActionAsPdf("ReporteVacunasPDF")
            {
                FileName = Server.MapPath("~/Content/Reporte.pdf")
            };
        }

        public ActionResult DescargarZonasPDF()
        {
            return new ActionAsPdf("ReporteZonasPDF")
            {
                FileName = Server.MapPath("~/Content/Reporte.pdf")
            };
        }

        public ActionResult DescargarRiesgosPDF()
        {
            return new ActionAsPdf("ReporteRiesgosPDF")
            {
                FileName = Server.MapPath("~/Content/Reporte.pdf")
            };
        }

        public ActionResult DescargarGastoPDF()
        {
            return new ActionAsPdf("PDFGasto")
            {
                FileName = Server.MapPath("~/Content/Reporte.pdf")
            };
        }

        public ActionResult DescargarIngresoPDF()
        {
            return new ActionAsPdf("PDFIngreso")
            {
                FileName = Server.MapPath("~/Content/Reporte.pdf")
            };
        }
    }
}