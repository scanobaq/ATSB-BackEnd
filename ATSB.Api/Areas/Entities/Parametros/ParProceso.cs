using System;
using System.Collections.Generic;

namespace ATSB.Api.Areas.Entities.Parametros
{
    public partial class ParProceso
    {
        public int CodigoProceso { get; set; }
        public int CodigoEmpresa { get; set; }
        public string Descripcion { get; set; }
        public string NombreProceso { get; set; }
        public string TablaDestino { get; set; }

        public virtual ParEmpresa CodigoEmpresaNavigation { get; set; }
    }
}
