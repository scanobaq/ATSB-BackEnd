using System;
using System.Collections.Generic;
using ATSB.Api.Areas.Entities.Parametros;

namespace ATSB.Api.Areas.Entities.Contable
{
    public partial class ConBalancehistorico
    {
        public int CodigoEmpresa { get; set; }
        public DateTime Fecha { get; set; }
        public int CodigoCuentaContable { get; set; }
        public double SaldoInicio { get; set; }
        public double Debito { get; set; }
        public double Credito { get; set; }
        public double DiferenciaSaldos { get; set; }
        public double SaldoFinal { get; set; }
        public string? IdUsuario { get; set; }

        public virtual ParEmpresa CodigoEmpresaNavigation { get; set; }
    }
}
