using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Liquidez
{
    public class LiqInstrumentoRubroGetRequest
    {
        public int CodigoEmpresa { get; set; }
        public string? Instrumento { get; set; }
        public string? CodigoRegion { get; set; }
        public int CodigoRubro { get; set; }
    }
}
