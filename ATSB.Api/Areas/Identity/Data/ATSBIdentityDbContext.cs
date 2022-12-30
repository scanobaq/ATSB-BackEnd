using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ATSB.Api.Areas.Entities.Parametros;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ATSB.Api.Areas.Identity.Entities.Security;
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

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
