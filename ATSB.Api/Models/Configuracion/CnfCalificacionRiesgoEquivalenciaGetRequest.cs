using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Configuracion
{
    public class CnfCalificacionRiesgoEquivalenciaGetRequest
    {
        public int CodigoEmpresa { get; set; }
        public string CalificacionOrigen { get; set; }
    }
}
