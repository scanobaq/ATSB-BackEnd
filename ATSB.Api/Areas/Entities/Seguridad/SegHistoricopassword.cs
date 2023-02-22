using System;
using System.Collections.Generic;
using ATSB.Api.Areas.Entities.Parametros;

namespace ATSB.Api.Areas.Entities.Seguridad
{
    public partial class SegHistoricopassword
    {
        public int CodigoEmpresa { get; set; }
        public string? IdUsuario { get; set; }
        public DateTime FechaHoraCambio { get; set; }
        public string? DescripcionPassword { get; set; }

        public virtual ParEmpresa CodigoEmpresaNavigation { get; set; }
    }
}
