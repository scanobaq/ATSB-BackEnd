using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Pasivo
{
    public class PasDetalleHistoricoRequest
    {
        public int CodigoEmpresa { get; set; }
        public string? NumeroOperacion { get; set; }
        public string? Fecha { get; set; }
        public int? CodigoSubsidiaria { get; set; }
        public int? TipoDeposito { get; set; }
        public int? TipoCliente { get; set; }
        public double? Tasa { get; set; }
        public string? Destino { get; set; }
        public int? CodigoPais { get; set; }
        public string? FechaInicio { get; set; }
        public string? FechaVencimiento { get; set; }
        public double? MontoPrincipal { get; set; }
        public double? MontoPignorado { get; set; }
        public int? NumeroRenovaciones { get; set; }
        public string? FechaRenovacion { get; set; }
        public double? InteresPorPagar { get; set; }
        public int? PeriodicidadPago { get; set; }
        public string? NombreCliente { get; set; }
        public int? Plazo { get; set; }
        public string? CodigoCliente { get; set; }
        public int? ClaseCliente { get; set; }
        public string? IdUsuario { get; set; }
    }
}
