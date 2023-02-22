using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Liquidez
{
    public class LiqIndiceGetRequest
    {
        public int CodigoEmpresa { get; set; }
        public string? Tipo { get; set; }
        public int? Rubro { get; set; }
    }
}
