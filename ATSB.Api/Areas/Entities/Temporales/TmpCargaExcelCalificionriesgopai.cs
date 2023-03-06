using System;
using System.Collections.Generic;

namespace ATSB.Api.Areas.Entities.Temporales
{
    public partial class TmpCargaExcelCalificionriesgopai
    {
        /// <summary>
        /// 1-Entity Name
        /// </summary>
        public string? EntityName { get; set; }
        /// <summary>
        /// 2-Riesgo Fitch
        /// </summary>
        public string? FitchRiesgo { get; set; }
        /// <summary>
        /// 3-Fitch Fecha Ultima Actualización
        /// </summary>
        public string? FitchFechaUltAct { get; set; }
        /// <summary>
        /// 4-Fitch Perspectiva
        /// </summary>
        public string? FitchPerspectiva { get; set; }
        /// <summary>
        /// 5-Moody Riesgo fc
        /// </summary>
        public string? MoodyRiesgoFc { get; set; }
        /// <summary>
        /// 6-Moody Fecha Ultima Actualización fc
        /// </summary>
        public string? MoodyFechaUltActFc { get; set; }
        /// <summary>
        /// 7-Moody Riesgo lc
        /// </summary>
        public string? MoodyRiesgoLc { get; set; }
        /// <summary>
        /// 8-Moody Fecha Ultima Actualización lc
        /// </summary>
        public string? MoodyFechaUltActLc { get; set; }
        /// <summary>
        /// 9-Moody Perspectiva
        /// </summary>
        public string? MoodyPerspectiva { get; set; }
        /// <summary>
        /// 10-SP Riesgo fc
        /// </summary>
        public string? SpRiesgoFc { get; set; }
        /// <summary>
        /// 11-SP Fecha Ultima Actualización fc
        /// </summary>
        public string? SpFechaUltActFc { get; set; }
        /// <summary>
        /// 12-SP Riesgo lc
        /// </summary>
        public string? SpRiesgoLc { get; set; }
        /// <summary>
        /// 13-SP Fecha Ultima Actualización lc
        /// </summary>
        public string? SpFechaUltActLc { get; set; }
        /// <summary>
        /// 14-SP Perspectiva
        /// </summary>
        public string? SpPerspectiva { get; set; }
        /// <summary>
        /// 0-NA
        /// </summary>
        public Guid Llave { get; set; }
    }
}
