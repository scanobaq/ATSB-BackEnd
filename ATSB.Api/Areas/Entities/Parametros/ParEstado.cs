using System;
using System.Collections.Generic;
using ATSB.Api.Areas.Entities.Configuracion;

namespace ATSB.Api.Areas.Entities.Parametros
{
    /// <summary>
    /// Tabla ParEstado
    /// </summary>
    public partial class ParEstado
    {
        public ParEstado()
        {
            ParEmpresas = new HashSet<ParEmpresa>();
            ParSucursals = new HashSet<ParSucursal>();
            CnfTablavalors = new HashSet<CnfTablavalor>();
            CnfArchivocampos = new HashSet<CnfArchivocampo>();
            CnfTablagenericavalores = new HashSet<CnfTablagenericavalore>();
            CnfEjecucionreportes = new HashSet<CnfEjecucionreporte>();
            CnfEjecucionprocesos = new HashSet<CnfEjecucionproceso>();
            CnfRangomontodetalles = new HashSet<CnfRangomontodetalle>();
        }

        /// <summary>
        /// 1-Código
        /// </summary>
        public int CodigoEstado { get; set; }
        /// <summary>
        /// 2-Descripción
        /// </summary>
        public string Descripcion { get; set; }

        public virtual ICollection<ParEmpresa> ParEmpresas { get; set; }
        public virtual ICollection<ParSucursal> ParSucursals { get; set; }
        public virtual ICollection<CnfTablavalor> CnfTablavalors { get; set; }
        public virtual ICollection<CnfArchivocampo> CnfArchivocampos { get; set; }
        public virtual ICollection<CnfTablagenericavalore> CnfTablagenericavalores { get; set; }
        public virtual ICollection<CnfEjecucionreporte> CnfEjecucionreportes { get; set; }
        public virtual ICollection<CnfEjecucionproceso> CnfEjecucionprocesos { get; set; }
        public virtual ICollection<CnfRangomontodetalle> CnfRangomontodetalles { get; set; }
    }
}