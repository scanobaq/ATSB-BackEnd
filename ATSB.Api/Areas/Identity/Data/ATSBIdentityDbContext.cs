using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ATSB.Api.Areas.Entities.Parametros;
using ATSB.Api.Areas.Entities.Configuracion;

namespace ATSB.Api.Areas.Identity.Data
{
    public partial class ATSBIdentityDbContext : DbContext
    {
        public ATSBIdentityDbContext()
        {
        }

        public ATSBIdentityDbContext(DbContextOptions<ATSBIdentityDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ParEstado> ParEstados { get; set; }
        public virtual DbSet<ParPai> ParPais { get; set; }
        public virtual DbSet<ParTipoidentificacion> ParTipoidentificacions { get; set; }
        public virtual DbSet<ParEmpresa> ParEmpresas { get; set; }
        public virtual DbSet<ParConsecutivo> ParConsecutivos { get; set; }
        public virtual DbSet<ParProceso> ParProcesos { get; set; }
        public virtual DbSet<ParTipoorigendato> ParTipoorigendatos { get; set; }
        public virtual DbSet<ParCalificacionriesgo> ParCalificacionriesgos { get; set; }
        public virtual DbSet<ParMonedum> ParMoneda { get; set; }
        public virtual DbSet<ParTipocambio> ParTipocambios { get; set; }
        public virtual DbSet<ParSucursal> ParSucursals { get; set; }
        public virtual DbSet<CnfCalificacionriesgoequivalencium> CnfCalificacionriesgoequivalencia { get; set; }
        public virtual DbSet<CnfTablagenerica> CnfTablagenericas { get; set; }
        public virtual DbSet<CnfTablagenericacampo> CnfTablagenericacampos { get; set; }
        public virtual DbSet<CnfTabla> CnfTablas { get; set; }
        public virtual DbSet<CnfTablavalor> CnfTablavalors { get; set; }
        public virtual DbSet<CnfArchivo> CnfArchivos { get; set; }
        public virtual DbSet<CnfArchivocampo> CnfArchivocampos { get; set; }
        public virtual DbSet<CnfTablagenericavalore> CnfTablagenericavalores { get; set; }
        public virtual DbSet<CnfEjecucionreporte> CnfEjecucionreportes { get; set; }
        public virtual DbSet<CnfRangomontoencabezado> CnfRangomontoencabezados { get; set; }
        public virtual DbSet<CnfEjecucionproceso> CnfEjecucionprocesos { get; set; }
        public virtual DbSet<CnfRangomontodetalle> CnfRangomontodetalles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParEstado>(entity =>
            {
                entity.HasKey(e => e.CodigoEstado);

                entity.ToTable("PAR_ESTADO");

                entity.HasComment("Tabla ParEstado");

                entity.Property(e => e.CodigoEstado)
                    .ValueGeneratedNever()
                    .HasComment("1-Código");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasComment("2-Descripción");
            });

            modelBuilder.Entity<ParPai>(entity =>
            {
                entity.HasKey(e => e.CodigoPais);

                entity.ToTable("PAR_PAIS");

                entity.HasComment("Tabla ParPais");

                entity.Property(e => e.CodigoPais)
                    .ValueGeneratedNever()
                    .HasComment("1-Código");

                entity.Property(e => e.CodigoIsoalfa2)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("CodigoISOAlfa2")
                    .HasComment("4-ISO Alfa2");

                entity.Property(e => e.CodigoIsoalfa3)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CodigoISOAlfa3")
                    .HasComment("5-ISO Alfa3");

                entity.Property(e => e.CodigoIsonumerico)
                    .HasColumnName("CodigoISONumerico")
                    .HasComment("3-ISO Númerico");

                entity.Property(e => e.FormatoTelefonoCelular)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasComment("7-Formato Teléfono Celular");

                entity.Property(e => e.FormatoTelefonoFijo)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasComment("6-Formato Teléfono Fijo");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasComment("2-Nombre");
            });

            modelBuilder.Entity<ParTipoidentificacion>(entity =>
            {
                entity.HasKey(e => new { e.CodigoTipoIdentificacion, e.CodigoPais });

                entity.ToTable("PAR_TIPOIDENTIFICACION");

                entity.HasComment("Tabla ParTipoIdentificacion");

                entity.Property(e => e.CodigoTipoIdentificacion).HasComment("2-Código");

                entity.Property(e => e.CodigoPais).HasComment("1-País");

                entity.Property(e => e.CantidadModificaciones).HasComment("0-NoAplica");

                entity.Property(e => e.CodigoFacturaElectronica)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasComment("9-Código Factura Electrónica");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasComment("3-Descripcion");

                entity.Property(e => e.FechaUltimaModificacion)
                    .HasColumnType("datetime")
                    .HasComment("7-Ultima Modificación");

                entity.Property(e => e.Formato)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasComment("4-Formato");

                entity.Property(e => e.IndicadorFisica).HasComment("6-Es Física");

                entity.Property(e => e.Longitud).HasComment("5-Longitud");

                entity.Property(e => e.UsuarioModifica)
                    .HasColumnType("text")
                    .HasComment("8-Usuario Modificación");

                entity.HasOne(d => d.CodigoPaisNavigation)
                    .WithMany(p => p.ParTipoidentificacions)
                    .HasForeignKey(d => d.CodigoPais)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PAR_PAIS_PAR_TIPOIDENTIFICACION");
            });

            modelBuilder.Entity<ParEmpresa>(entity =>
            {
                entity.HasKey(e => e.CodigoEmpresa);

                entity.ToTable("PAR_EMPRESA");

                entity.HasComment("Tabla ParEmpresa");

                entity.Property(e => e.CodigoEmpresa)
                    .ValueGeneratedNever()
                    .HasComment("1-Código");

                entity.Property(e => e.CantidadModificaciones).HasComment("0-NoAplica");

                entity.Property(e => e.CodigoBancoRegulador)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoEstado).HasComment("10-Estado");

                entity.Property(e => e.CodigoPais).HasComment("5-País");

                entity.Property(e => e.CodigoTipoIdentificacion).HasComment("3-Tipo Id");

                entity.Property(e => e.FechaIngreso)
                    .HasColumnType("datetime")
                    .HasComment("8-Fecha Ingreso");

                entity.Property(e => e.FechaUltimaModificacion)
                    .HasColumnType("datetime")
                    .HasComment("11-Ultima Modificación");

                entity.Property(e => e.IdUsuario)
                    .HasMaxLength(450)
                    .HasColumnName("idUsuario")
                    .HasComment("9-Usuario Ingreso");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasComment("2-Nombre");

                entity.Property(e => e.NumeroId)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasComment("4-# Identificación");

                entity.Property(e => e.Telefono1)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasComment("6-Teléfono");

                entity.Property(e => e.Telefono2)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasComment("7-Teléfono");

                entity.Property(e => e.UsuarioModifica)
                    .HasColumnType("text")
                    .HasComment("12-Usuario Ultima Modficación");

                entity.HasOne(d => d.CodigoEstadoNavigation)
                    .WithMany(p => p.ParEmpresas)
                    .HasForeignKey(d => d.CodigoEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PAR_ESTADO_PAR_EMPRESA");

                entity.HasOne(d => d.CodigoPaisNavigation)
                    .WithMany(p => p.ParEmpresas)
                    .HasForeignKey(d => d.CodigoPais)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PAR_PAIS_PAR_EMPRESA");

                entity.HasOne(d => d.Codigo)
                    .WithMany(p => p.ParEmpresas)
                    .HasForeignKey(d => new { d.CodigoTipoIdentificacion, d.CodigoPais })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PAR_TIPOIDENTIFICACION_PAR_EMPRESA");
            });

            modelBuilder.Entity<ParConsecutivo>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEmpresa, e.IdConsecutivo });

