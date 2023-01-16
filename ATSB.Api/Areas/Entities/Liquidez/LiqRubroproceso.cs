using System;
using System.Collections.Generic;
using ATSB.Api.Areas.Entities.Parametros;

namespace ATSB.Api.Areas.Entities.Liquidez
{
    public partial class LiqRubroproceso
    {
        public int CodigoEmpresa { get; set; }
        public int Rubro { get; set; }
        public int? Proceso { get; set; }
        public string? IdUsuario { get; set; }

        public virtual ParEmpresa CodigoEmpresaNavigation { get; set; }
    }
}
