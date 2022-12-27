using System;
using System.Collections.Generic;

namespace ATSB.Api.Areas.Entities.Parametros
{
    public partial class ParTipoorigendato
    {
        public int CodigoOrigenDatos { get; set; }
        public int CodigoEmpresa { get; set; }
        public string? Descripcion { get; set; }
        public string? DelimitadorDatos { get; set; }

        public virtual ParEmpresa CodigoEmpresaNavigation { get; set; }
    }
}
