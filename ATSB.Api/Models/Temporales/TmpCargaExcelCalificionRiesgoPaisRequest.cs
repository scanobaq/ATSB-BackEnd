using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Temporales
{
    public class TmpCargaExcelCalificionRiesgoPaisRequest
    {
        public string? EntityName { get; set; }
        public string? FitchRiesgo { get; set; }
        public string? FitchFechaUltAct { get; set; }
        public string? FitchPerspectiva { get; set; }
        public string? MoodyRiesgoFc { get; set; }
        public string? MoodyFechaUltActFc { get; set; }
        public string? MoodyRiesgoLc { get; set; }
        public string? MoodyFechaUltActLc { get; set; }
        public string? MoodyPerspectiva { get; set; }
        public string? SpRiesgoFc { get; set; }
        public string? SpFechaUltActFc { get; set; }
        public string? SpRiesgoLc { get; set; }
        public string? SpFechaUltActLc { get; set; }
        public string? SpPerspectiva { get; set; }
        public Guid Llave { get; set; }
    }
}
