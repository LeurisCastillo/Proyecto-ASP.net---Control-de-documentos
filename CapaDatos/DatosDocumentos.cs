using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;


namespace CapaDatos
{
    public class DatosDocumentos
    {
        ControlDocumentosEntities1 db = new ControlDocumentosEntities1();
        
        // Insertar
        public void Insertar(Usuarios usuario)
        {
            db.Usuarios.Add(usuario);
            db.SaveChanges();
        }

        public void Insertar(Departamentos departamento)
        {
            db.Departamentos.Add(departamento);
            db.SaveChanges();
        }

        public void Insertar(Documentos documentos, int secuencia)
        {
            while (db.Documentos.Any(a => a.Secuencia == secuencia))
            {
                secuencia++;
            }

            documentos.Secuencia = secuencia;

            documentos.Detalle = $"{documentos.FechaCreacion.Year}-{documentos.DepartamentoOrigen.Remove(3).ToUpper()}-{documentos.DepartamentoDestino.Remove(3).ToUpper()}-0{documentos.Secuencia}";

            db.Documentos.Add(documentos);
            db.SaveChanges();
        }

        // Mostrar
        public List<Usuarios> MostrarUsuarios()
        {
            return db.Usuarios.ToList();
        }

        public List<Departamentos> MostrarDepartamentos()
        {
            return db.Departamentos.ToList();
        }

        public List<Documentos> MostrarDocumentos()
        {
            return db.Documentos.ToList();
        }

        // Actualizar
        public void ActualizarNombre(Usuarios usuario)
        {
            var registro = db.Usuarios.FirstOrDefault(a => a.Nombre == usuario.Nombre);
            registro.Email = usuario.Email;
            db.SaveChanges();
        }

        public void ActualizarNombre(Departamentos departamento)
        {
            var registro = db.Departamentos.FirstOrDefault(a => a.Nombre == departamento.Nombre);
            registro.Siglas = departamento.Siglas;
            db.SaveChanges();
        }

        public void ActualizarNombre(Documentos documento)
        {
            var registro = db.Documentos.FirstOrDefault(a => a.Nombre == documento.Nombre);
            registro.DepartamentoDestino = documento.DepartamentoDestino;
            db.SaveChanges();
        }

        // Eliminar
        public void Borrar(Usuarios usuario)
        {
            var registro = db.Usuarios.FirstOrDefault(a => a.Nombre == usuario.Nombre);
            db.Usuarios.Remove(registro);
            db.SaveChanges();
        }

        public void Borrar(Departamentos departamento)
        {
            var registro = db.Departamentos.FirstOrDefault(a => a.Nombre == departamento.Nombre);
            db.Departamentos.Remove(registro);
            db.SaveChanges();
        }

        public void Borrar(Documentos documento)
        {
            var registro = db.Documentos.FirstOrDefault(a => a.Nombre == documento.Nombre);
            db.Documentos.Remove(registro);
            db.SaveChanges();
        }

        public List<Usuarios> BuscarUsuario(Usuarios usuario)
        {
            return db.Usuarios.Where(a => a.Email == usuario.Email && a.Contraseña == usuario.Contraseña).ToList();
        }

        // filtro de fechas

        public List<spFiltra_Fecha_Result> filtrarDocumentoFecha(DateTime primeraFecha, DateTime segundaFecha)
        {
            return db.spFiltra_Fecha(primeraFecha, segundaFecha).ToList();
        }
    }
}
