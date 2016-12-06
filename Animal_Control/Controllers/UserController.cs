using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Animal_Control.Models;

namespace Animal_Control.Controllers
{
    public class UserController : Controller
    {
        public AnimalControl db = new AnimalControl();
        AC_Usuario user = new AC_Usuario();

        // GET: User
        [Authorize]
        public ActionResult Index()
        {
            var model = db.AC_Usuario.ToList();
            return View(model);
        }

        [Authorize]
        public ActionResult AgregarUsuario()
        {
            return View();
        }

        //POST : Agregar Usuario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarUsuario(AC_Usuario usuario)
        {
            try
            {
                if (usuario != null)
                {
                    user.Nombre = usuario.Nombre;
                    user.Correo = usuario.Correo;
                    user.Contraseña = usuario.Contraseña;
                    user.Pais = usuario.Pais;
                    user.Fecha = DateTime.Now;
                    db.AC_Usuario.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ViewBag.mensage = "Ingrese los datos requeridos";
                }
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        [Authorize]
        public ActionResult ModificarUsuario(int id)
        {
            user = db.AC_Usuario.Find(id);
            return View(user);
        }

        //POST : Modificar un Usuario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModificarUsuario(int id, AC_Usuario usuario)
        {
            user = db.AC_Usuario.Find(usuario.U_ID);
            if (user != null)
            {
                try
                {
                    user.Nombre = usuario.Nombre;
                    user.Contraseña = usuario.Contraseña;
                    user.Pais = usuario.Pais;
                    db.SaveChanges();
                    return RedirectToAction("Index", "User");

                }
                catch (Exception ex)
                {
                    ViewBag.mensage = "Este usuario no existe";
                    return RedirectToAction("Index", "User");
                }
            }
            return View();
        }

        [Authorize]
        public ActionResult EliminarUsuario(int id)
        {
            var model = db.AC_Usuario.Find(id);
            if (model != null)
            {
                return View(model);
            }
            return View("Index");
        }

        //POST : Eliminar un Usuario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarUsuario(int id, AC_Usuario usuario)
        {
            try
            {
                user = db.AC_Usuario.Find(id);
                if (user != null)
                {
                    db.AC_Usuario.Remove(user);
                    db.SaveChanges();
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ViewBag.mensage = "No existe este usuario, Ingrese un valor valido";
                    return View("Error");
                }
            }
            catch(Exception ex)
            {
                ViewBag.error = "No se puede eliminar este usuario";
                ViewBag.mensage = "Tiene datos ligados a el";
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