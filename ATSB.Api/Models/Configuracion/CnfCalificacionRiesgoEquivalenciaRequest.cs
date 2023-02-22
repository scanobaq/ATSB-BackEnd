using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Configuracion
{
    public class CnfCalificacionRiesgoEquivalenciaRequest
    {
        public int CodigoEmpresa { get; set; }
        public string CalificacionOrigen { get; set; }
        public string CalificacionDestino { get; set; }
        public int? NumeroCalificacion { get; set; }
        public string IdUsuario { get; set; }
    }
}
