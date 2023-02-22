using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Configuracion
{
    public class CnfTablaGetRequest
    {
        public int CodigoEmpresa { get; set; }
        public int CodigoTabla { get; set; }
    }
}
