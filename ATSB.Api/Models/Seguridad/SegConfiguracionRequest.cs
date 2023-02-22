using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Seguridad
{
    public class SegConfiguracionRequest
    {
        public int CodigoEmpresa { get; set; }
        public int IdParametro { get; set; }
        public DateTime? FechaHoraIngreso { get; set; }
        public int? CantidadDiasVigenciaPassword { get; set; }
        public int? CantidadMinimaCaracteresClave { get; set; }
        public int? CantidadIntentosFallidos { get; set; }
        public string? IndicadorPermiteRepetirPassword { get; set; }
        public int? CantidadClavesParaRepetir { get; set; }
        public int? CantidadMayusculasClave { get; set; }
        public int? CantidadNumeroClave { get; set; }
        public int? CantidadCaracterEspecial { get; set; }
        public string? IdUsuario { get; set; }
        public int? CodigoEstado { get; set; }
    }
}
