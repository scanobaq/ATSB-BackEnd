using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Pasivo
{
    public class PasMaestroRequest
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
    }
}
