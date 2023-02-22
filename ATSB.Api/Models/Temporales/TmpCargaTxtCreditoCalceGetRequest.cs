using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Temporales
{
    public class TmpCargaTxtCreditoCalceGetRequest
    {
        public int CodigoEmpresa { get; set; }
        public string CodigoTipo { get; set; }
        public string NumeroCredito { get; set; }
    }
}
