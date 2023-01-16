using System;
using System.Collections.Generic;
using ATSB.Api.Areas.Entities.Parametros;

namespace ATSB.Api.Areas.Entities.Contable
{
    public partial class ConCatalogoequivalencium
    {
        public int CodigoEmpresa { get; set; }
        public int IdCuenta { get; set; }
        public string? CuentaContableLocal { get; set; }
        public int? CuentaContableAnteriorSuperIntendencia { get; set; }
        public string? NombreCuenta { get; set; }
        public int? CodigoTipo { get; set; }
        public string? Destino { get; set; }
        public int? CodigoPais { get; set; }
        public int? CuentaContableSuperIntendencia { get; set; }
        public string? IdUsuario { get; set; }

        public virtual ConTipocuentum Codigo { get; set; }
        public virtual ParEmpresa CodigoEmpresaNavigation { get; set; }
    }
}
