using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Parametros
{
    public class ParProcesoRequest
    {
        public int CodigoProceso { get; set; }
        public int CodigoEmpresa { get; set; }
        public string Descripcion { get; set; }
        public string NombreProceso { get; set; }
        public string TablaDestino { get; set; }
    }
}
