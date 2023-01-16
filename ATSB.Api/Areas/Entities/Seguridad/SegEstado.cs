using System;
using System.Collections.Generic;
using ATSB.Api.Areas.Entities.Parametros;

namespace ATSB.Api.Areas.Entities.Seguridad
{
    public partial class SegEstado
    {
        public int CodigoEmpresa { get; set; }
        public string? CodigoEstado { get; set; }
        public string? Descripcion { get; set; }

        public virtual ParEmpresa CodigoEmpresaNavigation { get; set; }
    }
}
