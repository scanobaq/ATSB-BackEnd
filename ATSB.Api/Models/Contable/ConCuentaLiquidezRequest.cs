using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Contable
{
    public class ConCuentaLiquidezRequest
    {
        public int CodigoEmpresa { get; set; }
        public int CuentaLiquidez { get; set; }
        public int CuentaContableLocal { get; set; }
        public string? Agrupar { get; set; }
        public double? Porcentaje { get; set; }
        public string? FechaAdquisicion { get; set; }
        public string? NombreEnte { get; set; }
        public string? DestinoLocalExtranjero { get; set; }
        public int? CodigoPais { get; set; }
        public string? CodigoRelacionBanco { get; set; }
        public int? CodigoCalificacionRiesgo { get; set; }
        public double? Tasa { get; set; }
        public string? CodigoEstado { get; set; }
        public string? IdUsuario { get; set; }
    }
}
