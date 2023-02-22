using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ATSB.Api.Areas.Entities.Parametros;
using ATSB.Api.Areas.Entities.Configuracion;
using ATSB.Api.Areas.Entities.Contable;
using ATSB.Api.Areas.Entities.Credito;
using ATSB.Api.Areas.Entities.Liquidez;
using ATSB.Api.Areas.Entities.Pasivo;
using ATSB.Api.Areas.Entities.Seguridad;
using ATSB.Api.Areas.Entities.Logs;
using ATSB.Api.Areas.Entities.Temporales;
using ATSB.Api.Areas.Identity.Entities.Security;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ATSB.Api.Areas.Identity.Data
{
    public partial class ATSBIdentityDbContext : IdentityDbContext<UserAtsb>
    {
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
        public virtual DbSet<ConTipocuentum> ConTipocuenta { get; set; }
        public virtual DbSet<ConCatalogoequivalencium> ConCatalogoequivalencia { get; set; }
        public virtual DbSet<ConCuentaliquidez> ConCuentaliquidezs { get; set; }
        public virtual DbSet<ConBalancehistorico> ConBalancehistoricos { get; set; }
        public virtual DbSet<ParCalificacionriesgopai> ParCalificacionriesgopais { get; set; }
        public virtual DbSet<CreMaestro> CreMaestros { get; set; }
        public virtual DbSet<LiqRubroproceso> LiqRubroprocesos { get; set; }
        public virtual DbSet<LiqIndie> LiqIndice { get; set; }
        public virtual DbSet<LiqInstrumentorubro> LiqInstrumentorubros { get; set; }
        public virtual DbSet<PasMaestro> PasMaestros { get; set; }
        public virtual DbSet<PasCuentaliquidez> PasCuentaliquidezs { get; set; }
        public virtual DbSet<PasDetallehistorico> PasDetallehistoricos { get; set; }
        public virtual DbSet<PasGarantiapignorado> PasGarantiapignorados { get; set; }
        public virtual DbSet<SegEstado> SegEstados { get; set; }
        public virtual DbSet<SegEvento> SegEventos { get; set; }
        public virtual DbSet<SegHistoricopassword> SegHistoricopasswords { get; set; }
        public virtual DbSet<SegConfiguracion> SegConfiguracions { get; set; }
        public virtual DbSet<SegAcceso> SegAccesos { get; set; }
        public virtual DbSet<LogEjecucionproceso> LogEjecucionprocesos { get; set; }
        public virtual DbSet<ConBalancecomparativo> ConBalancecomparativos { get; set; }
        public virtual DbSet<TmpCargaTxtBalancecontable> TmpCargaTxtBalancecontables { get; set; }
        public virtual DbSet<TmpCargaTxtCredito> TmpCargaTxtCreditos { get; set; }
        public virtual DbSet<TmpCargaTxtDepositoplazo> TmpCargaTxtDepositoplazos { get; set; }
        public virtual DbSet<TmpCargaTxtDepositoplazopignorado> TmpCargaTxtDepositoplazopignorados { get; set; }
        public virtual DbSet<TmpCargaExcelCreditoCalificacionesDef> TmpCargaExcelCreditoCalificacionesDefs { get; set; }
        public virtual DbSet<TmpCargaExcelMaestroTcDef> TmpCargaExcelMaestroTcDefs { get; set; }
        public virtual DbSet<TmpCargaTxtCreditocalce> TmpCargaTxtCreditocalces { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityUser>().ToTable("UserAtsb");

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

            modelBuilder.Entity<ConTipocuentum>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEmpresa, e.CodigoTipo });

                entity.ToTable("CON_TIPOCUENTA");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.IdUsuario)
                    .HasMaxLength(450)
                    .HasColumnName("idUsuario");

                entity.HasOne(d => d.CodigoEmpresaNavigation)
                    .WithMany(p => p.ConTipocuenta)
                    .HasForeignKey(d => d.CodigoEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PAR_EMPRESA_CON_TIPOCUENTA");
            });

            modelBuilder.Entity<ConCatalogoequivalencium>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEmpresa, e.IdCuenta });

                entity.ToTable("CON_CATALOGOEQUIVALENCIA");

                entity.HasIndex(e => new { e.CodigoEmpresa, e.CuentaContableLocal }, "IDX_CON_CATALOGOEQUIVALENCIA_CUENTACONTABLELOCAL")
                    .IsUnique();

                entity.Property(e => e.CuentaContableLocal).HasMaxLength(30);

                entity.Property(e => e.Destino)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.IdUsuario)
                    .HasMaxLength(450)
                    .HasColumnName("idUsuario");

                entity.Property(e => e.NombreCuenta)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodigoEmpresaNavigation)
                    .WithMany(p => p.ConCatalogoequivalencia)
                    .HasForeignKey(d => d.CodigoEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PAR_EMPRESA_CON_CATALOGOEQUIVALENCIA");

                entity.HasOne(d => d.Codigo)
                    .WithMany(p => p.ConCatalogoequivalencia)
                    .HasForeignKey(d => new { d.CodigoEmpresa, d.CodigoTipo })
                    .HasConstraintName("CON_TIPOCUENTA_CON_CATALOGOEQUIVALENCIA");
            });

            modelBuilder.Entity<ConCuentaliquidez>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEmpresa, e.CuentaLiquidez, e.CuentaContableLocal });

                entity.ToTable("CON_CUENTALIQUIDEZ");

                entity.Property(e => e.CodigoRelacionBanco)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.DestinoLocalExtranjero)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.FechaAdquisicion)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IdUsuario)
                    .HasMaxLength(450)
                    .HasColumnName("idUsuario");

                entity.Property(e => e.NombreEnte)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodigoEmpresaNavigation)
                    .WithMany(p => p.ConCuentaliquidezs)
                    .HasForeignKey(d => d.CodigoEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PAR_EMPRESA_CON_CUENTALIQUIDEZ");

                entity.HasOne(d => d.Codigo)
                    .WithMany(p => p.ConCuentaliquidezs)
                    .HasForeignKey(d => new { d.CodigoEmpresa, d.CodigoCalificacionRiesgo })
                    .HasConstraintName("PAR_CALIFICACIONRIESGO_CON_CUENTALIQUIDEZ");
            });

            modelBuilder.Entity<ConBalancehistorico>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEmpresa, e.Fecha, e.CodigoCuentaContable })
                    .HasName("PK__CON_BALA__45D0484C717513BE");

                entity.ToTable("CON_BALANCEHISTORICO");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.IdUsuario)
                    .HasMaxLength(450)
                    .HasColumnName("idUsuario");

                entity.HasOne(d => d.CodigoEmpresaNavigation)
                    .WithMany(p => p.ConBalancehistoricos)
                    .HasForeignKey(d => d.CodigoEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PAR_EMPRESA_CON_BALANCEHISTORICO");
            });

            modelBuilder.Entity<ParCalificacionriesgopai>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEmpresa, e.CodigoPais });

                entity.ToTable("PAR_CALIFICACIONRIESGOPAIS");

                entity.Property(e => e.CalficacionAjustada).HasComputedColumnSql("(case when [dbo].[FN_CALCULAR_PERSPECTIVAFINAL]([PerspectivaFitch],[PerspectivaMoody],[PerspectivaSP])=(1) then [dbo].[FN_MODA]((((CONVERT([varchar](10),[NumeroCalificacionFitch])+';')+CONVERT([varchar](10),[NumeroCalificacionMoody]))+';')+CONVERT([varchar](10),[NumeroCalificacionSP]),';')*(1)+(1) else [dbo].[FN_MODA]((((CONVERT([varchar](10),[NumeroCalificacionFitch])+';')+CONVERT([varchar](10),[NumeroCalificacionMoody]))+';')+CONVERT([varchar](10),[NumeroCalificacionSP]),';')*(1) end)", false);

                entity.Property(e => e.CodigoCalificacionFitch)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoCalificacionMoody)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoCalificacionSp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CodigoCalificacionSP");

                entity.Property(e => e.FechaUltimaActualizacion).HasColumnType("date");

                entity.Property(e => e.FechaUltimaActualizacionFitch)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FechaUltimaActualizacionMoody)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FechaUltimaActualizacionSp)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("FechaUltimaActualizacionSP");

                entity.Property(e => e.IdUsuario)
                    .HasMaxLength(450)
                    .HasColumnName("idUsuario");

                entity.Property(e => e.NumeroCalificacionPais).HasComputedColumnSql("([dbo].[FN_MODA]((((CONVERT([varchar](10),[NumeroCalificacionFitch])+';')+CONVERT([varchar](10),[NumeroCalificacionMoody]))+';')+CONVERT([varchar](10),[NumeroCalificacionSP]),';'))", false);

                entity.Property(e => e.NumeroCalificacionSp).HasColumnName("NumeroCalificacionSP");

                entity.Property(e => e.Pd).HasColumnName("PD");

                entity.Property(e => e.Pdajustada).HasColumnName("PDAjustada");

                entity.Property(e => e.Pdfinal).HasColumnName("PDFinal");

                entity.Property(e => e.Perspectiva).HasComputedColumnSql("([dbo].[FN_CALCULAR_PERSPECTIVAFINAL]([PerspectivaFitch],[PerspectivaMoody],[PerspectivaSP]))", false);

                entity.Property(e => e.PerspectivaSp).HasColumnName("PerspectivaSP");

                entity.HasOne(d => d.CodigoEmpresaNavigation)
                    .WithMany(p => p.ParCalificacionriesgopais)
                    .HasForeignKey(d => d.CodigoEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PAR_EMPRESA_PAR_CALIFICACIONRIESGOPAIS");
            });

            modelBuilder.Entity<CreMaestro>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEmpresa, e.NumeroOperacion });

                entity.ToTable("CRE_MAESTRO");

                entity.Property(e => e.NumeroOperacion)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoCliente)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaArchivo).HasColumnType("datetime");

                entity.Property(e => e.FechaInicio).HasColumnType("datetime");

                entity.Property(e => e.FechaRevisionTasa).HasColumnType("datetime");

                entity.Property(e => e.FechaVencimiento).HasColumnType("datetime");

                entity.Property(e => e.IdUsuario)
                    .HasMaxLength(450)
                    .HasColumnName("idUsuario");

                entity.Property(e => e.NombreCliente)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodigoEmpresaNavigation)
                    .WithMany(p => p.CreMaestros)
                    .HasForeignKey(d => d.CodigoEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PAR_EMPRESA_CRE_MAESTRO");
            });

            modelBuilder.Entity<LiqRubroproceso>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEmpresa, e.Rubro });

                entity.ToTable("LIQ_RUBROPROCESO");

                entity.Property(e => e.IdUsuario)
                    .HasMaxLength(450)
                    .HasColumnName("idUsuario");

                entity.HasOne(d => d.CodigoEmpresaNavigation)
                    .WithMany(p => p.LiqRubroprocesos)
                    .HasForeignKey(d => d.CodigoEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PAR_EMPRESA_LIQ_RUBROPROCESO");
            });

            modelBuilder.Entity<LiqIndie>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEmpresa, e.Tipo, e.Rubro });

                entity.ToTable("LIQ_INDICE");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.IdUsuario)
                    .HasMaxLength(450)
                    .HasColumnName("idUsuario");

                entity.Property(e => e.TipoDescipcion)
                    .IsRequired()
                    .HasMaxLength(28)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(case when [Tipo]='A' then 'ACTIVOS LÍQUIDOS' else 'PASIVOS(DEPÓSITOS RECIBIDOS)' end)", false);

                entity.HasOne(d => d.CodigoEmpresaNavigation)
                    .WithMany(p => p.LiqIndice)
                    .HasForeignKey(d => d.CodigoEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PAR_EMPRESA_LIQ_INDICE");
            });

            modelBuilder.Entity<LiqInstrumentorubro>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEmpresa, e.Instrumento, e.CodigoRegion, e.CodigoRubro })
                    .HasName("PK_tblLiq_Rubros_Instrumento");

                entity.ToTable("LIQ_INSTRUMENTORUBRO");

                entity.Property(e => e.Instrumento)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoRegion)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoEstado)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IdUsuario)
                    .HasMaxLength(450)
                    .HasColumnName("idUsuario");

                entity.HasOne(d => d.CodigoEmpresaNavigation)
                    .WithMany(p => p.LiqInstrumentorubros)
                    .HasForeignKey(d => d.CodigoEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PAR_EMPRESA_LIQ_INSTRUMENTORUBRO");
            });

            modelBuilder.Entity<PasMaestro>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEmpresa, e.NumeroCuenta });

                entity.ToTable("PAS_MAESTRO");

                entity.HasIndex(e => new { e.CodigoEmpresa, e.IndicadorRelacionBanco }, "IDX_PAS_MAESTRO_INDICADORRELACIONBANCO");

                entity.Property(e => e.NumeroCuenta)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DestinoLocalExtranjero)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.FechaArchivo).HasColumnType("datetime");

                entity.Property(e => e.FechaInicio).HasColumnType("datetime");

                entity.Property(e => e.FechaInicioReal).HasColumnType("datetime");

                entity.Property(e => e.IdUsuario)
                    .HasMaxLength(450)
                    .HasColumnName("idUsuario");

                entity.Property(e => e.IndicadorRelacionBanco)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodigoEmpresaNavigation)
                    .WithMany(p => p.PasMaestros)
                    .HasForeignKey(d => d.CodigoEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PAR_EMPRESA_PAS_MAESTRO");
            });

            modelBuilder.Entity<PasCuentaliquidez>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEmpresa, e.TipoDeposito, e.TipoCliente, e.CodigoCuentaLiquidez, e.DestinoLocalExtranjero });

                entity.ToTable("PAS_CUENTALIQUIDEZ");

                entity.Property(e => e.DestinoLocalExtranjero)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.IdUsuario)
                    .HasMaxLength(450)
                    .HasColumnName("idUsuario");

                entity.HasOne(d => d.CodigoEmpresaNavigation)
                    .WithMany(p => p.PasCuentaliquidezs)
                    .HasForeignKey(d => d.CodigoEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PAR_EMPRESA_PAS_CUENTALIQUIDEZ");
            });

            modelBuilder.Entity<PasDetallehistorico>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEmpresa, e.NumeroOperacion, e.Fecha });

                entity.ToTable("PAS_DETALLEHISTORICO");

                entity.Property(e => e.NumeroOperacion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoCliente)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Destino)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.FechaInicio)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FechaRenovacion)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FechaVencimiento)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IdUsuario)
                    .HasMaxLength(450)
                    .HasColumnName("idUsuario");

                entity.Property(e => e.NombreCliente)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodigoEmpresaNavigation)
                    .WithMany(p => p.PasDetallehistoricos)
                    .HasForeignKey(d => d.CodigoEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PAR_EMPRESA_PAS_DETALLEHISTORICO");
            });

            modelBuilder.Entity<PasGarantiapignorado>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEmpresa, e.NumeroCuenta, e.NumeroOperacionGarantia });

                entity.ToTable("PAS_GARANTIAPIGNORADO");

                entity.Property(e => e.NumeroCuenta)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroOperacionGarantia)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Agrupa)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaVencimientoOperacionGarantia).HasColumnType("date");

                entity.Property(e => e.IdUsuario)
                    .HasMaxLength(450)
                    .HasColumnName("idUsuario");

                entity.Property(e => e.NumeroClienteOperacionGarantia)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodigoEmpresaNavigation)
                    .WithMany(p => p.PasGarantiapignorados)
                    .HasForeignKey(d => d.CodigoEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PAR_EMPRESA_PAS_GARANTIAPIGNORADO");

                entity.HasOne(d => d.CodigoEstadoNavigation)
                    .WithMany(p => p.PasGarantiapignorados)
                    .HasForeignKey(d => d.CodigoEstado)
                    .HasConstraintName("PAR_ESTADO_PAS_GARANTIAPIGNORADO");
            });

            modelBuilder.Entity<SegEstado>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEmpresa, e.CodigoEstado });

                entity.ToTable("SEG_ESTADO");

                entity.Property(e => e.CodigoEstado)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodigoEmpresaNavigation)
                    .WithMany(p => p.SegEstados)
                    .HasForeignKey(d => d.CodigoEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PAR_EMPRESA_SEG_ESTADO");
            });

            modelBuilder.Entity<SegEvento>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEmpresa, e.IdEvento });

                entity.ToTable("SEG_EVENTO");

                entity.Property(e => e.IdEvento).HasColumnName("idEvento");

                entity.Property(e => e.Descripción)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodigoEmpresaNavigation)
                    .WithMany(p => p.SegEventos)
                    .HasForeignKey(d => d.CodigoEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PAR_EMPRESA_SEG_EVENTO");
            });

            modelBuilder.Entity<SegHistoricopassword>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEmpresa, e.IdUsuario, e.FechaHoraCambio });

                entity.ToTable("SEG_HISTORICOPASSWORD");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.FechaHoraCambio).HasColumnType("datetime");

                entity.Property(e => e.DescripcionPassword)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodigoEmpresaNavigation)
                    .WithMany(p => p.SegHistoricopasswords)
                    .HasForeignKey(d => d.CodigoEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PAR_EMPRESA_SEG_HISTORICOPASSWORD");
            });

            modelBuilder.Entity<SegConfiguracion>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEmpresa, e.IdParametro });

                entity.ToTable("SEG_CONFIGURACION");

                entity.Property(e => e.IdParametro).HasColumnName("idParametro");

                entity.Property(e => e.FechaHoraIngreso).HasColumnType("datetime");

                entity.Property(e => e.IdUsuario)
                    .HasMaxLength(450)
                    .HasColumnName("idUsuario");

                entity.HasOne(d => d.CodigoEmpresaNavigation)
                    .WithMany(p => p.SegConfiguracions)
                    .HasForeignKey(d => d.CodigoEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PAR_EMPRESA_SEG_CONFIGURACION");

                entity.HasOne(d => d.CodigoEstadoNavigation)
                    .WithMany(p => p.SegConfiguracions)
                    .HasForeignKey(d => d.CodigoEstado)
                    .HasConstraintName("PAR_ESTADO_SEG_CONFIGURACION");
            });

            modelBuilder.Entity<SegAcceso>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEmpresa, e.CodigoTipoAcceso });

                entity.ToTable("SEG_ACCESO");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .HasMaxLength(450)
                    .HasColumnName("id");

                entity.Property(e => e.IdUsuario)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("idUsuario");

                entity.HasOne(d => d.CodigoEmpresaNavigation)
                    .WithMany(p => p.SegAccesos)
                    .HasForeignKey(d => d.CodigoEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PAR_EMPRESA_SEG_ACCESO");
            });

            modelBuilder.Entity<LogEjecucionproceso>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEmpresa, e.CodigoProceso, e.SecuenciaProceso, e.FechaInforme });

                entity.ToTable("LOG_EJECUCIONPROCESOS");

                entity.Property(e => e.FechaInforme).HasColumnType("date");

                entity.Property(e => e.CantidadRegistros)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoErrorDb).HasColumnName("CodigoErrorDB");

                entity.Property(e => e.FechaEjecucion).HasColumnType("datetime");

                entity.Property(e => e.IdUsuario)
                    .IsRequired()
                    .HasMaxLength(450)
                    .HasColumnName("idUsuario");

                entity.Property(e => e.MensajeOriginal)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.MensajeTarea)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.HasOne(d => d.CnfEjecucionproceso)
                    .WithMany(p => p.LogEjecucionprocesos)
                    .HasForeignKey(d => new { d.CodigoEmpresa, d.CodigoProceso, d.SecuenciaProceso })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CNF_EJECUCIONPROCESOS_LOG_EJECUCIONPROCESOS");
            });

            modelBuilder.Entity<ConBalancecomparativo>(entity =>
            {
                entity.HasKey(e => e.Llave)
                    .HasName("PK__CON_BALA__8E70B293D80874AF");

                entity.ToTable("CON_BALANCECOMPARATIVO");

                entity.Property(e => e.Llave).HasDefaultValueSql("(newid())");

                entity.Property(e => e.FechaFinal).HasColumnType("datetime");

                entity.Property(e => e.FechaInicio).HasColumnType("datetime");

                entity.Property(e => e.IdUsuario)
                    .IsRequired()
                    .HasMaxLength(450)
                    .HasColumnName("idUsuario");

                entity.HasOne(d => d.CodigoEmpresaNavigation)
                    .WithMany(p => p.ConBalancecomparativos)
                    .HasForeignKey(d => d.CodigoEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PAR_EMPRESA_CON_BALANCECOMPARATIVO");

                entity.HasOne(d => d.Codigo)
                    .WithMany(p => p.ConBalancecomparativos)
                    .HasForeignKey(d => new { d.CodigoEmpresa, d.CodigoTipo })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CON_TIPOCUENTA_CON_BALANCECOMPARATIVO");
            });

            modelBuilder.Entity<TmpCargaTxtBalancecontable>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEmpresa, e.Fecha, e.Cuenta });

                entity.ToTable("TMP_CARGA_TXT_BALANCECONTABLE");

                entity.Property(e => e.Fecha).HasMaxLength(8);

                entity.Property(e => e.Cuenta).HasMaxLength(30);

                entity.Property(e => e.Detalle)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.IdUsuario)
                    .IsRequired()
                    .HasMaxLength(450)
                    .HasColumnName("idUsuario");

                entity.HasOne(d => d.CodigoEmpresaNavigation)
                    .WithMany(p => p.TmpCargaTxtBalancecontables)
                    .HasForeignKey(d => d.CodigoEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PAR_EMPRESA_TMP_CARGA_TXT_BALANCECONTABLE");

                entity.HasOne(d => d.Codigo)
                    .WithMany(p => p.TmpCargaTxtBalancecontables)
                    .HasForeignKey(d => new { d.CodigoProceso, d.CodigoEmpresa })
                    .HasConstraintName("PAR_PROCESO_TMP_CARGA_TXT_BALANCECONTABLE");
            });

            modelBuilder.Entity<TmpCargaTxtCredito>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEmpresa, e.NumeroOperacion });

                entity.ToTable("TMP_CARGA_TXT_CREDITO");

                entity.Property(e => e.NumeroOperacion).HasMaxLength(16);

                entity.Property(e => e.ClasePrestamo)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.CodigoCliente)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FechaArchivo).HasColumnType("datetime");

                entity.Property(e => e.IdUsuario)
                    .IsRequired()
                    .HasMaxLength(450)
                    .HasColumnName("idUsuario");

                entity.Property(e => e.NombreCliente)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TipoCredito)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.HasOne(d => d.CodigoEmpresaNavigation)
                    .WithMany(p => p.TmpCargaTxtCreditos)
                    .HasForeignKey(d => d.CodigoEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PAR_EMPRESA_TMP_CARGA_TXT_CREDITO");

                entity.HasOne(d => d.Codigo)
                    .WithMany(p => p.TmpCargaTxtCreditos)
                    .HasForeignKey(d => new { d.CodigoProceso, d.CodigoEmpresa })
                    .HasConstraintName("PAR_PROCESO_TMP_CARGA_TXT_CREDITO");
            });

            modelBuilder.Entity<TmpCargaTxtDepositoplazo>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEmpresa, e.Cuenta });

                entity.ToTable("TMP_CARGA_TXT_DEPOSITOPLAZO");

                entity.Property(e => e.Cuenta).HasMaxLength(50);

                entity.Property(e => e.CodigoCliente)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CodigoEstado)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.CodigoSectorEconomico)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.FechaArchivo).HasColumnType("datetime");

                entity.Property(e => e.FormaPago)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.IdUsuario)
                    .IsRequired()
                    .HasMaxLength(450)
                    .HasColumnName("idUsuario");

                entity.Property(e => e.NombreCliente)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.CodigoEmpresaNavigation)
                    .WithMany(p => p.TmpCargaTxtDepositoplazos)
                    .HasForeignKey(d => d.CodigoEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PAR_EMPRESA_TMP_CARGA_TXT_DEPOSITOPLAZO");

                entity.HasOne(d => d.Codigo)
                    .WithMany(p => p.TmpCargaTxtDepositoplazos)
                    .HasForeignKey(d => new { d.CodigoProceso, d.CodigoEmpresa })
                    .HasConstraintName("PAR_PROCESO_TMP_CARGA_TXT_DEPOSITOPLAZO");
            });

            modelBuilder.Entity<TmpCargaTxtDepositoplazopignorado>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEmpresa, e.NumeroCuenta });

                entity.ToTable("TMP_CARGA_TXT_DEPOSITOPLAZOPIGNORADO");

                entity.Property(e => e.NumeroCuenta).HasMaxLength(50);

                entity.Property(e => e.CodigoCliente)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CodigoTipoGarantia)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.IdUsuario)
                    .IsRequired()
                    .HasMaxLength(450)
                    .HasColumnName("idUsuario");

                entity.Property(e => e.NombreCliente)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TipoDeposito)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.HasOne(d => d.CodigoEmpresaNavigation)
                    .WithMany(p => p.TmpCargaTxtDepositoplazopignorados)
                    .HasForeignKey(d => d.CodigoEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PAR_EMPRESA_TMP_CARGA_TXT_DEPOSITOPLAZOPIGNORADO");

                entity.HasOne(d => d.Codigo)
                    .WithMany(p => p.TmpCargaTxtDepositoplazopignorados)
                    .HasForeignKey(d => new { d.CodigoProceso, d.CodigoEmpresa })
                    .HasConstraintName("PAR_PROCESO_TMP_CARGA_TXT_DEPOSITOPLAZOPIGNORADO");
            });

            modelBuilder.Entity<TmpCargaExcelCreditoCalificacionesDef>(entity =>
            {
                entity.HasKey(e => e.NumOper)
                    .HasName("TMP_EXCEL_LOAN_CALIF$TMP_EXCEL_LOAN_CALIF_PK_INDEX");

                entity.ToTable("TMP_CARGA_EXCEL_CREDITO_CALIFICACIONES_DEF");

                entity.Property(e => e.NumOper)
                    .HasMaxLength(16)
                    .HasColumnName("num_oper");

                entity.Property(e => e.ClasPres)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnName("Clas_Pres");

                entity.Property(e => e.FechaCarga)
                    .HasPrecision(0)
                    .HasColumnName("Fecha_Carga");
            });

            modelBuilder.Entity<TmpCargaExcelMaestroTcDef>(entity =>
            {
                entity.HasKey(e => e.NumeroTarjeta)
                    .HasName("TMP_EXCEL_MAESTRO_TC$PK_NumeroTarjeta");

                entity.ToTable("TMP_CARGA_EXCEL_MAESTRO_TC_DEF");

                entity.Property(e => e.NumeroTarjeta).HasMaxLength(30);

                entity.Property(e => e.Centalta).HasMaxLength(10);

                entity.Property(e => e.CodigoCliente).HasMaxLength(30);

                entity.Property(e => e.Contrato).HasMaxLength(30);

                entity.Property(e => e.EstadoTarjeta).HasMaxLength(100);

                entity.Property(e => e.FechaEmision).HasPrecision(0);

                entity.Property(e => e.FechaVencimiento).HasPrecision(0);

                entity.Property(e => e.Identificacion).HasMaxLength(30);

                entity.Property(e => e.NombreCliente)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.SaldoAFavor).HasColumnName("Saldo_a_Favor");

                entity.Property(e => e.TcRelacionada).HasMaxLength(30);

                entity.Property(e => e.TipoIdentificacion).HasMaxLength(5);

                entity.Property(e => e.TipoProducto).HasMaxLength(100);

                entity.Property(e => e.TipoTarjeta).HasMaxLength(20);
            });

            modelBuilder.Entity<TmpCargaTxtCreditocalce>(entity =>
            {
                entity.HasKey(e => new { e.CodigoEmpresa, e.CodigoTipo, e.NumeroCredito });

                entity.ToTable("TMP_CARGA_TXT_CREDITOCALCE");

                entity.Property(e => e.CodigoTipo).HasMaxLength(1);

                entity.Property(e => e.NumeroCredito).HasMaxLength(15);

                entity.Property(e => e.IdUsuario)
                    .HasMaxLength(450)
                    .HasColumnName("idUsuario");

                entity.HasOne(d => d.CodigoEmpresaNavigation)
                    .WithMany(p => p.TmpCargaTxtCreditocalces)
                    .HasForeignKey(d => d.CodigoEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PAR_EMPRESA_TMP_CARGA_TXT_CREDITOCALCE");

                entity.HasOne(d => d.Codigo)
                    .WithMany(p => p.TmpCargaTxtCreditocalces)
                    .HasForeignKey(d => new { d.CodigoProceso, d.CodigoEmpresa })
                    .HasConstraintName("PAR_PROCESO_TMP_CARGA_TXT_CREDITOCALCE");
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
