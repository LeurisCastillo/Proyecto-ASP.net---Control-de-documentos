﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CapaDatos
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    using CapaEntidad;
    
    public partial class ControlDocumentosEntities1 : DbContext
    {
        public ControlDocumentosEntities1()
            : base("name=ControlDocumentosEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Departamentos> Departamentos { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<Documentos> Documentos { get; set; }
    
        public virtual ObjectResult<spFiltra_Fecha_Result> spFiltra_Fecha(Nullable<System.DateTime> primeraFecha, Nullable<System.DateTime> segundaFecha)
        {
            var primeraFechaParameter = primeraFecha.HasValue ?
                new ObjectParameter("primeraFecha", primeraFecha) :
                new ObjectParameter("primeraFecha", typeof(System.DateTime));
    
            var segundaFechaParameter = segundaFecha.HasValue ?
                new ObjectParameter("segundaFecha", segundaFecha) :
                new ObjectParameter("segundaFecha", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spFiltra_Fecha_Result>("spFiltra_Fecha", primeraFechaParameter, segundaFechaParameter);
        }
    }
}