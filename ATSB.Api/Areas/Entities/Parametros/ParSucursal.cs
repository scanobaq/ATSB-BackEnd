using System;
using System.Collections.Generic;

namespace ATSB.Api.Areas.Entities.Parametros
{
    public partial class ParSucursal
    {
        /// <summary>
        /// 1-Empresa
        /// </summary>
        public int CodigoEmpresa { get; set; }
        /// <summary>
        /// 10-Centro de Costo
        /// </summary>
        public int CodigoBanco { get; set; }
        /// <summary>
        /// 2-Código
        /// </summary>
        public int CodigoSucursal { get; set; }
        /// <summary>
        /// 3-Nombre
        /// </summary>
        public string NombreSucursal { get; set; }
        /// <summary>
        /// 5-Provincia
        /// </summary>
        public int? CodigoSubsidiaria { get; set; }
        /// <summary>
        /// 4-País
        /// </summary>
        public string CodigoOrigen { get; set; }
        /// <summary>
        /// 6-Cantón
        /// </summary>
        public int? CodigoPais { get; set; }
        /// <summary>
        /// 6-Cantón
        /// </summary>
        public int? TipoEstablecimiento { get; set; }
        /// <summary>
        /// 7-Dirección
        /// </summary>
        public string Direccion { get; set; }
        /// <summary>
        /// 9-Teléfono
        /// </summary>
        public string Telefono1 { get; set; }
        /// <summary>
        /// 8-Encargado
        /// </summary>
        public string Encargado { get; set; }
        /// <summary>
        /// 9-Teléfono
        /// </summary>
        public string Telefono2 { get; set; }
        /// <summary>
        /// 9-Teléfono
        /// </summary>
        public string Fax { get; set; }
        public string NombreResponsable { get; set; }
        public int? CargoResposable { get; set; }
        public int? CodigoEstado { get; set; }
        /// <summary>
        /// 0-No Aplica
        /// </summary>
        public string IdUsuario { get; set; }

        public virtual ParEmpresa CodigoEmpresaNavigation { get; set; }
        public virtual ParEstado CodigoEstadoNavigation { get; set; }
    }
}
