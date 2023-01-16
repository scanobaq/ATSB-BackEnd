using System;
using System.Collections.Generic;
using ATSB.Api.Areas.Entities.Parametros;

namespace ATSB.Api.Areas.Entities.Contable
{
    public partial class ConCuentaliquidez
    {
        public int CodigoEmpresa { get; set; }
        public int CuentaLiquidez { get; set; }
        public int CuentaContableLocal { get; set; }
        public bool? Agrupar { get; set; }
        public double? Porcentaje { get; set; }
        public string? FechaAdquisicion { get; set; }
        public string? NombreEnte { get; set; }
        public string? DestinoLocalExtranjero { get; set; }
        public int? CodigoPais { get; set; }
        public string? CodigoRelacionBanco { get; set; }
        public int? CodigoCalificacionRiesgo { get; set; }
        public double? Tasa { get; set; }
        public bool? CodigoEstado { get; set; }
        public string? IdUsuario { get; set; }

        public virtual ParCalificacionriesgo Codigo { get; set; }
        public virtual ParEmpresa CodigoEmpresaNavigation { get; set; }
    }
}
