using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Configuracion
{
    public class CnfRangoMontoDetalleRequest
    {
        public int CodigoEmpresa { get; set; }
        public int CodigoTabla { get; set; }
        public string? CodigoRango { get; set; }
        public string? Descripcion { get; set; }
        public double? RangoMinimo { get; set; }
        public double? RangoMaximo { get; set; }
        public string? RangoValor { get; set; }
        public int? CodigoEstado { get; set; }
        public string? IdUsuario { get; set; }
    }
}
