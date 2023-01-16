using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Liquidez
{
    public class LiqRubroProcesoRequest
    {
        public int CodigoEmpresa { get; set; }
        public int Rubro { get; set; }
        public int? Proceso { get; set; }
        public string? IdUsuario { get; set; }
    }
}
