using System;
using System.Collections.Generic;
using ATSB.Api.Areas.Entities.Configuracion;

namespace ATSB.Api.Areas.Entities.Parametros
{
    public partial class ParTipoorigendato
    {
        public ParTipoorigendato()
        {
            CnfEjecucionreportes = new HashSet<CnfEjecucionreporte>();
            CnfEjecucionprocesos = new HashSet<CnfEjecucionproceso>();
        }

        public int CodigoOrigenDatos { get; set; }
        public int CodigoEmpresa { get; set; }
        public string? Descripcion { get; set; }
        public string? DelimitadorDatos { get; set; }

        public virtual ParEmpresa CodigoEmpresaNavigation { get; set; }
        public virtual ICollection<CnfEjecucionreporte> CnfEjecucionreportes { get; set; }
        public virtual ICollection<CnfEjecucionproceso> CnfEjecucionprocesos { get; set; }
    }
}
