using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Contable
{
    public class ConBalanceHistoricoRequest
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
    }
}
