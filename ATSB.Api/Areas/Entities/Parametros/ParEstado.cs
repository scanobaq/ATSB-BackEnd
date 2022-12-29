using System;
using System.Collections.Generic;

namespace ATSB.Api.Areas.Entities.Parametros
{
    /// <summary>
    /// Tabla ParEstado
    /// </summary>
    public partial class ParEstado
    {
        public ParEstado()
        {
            ParEmpresas = new HashSet<ParEmpresa>();
            ParSucursals = new HashSet<ParSucursal>();
        }

        /// <summary>
        /// 1-Código
        /// </summary>
        public int CodigoEstado { get; set; }
        /// <summary>
        /// 2-Descripción
        /// </summary>
        public string Descripcion { get; set; }

        public virtual ICollection<ParEmpresa> ParEmpresas { get; set; }
        public virtual ICollection<ParSucursal> ParSucursals { get; set; }
    }
}