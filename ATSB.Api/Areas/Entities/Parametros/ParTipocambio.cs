using System;
using System.Collections.Generic;

namespace ATSB.Api.Areas.Entities.Parametros
{
    public partial class ParTipocambio
    {
        public int CodigoEmpresa { get; set; }
        public DateTime Fecha { get; set; }
        public int CodigoMoneda { get; set; }
        public double? TipoCambio { get; set; }
        public string Id { get; set; }

        public virtual ParMonedum Codigo { get; set; }
        public virtual ParEmpresa CodigoEmpresaNavigation { get; set; }
    }
}
