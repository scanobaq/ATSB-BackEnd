using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Contable
{
    public class ConBalanceComparativoRequest
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
    }
}
