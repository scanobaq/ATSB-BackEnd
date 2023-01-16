using System;
using System.Collections.Generic;
using ATSB.Api.Areas.Entities.Parametros;

namespace ATSB.Api.Areas.Entities.Pasivo
{
    public partial class PasMaestro
    {
        public int CodigoEmpresa { get; set; }
        public string? NumeroCuenta { get; set; }
        public int? CodigoTipoDeposito { get; set; }
        public int? CodigoTipoCliente { get; set; }
        public string? DestinoLocalExtranjero { get; set; }
        public int? CodigoPais { get; set; }
        public DateTime? FechaInicioReal { get; set; }
        public DateTime? FechaInicio { get; set; }
        public string? IndicadorRelacionBanco { get; set; }
        public string? IdUsuario { get; set; }
        public DateTime? FechaArchivo { get; set; }

        public virtual ParEmpresa CodigoEmpresaNavigation { get; set; }
    }
}
