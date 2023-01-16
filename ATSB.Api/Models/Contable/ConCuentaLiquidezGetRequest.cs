using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Contable
{
    public class ConCuentaLiquidezGetRequest
    {
        public int CodigoEmpresa { get; set; }
        public int CuentaLiquidez { get; set; }
        public int CuentaContableLocal { get; set; }
    }
}
