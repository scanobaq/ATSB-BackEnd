using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Parametros
{
    public class ParTipoCambioGetRequest
    {
        public int CodigoEmpresa { get; set; }
        public DateTime Fecha { get; set; }
        public int CodigoMoneda { get; set; }
    }
}
