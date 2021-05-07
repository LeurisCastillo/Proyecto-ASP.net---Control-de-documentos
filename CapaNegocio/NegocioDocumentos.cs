using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class NegocioDocumentos
    {
        DatosDocumentos datos = new DatosDocumentos();

        public void Agregar(Usuarios usuario)
        {
            datos.Insertar(usuario);
        }

        public void Agregar(Departamentos departamento)
        {
            datos.Insertar(departamento);
        }

        public void Agregar(Documentos documentos, int secuencia)
        {
            datos.Insertar(documentos, secuencia);
        }

        public List<Usuarios> MostrarUsuarios()
        {
            return datos.MostrarUsuarios();
        }

        public List<Departamentos> MostrarDepartamentos()
        {
            return datos.MostrarDepartamentos();
        }

        public List<Documentos> MostrarDocumentos()
        {
            return datos.MostrarDocumentos();
        }

        public void Modificar(Usuarios usuario)
        {
            datos.ActualizarNombre(usuario);
        }

        public void Modificar(Departamentos departamento)
        {
            datos.ActualizarNombre(departamento);
        }

        public void Modificar(Documentos documento)
        {
            datos.ActualizarNombre(documento);
        }

        public void Eliminar(Usuarios usuario)
        {
            datos.Borrar(usuario);
        }

        public void Eliminar(Departamentos departamento)
        {
            datos.Borrar(departamento);
        }

        public void Eliminar(Documentos documento)
        {
            datos.Borrar(documento);
        }

        public List<Usuarios> BuscarUsuario(Usuarios usuario)
        {
            return datos.BuscarUsuario(usuario);
        }

        public List<spFiltra_Fecha_Result> FiltrarFecha(DateTime primeraFecha, DateTime segundaFecha)
        {
            return datos.filtrarDocumentoFecha(primeraFecha, segundaFecha);
        }
    }
}
