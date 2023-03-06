using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Temporales
{
    public class TmpCargaExcelMaestroTcGetRequest
    {
        public string? NumeroTarjeta { get; set; }
        public string? TipoIdentificacion { get; set; }
        public string? CodigoCliente { get; set; }
        public string? Identificacion { get; set; }
        public string? NombreCliente { get; set; }
        public string? CupoGlobal { get; set; }
        public string? SaldoCapital { get; set; }
        public string? SaldoTotal { get; set; }
        public string? Intereses { get; set; }
        public string? TasaIntereses { get; set; }
        public string? InteresXfinanciamiento { get; set; }
        public string? InteresesMora { get; set; }
        public string? Cargo { get; set; }
        public string? InteresExtracontable { get; set; }
        public string? SaldoAFavor { get; set; }
        public string? FechaEmision { get; set; }
        public string? FechaVencimiento { get; set; }
        public string? EstadoTarjeta { get; set; }
        public string? TipoTarjeta { get; set; }
        public string? TcRelacionada { get; set; }
        public string? TipoProducto { get; set; }
        public string? Centalta { get; set; }
        public string? Contrato { get; set; }
    }
}