                entity.ToTable("PAR_CONSECUTIVO");

                entity.HasComment("Tabla ParConsecutivo");

                entity.Property(e => e.CodigoEmpresa).HasComment("1-Empresa");

                entity.Property(e => e.IdConsecutivo)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasComment("2-Id");

                entity.Property(e => e.NumeroConsecutivo).HasComment("3-Descripción");

                entity.HasOne(d => d.CodigoEmpresaNavigation)
                    .WithMany(p => p.ParConsecutivos)
                    .HasForeignKey(d => d.CodigoEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PAR_EMPRESA_PAR_CONSECUTIVO");
            });

            modelBuilder.Entity<ParProceso>(entity =>
            {
                entity.HasKey(e => new { e.CodigoProceso, e.CodigoEmpresa });

                entity.ToTable("PAR_PROCESO");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NombreProceso)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TablaDestino)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.CodigoEmpresaNavigation)
                    .WithMany(p => p.ParProcesos)
                    .HasForeignKey(d => d.CodigoEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PAR_EMPRESA_PAR_PROCESO");
            });

            modelBuilder.Entity<ParTipoorigendato>(entity =>
            {
                entity.HasKey(e => new { e.CodigoOrigenDatos, e.CodigoEmpresa });

                entity.ToTable("PAR_TIPOORIGENDATOS");

                entity.Property(e => e.DelimitadorDatos)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodigoEmpresaNavigation)
                    .WithMany(p => p.ParTipoorigendatos)
                    .HasForeignKey(d => d.CodigoEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PAR_EMPRESA_PAR_TIPOORIGENDATOS");
            });

            modelBuilder.Entity<ParCalificacionriesgo>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEmpresa, e.Id });

                entity.ToTable("PAR_CALIFICACIONRIESGO");

                entity.Property(e => e.Comp)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Fitch)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.IdUsuario)
                    .HasMaxLength(450)
                    .HasColumnName("idUsuario");

                entity.Property(e => e.Moody)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Sp)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("SP");

                entity.HasOne(d => d.CodigoEmpresaNavigation)
                    .WithMany(p => p.ParCalificacionriesgos)
                    .HasForeignKey(d => d.CodigoEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PAR_EMPRESA_PAR_CALIFICACIONRIESGO");
            });

            modelBuilder.Entity<ParMonedum>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEmpresa, e.CodigoMoneda });

                entity.ToTable("PAR_MONEDA");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionCorta)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.IdUsuario)
                    .HasMaxLength(450)
                    .HasColumnName("idUsuario");

                entity.HasOne(d => d.CodigoEmpresaNavigation)
                    .WithMany(p => p.ParMoneda)
                    .HasForeignKey(d => d.CodigoEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PAR_EMPRESA_PAR_MONEDA");
            });

            modelBuilder.Entity<ParTipocambio>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEmpresa, e.Fecha, e.CodigoMoneda });

                entity.ToTable("PAR_TIPOCAMBIO");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.Id)
                    .HasMaxLength(450)
                    .HasColumnName("id");

                entity.HasOne(d => d.CodigoEmpresaNavigation)
                    .WithMany(p => p.ParTipocambios)
                    .HasForeignKey(d => d.CodigoEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PAR_EMPRESA_PAR_TIPOCAMBIO");

                entity.HasOne(d => d.Codigo)
                    .WithMany(p => p.ParTipocambios)
                    .HasForeignKey(d => new { d.CodigoEmpresa, d.CodigoMoneda })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PAR_MONEDA_PAR_TIPOCAMBIO");
            });

            modelBuilder.Entity<ParSucursal>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEmpresa, e.CodigoBanco, e.CodigoSucursal });

                entity.ToTable("PAR_SUCURSAL");

                entity.Property(e => e.CodigoEmpresa).HasComment("1-Empresa");

                entity.Property(e => e.CodigoBanco).HasComment("10-Centro de Costo");

                entity.Property(e => e.CodigoSucursal).HasComment("2-Código");

                entity.Property(e => e.CodigoOrigen)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasComment("4-País");

                entity.Property(e => e.CodigoPais).HasComment("6-Cantón");

                entity.Property(e => e.CodigoSubsidiaria).HasComment("5-Provincia");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("7-Dirección");

                entity.Property(e => e.Encargado)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("8-Encargado");

                entity.Property(e => e.Fax)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasComment("9-Teléfono");

                entity.Property(e => e.IdUsuario)
                    .HasMaxLength(450)
                    .HasColumnName("idUsuario")
                    .HasComment("0-No Aplica");

                entity.Property(e => e.NombreResponsable)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.NombreSucursal)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("3-Nombre");

                entity.Property(e => e.Telefono1)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasComment("9-Teléfono");

                entity.Property(e => e.Telefono2)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasComment("9-Teléfono");

                entity.Property(e => e.TipoEstablecimiento).HasComment("6-Cantón");

                entity.HasOne(d => d.CodigoEmpresaNavigation)
                    .WithMany(p => p.ParSucursals)
                    .HasForeignKey(d => d.CodigoEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PAR_EMPRESA_PAR_SUCURSAL");

                entity.HasOne(d => d.CodigoEstadoNavigation)
                    .WithMany(p => p.ParSucursals)
                    .HasForeignKey(d => d.CodigoEstado)
                    .HasConstraintName("PAR_ESTADO_PAR_SUCURSAL");
            });

            modelBuilder.Entity<CnfCalificacionriesgoequivalencium>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEmpresa, e.CalificacionOrigen });

                entity.ToTable("CNF_CALIFICACIONRIESGOEQUIVALENCIA");

                entity.Property(e => e.CalificacionOrigen)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.CalificacionDestino)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IdUsuario)
                    .HasMaxLength(450)
                    .HasColumnName("idUsuario");

                entity.HasOne(d => d.CodigoEmpresaNavigation)
                    .WithMany(p => p.CnfCalificacionriesgoequivalencia)
                    .HasForeignKey(d => d.CodigoEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PAR_EMPRESA_CNF_CALIFICACIONRIESGOEQUIVALENCIA");
            });

            modelBuilder.Entity<CnfTablagenerica>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEmpresa, e.IdTabla });

                entity.ToTable("CNF_TABLAGENERICA");

                entity.HasIndex(e => new { e.CodigoEmpresa, e.TablaParametros }, "IDX_TABLAGENERICA_TABLAPARAMETRO");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdUsuario)
                    .HasMaxLength(450)
                    .HasColumnName("idUsuario");

                entity.Property(e => e.TablaParametros)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodigoEmpresaNavigation)
                    .WithMany(p => p.CnfTablagenericas)
                    .HasForeignKey(d => d.CodigoEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PAR_EMPRESA_CNF_TABLAGENERICA");
            });

            modelBuilder.Entity<CnfTablagenericacampo>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEmpresa, e.IdTabla, e.IdCampo });

                entity.ToTable("CNF_TABLAGENERICACAMPOS");

                entity.Property(e => e.IdCampo)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Etiqueta)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdUsuario)
                    .HasMaxLength(450)
                    .HasColumnName("idUsuario");

                entity.Property(e => e.NombreCampo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CnfTablagenerica)
                    .WithMany(p => p.CnfTablagenericacampos)
                    .HasForeignKey(d => new { d.CodigoEmpresa, d.IdTabla })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CNF_TABLAGENERICA_CNF_TABLAGENERICACAMPOS");
            });

            modelBuilder.Entity<CnfTabla>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEmpresa, e.CodigoTabla });

                entity.ToTable("CNF_TABLA");

                entity.HasIndex(e => new { e.CodigoEmpresa, e.Tabla }, "IDX_CNF_TABLA_CODIGOEMPRESA_TABLA");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tabla)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodigoEmpresaNavigation)
                    .WithMany(p => p.CnfTablas)
                    .HasForeignKey(d => d.CodigoEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PAR_EMPRESA_CNF_TABLA");
            });

            modelBuilder.Entity<CnfTablavalor>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEmpresa, e.CodigoTabla, e.IdValor });

                entity.ToTable("CNF_TABLAVALOR");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Valor)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodigoEstadoNavigation)
                    .WithMany(p => p.CnfTablavalors)
                    .HasForeignKey(d => d.CodigoEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PAR_ESTADO_CNF_TABLAVALOR");

                entity.HasOne(d => d.CodigoNavigation)
                    .WithMany(p => p.CnfTablavalors)
                    .HasForeignKey(d => new { d.CodigoEmpresa, d.CodigoTabla })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CNF_TABLA_CNF_TABLAVALOR");
            });

            modelBuilder.Entity<CnfArchivo>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEmpresa, e.IdArchivo });

                entity.ToTable("CNF_ARCHIVO");

                entity.Property(e => e.DescripcionArchivo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdUsuario)
                    .HasMaxLength(450)
                    .HasColumnName("idUsuario");

                entity.Property(e => e.NombreArchivo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TablaDestino)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodigoEmpresaNavigation)
                    .WithMany(p => p.CnfArchivos)
                    .HasForeignKey(d => d.CodigoEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PAR_EMPRESA_CNF_ARCHIVO");
            });

            modelBuilder.Entity<CnfArchivocampo>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEmpresa, e.IdArchivo, e.IdCampo });

                entity.ToTable("CNF_ARCHIVOCAMPO");

                entity.Property(e => e.CondicionPatron)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreCampo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombrePatron)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Patron)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodigoEstadoNavigation)
                    .WithMany(p => p.CnfArchivocampos)
                    .HasForeignKey(d => d.CodigoEstado)
                    .HasConstraintName("PAR_ESTADO_CNF_ARCHIVOCAMPO");

                entity.HasOne(d => d.CnfArchivo)
                    .WithMany(p => p.CnfArchivocampos)
                    .HasForeignKey(d => new { d.CodigoEmpresa, d.IdArchivo })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CNF_ARCHIVO_CNF_ARCHIVOCAMPO");
            });

            modelBuilder.Entity<CnfTablagenericavalore>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEmpresa, e.IdTabla, e.IdValor });

                entity.ToTable("CNF_TABLAGENERICAVALORES");

                entity.HasIndex(e => new { e.CodigoEmpresa, e.IdValor }, "IDX_CNF_TABLAGENERICAVALORES_EMPRESA_IDVALOR");

                entity.Property(e => e.CodigoValor)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion1)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion2)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion3)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion4)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion5)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.IdUsuario)
                    .HasMaxLength(450)
                    .HasColumnName("idUsuario");

                entity.HasOne(d => d.CodigoEstadoNavigation)
                    .WithMany(p => p.CnfTablagenericavalores)
                    .HasForeignKey(d => d.CodigoEstado)
                    .HasConstraintName("PAR_ESTADO_CNF_TABLAGENERICAVALORES");

                entity.HasOne(d => d.CnfTablagenerica)
                    .WithMany(p => p.CnfTablagenericavalores)
                    .HasForeignKey(d => new { d.CodigoEmpresa, d.IdTabla })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CNF_TABLAGENERICA_CNF_TABLAGENERICAVALORES");
            });

            modelBuilder.Entity<CnfEjecucionreporte>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEmpresa, e.Id });

                entity.ToTable("CNF_EJECUCIONREPORTES");

                entity.Property(e => e.Campos)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.Condicion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdUsuario)
                    .HasMaxLength(450)
                    .HasColumnName("idUsuario");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NombreHoja)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Tabla)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodigoEmpresaNavigation)
                    .WithMany(p => p.CnfEjecucionreportes)
                    .HasForeignKey(d => d.CodigoEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PAR_EMPRESA_CNF_EJECUCIONREPORTES");

                entity.HasOne(d => d.CodigoEstadoNavigation)
                    .WithMany(p => p.CnfEjecucionreportes)
                    .HasForeignKey(d => d.CodigoEstado)
                    .HasConstraintName("PAR_ESTADO_CNF_EJECUCIONREPORTES");

                entity.HasOne(d => d.Codigo)
                    .WithMany(p => p.CnfEjecucionreportes)
                    .HasForeignKey(d => new { d.CodigoOrigenDatosSalida, d.CodigoEmpresa })
                    .HasConstraintName("PAR_TIPOORIGENDATOS_CNF_EJECUCIONREPORTES");
            });

            modelBuilder.Entity<CnfRangomontoencabezado>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEmpresa, e.CodigoTabla });

                entity.ToTable("CNF_RANGOMONTOENCABEZADO");

                entity.Property(e => e.DescripcionProceso)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.IdUsuario)
                    .HasMaxLength(450)
                    .HasColumnName("idUsuario");

                entity.Property(e => e.NombreTabla)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodigoEmpresaNavigation)
                    .WithMany(p => p.CnfRangomontoencabezados)
                    .HasForeignKey(d => d.CodigoEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PAR_EMPRESA_CNF_RANGOMONTOENCABEZADO");
            });

            modelBuilder.Entity<CnfEjecucionproceso>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEmpresa, e.CodigoProceso, e.SecuenciaProceso });

                entity.ToTable("CNF_EJECUCIONPROCESOS");

                entity.Property(e => e.Condicion)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionOrigenDatos)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.EjecutaProcedimiento)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TablaDestino)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodigoEmpresaNavigation)
                    .WithMany(p => p.CnfEjecucionprocesos)
                    .HasForeignKey(d => d.CodigoEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PAR_EMPRESA_CNF_EJECUCIONPROCESOS");

                entity.HasOne(d => d.CodigoEstadoNavigation)
                    .WithMany(p => p.CnfEjecucionprocesos)
                    .HasForeignKey(d => d.CodigoEstado)
                    .HasConstraintName("PAR_ESTADO_CNF_EJECUCIONPROCESOS");

                entity.HasOne(d => d.Codigo)
                    .WithMany(p => p.CnfEjecucionprocesos)
                    .HasForeignKey(d => new { d.CodigoOrigenDatos, d.CodigoEmpresa })
                    .HasConstraintName("PAR_TIPOORIGENDATOS_CNF_EJECUCIONPROCESOS");

                entity.HasOne(d => d.CodigoNavigation)
                    .WithMany(p => p.CnfEjecucionprocesos)
                    .HasForeignKey(d => new { d.CodigoProceso, d.CodigoEmpresa })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PAR_PROCESO_CNF_EJECUCIONPROCESOS");
            });

            modelBuilder.Entity<CnfRangomontodetalle>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEmpresa, e.CodigoTabla, e.CodigoRango });

                entity.ToTable("CNF_RANGOMONTODETALLE");

                entity.Property(e => e.CodigoRango)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.IdUsuario)
                    .HasMaxLength(450)
                    .HasColumnName("idUsuario");

                entity.Property(e => e.RangoValor)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodigoEmpresaNavigation)
                    .WithMany(p => p.CnfRangomontodetalles)
                    .HasForeignKey(d => d.CodigoEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PAR_EMPRESA_CNF_RANGOMONTODETALLE");

                entity.HasOne(d => d.CodigoEstadoNavigation)
                    .WithMany(p => p.CnfRangomontodetalles)
                    .HasForeignKey(d => d.CodigoEstado)
                    .HasConstraintName("PAR_ESTADO_CNF_RANGOMONTODETALLE");

                entity.HasOne(d => d.Codigo)
                    .WithMany(p => p.CnfRangomontodetalles)
                    .HasForeignKey(d => new { d.CodigoEmpresa, d.CodigoTabla })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CNF_RANGOMONTOENCABEZADO_CNF_RANGOMONTODETALLE");
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
