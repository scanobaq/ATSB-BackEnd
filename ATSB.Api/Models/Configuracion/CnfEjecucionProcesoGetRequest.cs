using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Configuracion
{
    public class CnfEjecucionProcesoGetRequest
    {
        public int CodigoEmpresa { get; set; }
        public int CodigoProceso { get; set; }
        public int SecuenciaProceso { get; set; }
    }
}
