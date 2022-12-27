using System;
using System.Collections.Generic;

namespace ATSB.Api.Areas.Entities.Parametros
{
    /// <summary>
    /// Tabla ParPais
    /// </summary>
    public partial class ParPai
    {
        public ParPai()
        {
            ParTipoidentificacions = new HashSet<ParTipoidentificacion>();
            ParEmpresas = new HashSet<ParEmpresa>();
        }

        /// <summary>
        /// 1-Código
        /// </summary>
        public int CodigoPais { get; set; }
        /// <summary>
        /// 2-Nombre
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// 3-ISO Númerico
        /// </summary>
        public int? CodigoIsonumerico { get; set; }
        /// <summary>
        /// 4-ISO Alfa2
        /// </summary>
        public string CodigoIsoalfa2 { get; set; }
        /// <summary>
        /// 5-ISO Alfa3
        /// </summary>
        public string CodigoIsoalfa3 { get; set; }
        /// <summary>
        /// 6-Formato Teléfono Fijo
        /// </summary>
        public string FormatoTelefonoFijo { get; set; }
        /// <summary>
        /// 7-Formato Teléfono Celular
        /// </summary>
        public string FormatoTelefonoCelular { get; set; }

        
        public virtual ICollection<ParTipoidentificacion> ParTipoidentificacions { get; set; }
        public virtual ICollection<ParEmpresa> ParEmpresas { get; set; }
    }
}
