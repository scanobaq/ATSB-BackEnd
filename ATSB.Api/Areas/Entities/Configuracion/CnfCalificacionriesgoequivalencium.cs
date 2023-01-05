using System;
using System.Collections.Generic;
using ATSB.Api.Areas.Entities.Parametros;

namespace ATSB.Api.Areas.Entities.Configuracion
{
    public partial class CnfCalificacionriesgoequivalencium
    {
        public int CodigoEmpresa { get; set; }
        public string CalificacionOrigen { get; set; }
        public string CalificacionDestino { get; set; }
        public int? NumeroCalificacion { get; set; }
        public string IdUsuario { get; set; }

        public virtual ParEmpresa CodigoEmpresaNavigation { get; set; }
    }
}
