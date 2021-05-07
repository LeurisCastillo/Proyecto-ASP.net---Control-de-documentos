using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacion.Controllers
{
    public class UsuarioController : Controller
    {
        NegocioDocumentos negocio = new NegocioDocumentos();

        // GET: Usuario
        public ActionResult Index()
        {
            return View(negocio.MostrarUsuarios());
        }

        // GET: Usuario/Edit/5
        public ActionResult Editar()
        {
            return View();
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Editar(Usuarios usuario)
        {
            negocio.Modificar(usuario);
            return RedirectToAction("Index");
        }

        // GET: Usuario/Delete/5
        public ActionResult Eliminar()
        {
            return View();
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Eliminar(Usuarios usuario)
        {
            negocio.Eliminar(usuario);
            return RedirectToAction("Index");
        }
    
    }
}
