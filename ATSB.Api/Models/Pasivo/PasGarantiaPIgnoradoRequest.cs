using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Pasivo
{
    public class PasGarantiaPIgnoradoRequest
    {
        public int CodigoEmpresa { get; set; }
        public string? NumeroCuenta { get; set; }
        public string? NumeroOperacionGarantia { get; set; }
        public double? SaldoOperacionGarantia { get; set; }
        public DateTime? FechaVencimientoOperacionGarantia { get; set; }
        public string? NumeroClienteOperacionGarantia { get; set; }
        public string? Agrupa { get; set; }
        public int? CodigoEstado { get; set; }
        public string? IdUsuario { get; set; }
    }
}
