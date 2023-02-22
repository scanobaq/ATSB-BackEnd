using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Temporales
{
    public class TmpCargaTxtBalanceContableGetRequest
    {
        public int CodigoEmpresa { get; set; }
        public string Fecha { get; set; }
        public string Cuenta { get; set; }
    }
}
