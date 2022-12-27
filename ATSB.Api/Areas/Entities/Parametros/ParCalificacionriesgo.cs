using System;
using System.Collections.Generic;

namespace ATSB.Api.Areas.Entities.Parametros
{
    public partial class ParCalificacionriesgo
    {
        public int CodigoEmpresa { get; set; }
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public string? Moody { get; set; }
        public string? Fitch { get; set; }
        public string? Comp { get; set; }
        public string? Sp { get; set; }
        public string IdUsuario { get; set; }

        public virtual ParEmpresa CodigoEmpresaNavigation { get; set; }
    }
}
