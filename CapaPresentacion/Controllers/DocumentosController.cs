using CapaEntidad;
using CapaNegocio;
using System;
using System.Web.Mvc;
using CapaServicios;

namespace CapaPresentacion.Controllers
{
    public class DocumentosController : Controller
    {
        NegocioDocumentos negocio = new NegocioDocumentos();
        DocumentosServicios servicios = new DocumentosServicios();

        public ActionResult Index()
        {
            return View(negocio.MostrarDocumentos());
        }

        [HttpPost]
        public ActionResult Index(FormCollection fechas)
        {
            TempData["primeraFecha"] = Convert.ToDateTime(fechas["primeraFecha"]);
            TempData["segundaFecha"] = Convert.ToDateTime(fechas["segundaFecha"]);
            return RedirectToAction("DocumentosFiltrados", "Documentos");
        }

        public ActionResult DocumentosFiltrados()
        {
            var primeraFecha = (DateTime)TempData["primeraFecha"];
            var segundaFecha = (DateTime)TempData["segundaFecha"];
            return View(negocio.FiltrarFecha(primeraFecha, segundaFecha));
        }

        [HttpGet]
        public ActionResult CrearDocumento()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CrearDocumento(Documentos documentos)
        {
            negocio.Agregar(documentos, servicios.Secuencia());
            return RedirectToAction("Index");
        }

        public ActionResult Editar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Editar(Documentos documento)
        {
            negocio.Modificar(documento);
            return RedirectToAction("Index");
        }

        public ActionResult Eliminar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Eliminar(Documentos documento)
        {
            negocio.Eliminar(documento);
            return RedirectToAction("Index");
        }
    }
}