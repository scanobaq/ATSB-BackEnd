using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Contable
{
    public class ConTipoCuentaGetRequest
    {
        public int CodigoEmpresa { get; set; }
        public int CodigoTipo { get; set; }
    }
}
