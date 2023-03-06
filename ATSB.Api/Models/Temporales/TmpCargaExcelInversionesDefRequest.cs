using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Temporales
{
    public class TmpCargaExcelInversionesDefRequest
    {
        public string? Fecha { get; set; }
        public string? CodBanco { get; set; }
        public string? CodSubsidiaria { get; set; }
        public string? CodRubro { get; set; }
        public string? FechaEmision { get; set; }
        public string? FechaAdquisicion { get; set; }
        public string? FechaVencimiento { get; set; }
        public string? Ente { get; set; }
        public string? Destino { get; set; }
        public string? CodRegion { get; set; }
        public string? BancoRelacion { get; set; }
        public string? InstrObligacion { get; set; }
        public string? RiesgoFitch { get; set; }
        public string? RiesgoMoody { get; set; }
        public string? RiesgoSp { get; set; }
        public string? Garante { get; set; }
        public double? ValLibros { get; set; }
        public double? ValNominal { get; set; }
        public double? ValorMercado { get; set; }
        public double? Tasa { get; set; }
        public double? IntXCobrar { get; set; }
        public string? Ticket { get; set; }
        public string? Cupon { get; set; }
        public string? EscaladaFitch { get; set; }
        public string? EscaladaMoody { get; set; }
        public string? EscaladaSp { get; set; }
        public Guid? Llave { get; set; }
    }
}
