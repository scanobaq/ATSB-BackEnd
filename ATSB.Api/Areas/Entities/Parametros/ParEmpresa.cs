using System;
using System.Collections.Generic;
using ATSB.Api.Areas.Entities.Configuracion;
using ATSB.Api.Areas.Entities.Contable;
using ATSB.Api.Areas.Entities.Credito;
using ATSB.Api.Areas.Entities.Liquidez;
using ATSB.Api.Areas.Entities.Pasivo;
using ATSB.Api.Areas.Entities.Seguridad;

namespace ATSB.Api.Areas.Entities.Parametros
{
    /// <summary>
    /// Tabla ParEmpresa
    /// </summary>
    public partial class ParEmpresa
    {
        public ParEmpresa()
        {
            ParConsecutivos = new HashSet<ParConsecutivo>();
            ParProcesos = new HashSet<ParProceso>();
            ParTipoorigendatos = new HashSet<ParTipoorigendato>();
            ParCalificacionriesgos = new HashSet<ParCalificacionriesgo>();
            ParMoneda = new HashSet<ParMonedum>();
            ParTipocambios = new HashSet<ParTipocambio>();
            ParSucursals = new HashSet<ParSucursal>();
            CnfCalificacionriesgoequivalencia = new HashSet<CnfCalificacionriesgoequivalencium>();
            CnfTablagenericas = new HashSet<CnfTablagenerica>();
            CnfTablas = new HashSet<CnfTabla>();
            CnfArchivos = new HashSet<CnfArchivo>();
            CnfEjecucionreportes = new HashSet<CnfEjecucionreporte>();
            CnfRangomontoencabezados = new HashSet<CnfRangomontoencabezado>();
            CnfEjecucionprocesos = new HashSet<CnfEjecucionproceso>();
            CnfRangomontodetalles = new HashSet<CnfRangomontodetalle>();
            ConTipocuenta = new HashSet<ConTipocuentum>();
            ConCatalogoequivalencia = new HashSet<ConCatalogoequivalencium>();
            ConCuentaliquidezs = new HashSet<ConCuentaliquidez>();
            ConBalancehistoricos = new HashSet<ConBalancehistorico>();
            ParCalificacionriesgopais = new HashSet<ParCalificacionriesgopai>();
            CreMaestros = new HashSet<CreMaestro>();
            LiqRubroprocesos = new HashSet<LiqRubroproceso>();
            LiqIndice = new HashSet<LiqIndie>();
            LiqInstrumentorubros = new HashSet<LiqInstrumentorubro>();
            PasMaestros = new HashSet<PasMaestro>();
            PasCuentaliquidezs = new HashSet<PasCuentaliquidez>();
            PasDetallehistoricos = new HashSet<PasDetallehistorico>();
            PasGarantiapignorados = new HashSet<PasGarantiapignorado>();
            SegEstados = new HashSet<SegEstado>();
            SegEventos = new HashSet<SegEvento>();
            SegHistoricopasswords = new HashSet<SegHistoricopassword>();
            SegConfiguracions = new HashSet<SegConfiguracion>();
        }

        /// <summary>
        /// 1-Código
        /// </summary>
        public int CodigoEmpresa { get; set; }
        /// <summary>
        /// 2-Nombre
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// 4-# Identificación
        /// </summary>
        public string NumeroId { get; set; }
        /// <summary>
        /// 6-Teléfono
        /// </summary>
        public string Telefono1 { get; set; }
        /// <summary>
        /// 7-Teléfono
        /// </summary>
        public string Telefono2 { get; set; }
        /// <summary>
        /// 8-Fecha Ingreso
        /// </summary>
        public DateTime FechaIngreso { get; set; }
        /// <summary>
        /// 9-Usuario Ingreso
        /// </summary>
        public string IdUsuario { get; set; }
        /// <summary>
        /// 11-Ultima Modificación
        /// </summary>
        public DateTime? FechaUltimaModificacion { get; set; }
        /// <summary>
        /// 12-Usuario Ultima Modficación
        /// </summary>
        public string? UsuarioModifica { get; set; }
        /// <summary>
        /// 0-NoAplica
        /// </summary>
        public int? CantidadModificaciones { get; set; }
        /// <summary>
        /// 3-Tipo Id
        /// </summary>
        public int CodigoTipoIdentificacion { get; set; }
        /// <summary>
        /// 5-País
        /// </summary>
        public int CodigoPais { get; set; }
        /// <summary>
        /// 10-Estado
        /// </summary>
        public int CodigoEstado { get; set; }
        public string CodigoBancoRegulador { get; set; }

        public virtual ParTipoidentificacion Codigo { get; set; }
        public virtual ParEstado CodigoEstadoNavigation { get; set; }
        public virtual ParPai CodigoPaisNavigation { get; set; }
        
        public virtual ICollection<ParConsecutivo> ParConsecutivos { get; set; }
        public virtual ICollection<ParProceso> ParProcesos { get; set; }
        public virtual ICollection<ParTipoorigendato> ParTipoorigendatos { get; set; }
        public virtual ICollection<ParCalificacionriesgo> ParCalificacionriesgos { get; set; }
        public virtual ICollection<ParMonedum> ParMoneda { get; set; }
        public virtual ICollection<ParTipocambio> ParTipocambios { get; set; }
        public virtual ICollection<ParSucursal> ParSucursals { get; set; }
        public virtual ICollection<CnfCalificacionriesgoequivalencium> CnfCalificacionriesgoequivalencia { get; set; }
        public virtual ICollection<CnfTablagenerica> CnfTablagenericas { get; set; }
        public virtual ICollection<CnfTabla> CnfTablas { get; set; }
        public virtual ICollection<CnfArchivo> CnfArchivos { get; set; }
        public virtual ICollection<CnfEjecucionreporte> CnfEjecucionreportes { get; set; }
        public virtual ICollection<CnfRangomontoencabezado> CnfRangomontoencabezados { get; set; }
        public virtual ICollection<CnfEjecucionproceso> CnfEjecucionprocesos { get; set; }
        public virtual ICollection<CnfRangomontodetalle> CnfRangomontodetalles { get; set; }
        public virtual ICollection<ConTipocuentum> ConTipocuenta { get; set; }
        public virtual ICollection<ConCatalogoequivalencium> ConCatalogoequivalencia { get; set; }
        public virtual ICollection<ConCuentaliquidez> ConCuentaliquidezs { get; set; }
        public virtual ICollection<ConBalancehistorico> ConBalancehistoricos { get; set; }
        public virtual ICollection<ParCalificacionriesgopai> ParCalificacionriesgopais { get; set; }
        public virtual ICollection<CreMaestro> CreMaestros { get; set; }
        public virtual ICollection<LiqRubroproceso> LiqRubroprocesos { get; set; }
        public virtual ICollection<LiqIndie> LiqIndice { get; set; }
        public virtual ICollection<LiqInstrumentorubro> LiqInstrumentorubros { get; set; }
        public virtual ICollection<PasMaestro> PasMaestros { get; set; }
        public virtual ICollection<PasCuentaliquidez> PasCuentaliquidezs { get; set; }
        public virtual ICollection<PasDetallehistorico> PasDetallehistoricos { get; set; }
        public virtual ICollection<PasGarantiapignorado> PasGarantiapignorados { get; set; }

        public virtual ICollection<SegEstado> SegEstados { get; set; }
        public virtual ICollection<SegEvento> SegEventos { get; set; }
        public virtual ICollection<SegHistoricopassword> SegHistoricopasswords { get; set; }
        public virtual ICollection<SegConfiguracion> SegConfiguracions { get; set; }
    }
}
