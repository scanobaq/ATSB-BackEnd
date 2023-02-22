using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Seguridad
{
    public class SegConfiguracionGetRequest
    {
        public int CodigoEmpresa { get; set; }
        public int IdParametro { get; set; }
    }
}
