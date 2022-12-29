using System;
using System.Collections.Generic;

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
    }
}
