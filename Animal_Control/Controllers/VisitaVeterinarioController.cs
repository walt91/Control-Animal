﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Animal_Control.Models;
using System.Text;

namespace Animal_Control.Controllers
{
    public class VisitaVeterinarioController : Controller
    {
        public AnimalControl db = new AnimalControl();
        AC_Visita_Veterinaria veterinario = new AC_Visita_Veterinaria();
        // GET: Stock Maximo
        [Authorize]
        public ActionResult Index()
        {
            StringBuilder visitaVeterinario = new StringBuilder();
            visitaVeterinario.AppendLine("SELECT s.SMA_ID ID, a.Nombre Articulo, s.Cantidad " +
                                "from AC_Stock_Maximo s " +
                                "INNER JOIN AC_Articulo a ON " +
                                "s.SMA_ID = a.A_ID");
            var model = db.Database.SqlQuery<QueryVisitaVeterinario>(visitaVeterinario.ToString()).ToList();
            return View(model);
        }

        public ActionResult Agregar()
        {
            var animal = db.AC_Animal.ToList();
            SelectList listAnimal = new SelectList(animal, "ID", "Especie");
            ViewBag.animal = listAnimal;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(AC_Visita_Veterinaria v)
        {
            try
            {
                if (v != null)
                {
                    veterinario.ID_Animal = v.ID_Animal;
                    veterinario.Fecha = DateTime.Now;
                    db.AC_Visita_Veterinaria.Add(veterinario);
                    db.SaveChanges();
                    return RedirectToAction("Index", "VisitaVeterinario");
                }
                else
                {
                    ViewBag.error = "No se pudo Agregar";
                    ViewBag.mensage = "Ingrese los datos requeridos";
                }
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        public ActionResult Modificar(int id)
        {
            var veterinario = db.AC_Visita_Veterinaria.Find(id);
            var animal = db.AC_Animal.ToList();
            SelectList listanimal = new SelectList(animal, "ID", "Especie");
            ViewBag.animal = listanimal;
            return View(veterinario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modificar(int id, AC_Visita_Veterinaria v)
        {
            veterinario = db.AC_Visita_Veterinaria.Find(id);
            if (veterinario != null)
            {
                try
                {
                    veterinario.ID_Animal = v.ID_Animal;
                    db.SaveChanges();
                    return RedirectToAction("Index", "VisitaVeterinario");

                }
                catch (Exception ex)
                {
                    ViewBag.error = "No se pudo Modificar";
                    ViewBag.mensage = "No existe";
                    return View("Error");
                }
            }
            return View();
        }

        public ActionResult Eliminar(int id)
        {
            var model = db.AC_Visita_Veterinaria.Find(id);
            if (model != null)
            {
                return View(model);
            }
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(int id, AC_Visita_Veterinaria v)
        {
            try
            {
                veterinario = db.AC_Visita_Veterinaria.Find(id);
                if (veterinario != null)
                {
                    db.AC_Visita_Veterinaria.Remove(veterinario);
                    db.SaveChanges();
                    return RedirectToAction("Index", "VisitaVeterinario");
                }
                else
                {
                    ViewBag.error = "No se pudo Eliminar";
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