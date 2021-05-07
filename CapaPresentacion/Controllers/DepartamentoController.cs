using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacion.Controllers
{
    public class DepartamentoController : Controller
    {
        NegocioDocumentos negocio = new NegocioDocumentos();

        public ActionResult Index()
        {
            return View(negocio.MostrarDepartamentos());
        }

        // Editar
        [HttpGet]
        public ActionResult Editar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Editar(Departamentos departamento)
        {

            negocio.Modificar(departamento);
            return RedirectToAction("Index");
        }

        // Eliminar
        [HttpGet]
        public ActionResult Eliminar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Eliminar(Departamentos departamento)
        {
            negocio.Eliminar(departamento);
            return RedirectToAction("Index");
        }

        // Crear
        [HttpGet]
        public ActionResult CrearDepartamento()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CrearDepartamento(Departamentos departamento)
        {
            negocio.Agregar(departamento);
            return RedirectToAction("Index");
        }
    }
}
