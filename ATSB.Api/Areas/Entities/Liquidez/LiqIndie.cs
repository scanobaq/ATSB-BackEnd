using System;
using System.Collections.Generic;
using ATSB.Api.Areas.Entities.Parametros;

namespace ATSB.Api.Areas.Entities.Liquidez
{
    public partial class LiqIndie
    {
        public int CodigoEmpresa { get; set; }
        public string? Tipo { get; set; }
        public int? Rubro { get; set; }
        public double? Porcentaje { get; set; }
        public double? Multiplicador { get; set; }
        public string? IdUsuario { get; set; }
        public string? TipoDescipcion { get; set; }

        public virtual ParEmpresa CodigoEmpresaNavigation { get; set; }
    }
}
