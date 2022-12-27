using System;
using System.Collections.Generic;

namespace ATSB.Api.Areas.Entities.Parametros
{
    /// <summary>
    /// Tabla ParConsecutivo
    /// </summary>
    public partial class ParConsecutivo
    {
        /// <summary>
        /// 1-Empresa
        /// </summary>
        public int CodigoEmpresa { get; set; }
        /// <summary>
        /// 2-Id
        /// </summary>
        public string IdConsecutivo { get; set; }
        /// <summary>
        /// 3-Descripción
        /// </summary>
        public int NumeroConsecutivo { get; set; }

        public virtual ParEmpresa CodigoEmpresaNavigation { get; set; }
    }
}
