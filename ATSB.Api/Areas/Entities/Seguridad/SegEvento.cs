using System;
using System.Collections.Generic;
using ATSB.Api.Areas.Entities.Parametros;

namespace ATSB.Api.Areas.Entities.Seguridad
{
    public partial class SegEvento
    {
        public int CodigoEmpresa { get; set; }
        public int IdEvento { get; set; }
        public string? Descripción { get; set; }

        public virtual ParEmpresa CodigoEmpresaNavigation { get; set; }
    }
}
