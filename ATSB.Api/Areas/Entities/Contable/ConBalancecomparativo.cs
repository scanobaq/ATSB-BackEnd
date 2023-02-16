using System;
using System.Collections.Generic;
using ATSB.Api.Areas.Entities.Parametros;

namespace ATSB.Api.Areas.Entities.Contable
{
    public partial class ConBalancecomparativo
    {
        public int CodigoEmpresa { get; set; }
        public DateTime FechaInicio { get; set; }
        public int? CodigoCuentaContableInicio { get; set; }
        public double SaldoInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public int? CodigoCuentaContableFinal { get; set; }
        public double SaldoFinal { get; set; }
        public double DiferenciaSaldos { get; set; }
        public double Variacion { get; set; }
        public int CodigoTipo { get; set; }
        public string IdUsuario { get; set; }
        public Guid Llave { get; set; }

        public virtual ConTipocuentum Codigo { get; set; }
        public virtual ParEmpresa CodigoEmpresaNavigation { get; set; }
    }
}
