using System;
using System.Collections.Generic;
using ATSB.Api.Areas.Entities.Parametros;

namespace ATSB.Api.Areas.Entities.Seguridad
{
    public partial class SegConfiguracion
    {
        public int CodigoEmpresa { get; set; }
        public int IdParametro { get; set; }
        public DateTime? FechaHoraIngreso { get; set; }
        public int? CantidadDiasVigenciaPassword { get; set; }
        public int? CantidadMinimaCaracteresClave { get; set; }
        public int? CantidadIntentosFallidos { get; set; }
        public bool? IndicadorPermiteRepetirPassword { get; set; }
        public int? CantidadClavesParaRepetir { get; set; }
        public int? CantidadMayusculasClave { get; set; }
        public int? CantidadNumeroClave { get; set; }
        public int? CantidadCaracterEspecial { get; set; }
        public string? IdUsuario { get; set; }
        public int? CodigoEstado { get; set; }

        public virtual ParEmpresa CodigoEmpresaNavigation { get; set; }
        public virtual ParEstado CodigoEstadoNavigation { get; set; }
    }
}
