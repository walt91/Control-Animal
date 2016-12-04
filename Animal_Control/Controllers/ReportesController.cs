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
        [Authorize]
        public ActionResult ReporteGasto()
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

        public ActionResult PDFGasto()
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
        public ActionResult ReporteIngreso()
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

        public ActionResult PDFIngreso()
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



        [Authorize]
        public ActionResult ReporteAnimal()
        {
            var model = db.AC_Animal.ToList();
            return View(model);
        }
        public ActionResult PDFAnimal()
        {
            var model = db.AC_Animal.ToList();
            return View(model);
        }



        [Authorize]
        public ActionResult ReporteLiberacion()
        {
            var liberacion = db.AC_Liberacion.ToList();
            return View(liberacion);
        }
        public ActionResult PDFLiberacion()
        {
            var liberacion = db.AC_Liberacion.ToList();
            return View(liberacion);
        }

        [Authorize]
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

        [Authorize]
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

        [Authorize]
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

        public ActionResult DescargarAnimalPDF()
        {
            return new ActionAsPdf("PDFAnimal")
            {
                FileName = Server.MapPath("~/Content/Reporte.pdf")
            };
        }

        public ActionResult DescargarLiberacionPDF()
        {
            return new ActionAsPdf("PDFLiberacion")
            {
                FileName = Server.MapPath("~/Content/Reporte.pdf")
            };
        }
    }
}