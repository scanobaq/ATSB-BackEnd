using System;
using System.Collections.Generic;
using ATSB.Api.Areas.Entities.Parametros;

namespace ATSB.Api.Areas.Entities.Temporales
{
    public partial class TmpCargaTxtDepositoplazopignorado
    {
        public int CodigoEmpresa { get; set; }
        public string TipoDeposito { get; set; }
        public string NumeroCuenta { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string CodigoCliente { get; set; }
        public string NombreCliente { get; set; }
        public double Balance { get; set; }
        public double MontoPignorado { get; set; }
        public string CodigoTipoGarantia { get; set; }
        public string IdUsuario { get; set; }
        public int? CodigoProceso { get; set; }

        public virtual ParProceso Codigo { get; set; }
        public virtual ParEmpresa CodigoEmpresaNavigation { get; set; }
    }
}
