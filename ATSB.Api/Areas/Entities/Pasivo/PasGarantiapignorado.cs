using System;
using System.Collections.Generic;
using ATSB.Api.Areas.Entities.Parametros;

namespace ATSB.Api.Areas.Entities.Pasivo
{
    public partial class PasGarantiapignorado
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

        public virtual ParEmpresa CodigoEmpresaNavigation { get; set; }
        public virtual ParEstado CodigoEstadoNavigation { get; set; }
    }
}
