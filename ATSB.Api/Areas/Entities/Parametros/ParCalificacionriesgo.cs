using System;
using System.Collections.Generic;
using ATSB.Api.Areas.Entities.Contable;

namespace ATSB.Api.Areas.Entities.Parametros
{
    public partial class ParCalificacionriesgo
    {
        public ParCalificacionriesgo()
        {
            ConCuentaliquidezs = new HashSet<ConCuentaliquidez>();
        }

        public int CodigoEmpresa { get; set; }
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public string? Moody { get; set; }
        public string? Fitch { get; set; }
        public string? Comp { get; set; }
        public string? Sp { get; set; }
        public string IdUsuario { get; set; }

        public virtual ParEmpresa CodigoEmpresaNavigation { get; set; }
        public virtual ICollection<ConCuentaliquidez> ConCuentaliquidezs { get; set; }
    }
}
