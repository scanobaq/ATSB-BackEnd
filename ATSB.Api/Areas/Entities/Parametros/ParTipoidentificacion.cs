using System;
using System.Collections.Generic;

namespace ATSB.Api.Areas.Entities.Parametros
{
    /// <summary>
    /// Tabla ParTipoIdentificacion
    /// </summary>
    public partial class ParTipoidentificacion
    {
        public ParTipoidentificacion()
        {
            ParEmpresas = new HashSet<ParEmpresa>();
        }

        /// <summary>
        /// 2-Código
        /// </summary>
        public int CodigoTipoIdentificacion { get; set; }
        /// <summary>
        /// 3-Descripcion
        /// </summary>
        public string Descripcion { get; set; }
        /// <summary>
        /// 4-Formato
        /// </summary>
        public string? Formato { get; set; }
        /// <summary>
        /// 5-Longitud
        /// </summary>
        public int? Longitud { get; set; }
        /// <summary>
        /// 6-Es Física
        /// </summary>
        public bool? IndicadorFisica { get; set; }
        /// <summary>
        /// 7-Ultima Modificación
        /// </summary>
        public DateTime? FechaUltimaModificacion { get; set; }
        /// <summary>
        /// 8-Usuario Modificación
        /// </summary>
        public string? UsuarioModifica { get; set; }
        /// <summary>
        /// 0-NoAplica
        /// </summary>
        public int? CantidadModificaciones { get; set; }
        /// <summary>
        /// 9-Código Factura Electrónica
        /// </summary>
        public string? CodigoFacturaElectronica { get; set; }
        /// <summary>
        /// 1-País
        /// </summary>
        public int CodigoPais { get; set; }

        public virtual ParPai CodigoPaisNavigation { get; set; }
        public virtual ICollection<ParEmpresa> ParEmpresas { get; set; }
    }
}
