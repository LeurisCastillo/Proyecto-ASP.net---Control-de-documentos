using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacion.Controllers
{
    public class LoginController : Controller
    {
        NegocioDocumentos negocio = new NegocioDocumentos();

        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogearUsuario(Usuarios usuario)
        {
            var registro = negocio.MostrarUsuarios();

            if (registro.Any(a => a.Email == usuario.Email && a.Contraseña == usuario.Contraseña))
            {
                Session["EmailSS"] = usuario.Email.ToString();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        public ActionResult RegistrarUsuario(Usuarios usuario)
        {
            var registro = negocio.MostrarUsuarios();

            if (!registro.Contains(usuario))
            {
                negocio.Agregar(usuario);
                return RedirectToAction("Index", "Login");
            }
            else
            {
                // Mostrar mensaje de que el usuario ya existe.
                return RedirectToAction("Index", "Login");
            }
        }
    }
}
