using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Liquidez
{
    public class LiqIndiceRequest
    {
        public int CodigoEmpresa { get; set; }
        public string? Tipo { get; set; }
        public int? Rubro { get; set; }
        public double? Porcentaje { get; set; }
        public double? Multiplicador { get; set; }
        public string? IdUsuario { get; set; }
        public string? TipoDescipcion { get; set; }
    }
}
