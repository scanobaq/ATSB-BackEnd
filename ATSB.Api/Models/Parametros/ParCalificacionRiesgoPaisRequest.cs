using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Parametros
{
    public class ParCalificacionRiesgoPaisRequest
    {
        public int CodigoEmpresa { get; set; }
        public int CodigoPais { get; set; }
        public string? FechaUltimaActualizacionFitch { get; set; }
        public string? CodigoCalificacionFitch { get; set; }
        public int? PerspectivaFitch { get; set; }
        public int? NumeroCalificacionFitch { get; set; }
        public string? FechaUltimaActualizacionMoody { get; set; }
        public string? CodigoCalificacionMoody { get; set; }
        public int? PerspectivaMoody { get; set; }
        public int? NumeroCalificacionMoody { get; set; }
        public string? FechaUltimaActualizacionSp { get; set; }
        public string? CodigoCalificacionSp { get; set; }
        public int? PerspectivaSp { get; set; }
        public int? NumeroCalificacionSp { get; set; }
        public double? Pd { get; set; }
        public double? Pdajustada { get; set; }
        public double? Pdfinal { get; set; }
        public int? Perspectiva { get; set; }
        public int? NumeroCalificacionPais { get; set; }
        public int? CalficacionAjustada { get; set; }
        public DateTime? FechaUltimaActualizacion { get; set; }
        public double? ForwardLooking { get; set; }
        public string? IdUsuario { get; set; }
    }
}
