using System;
using System.Collections.Generic;
using ATSB.Api.Areas.Entities.Parametros;

namespace ATSB.Api.Areas.Entities.Credito
{
    public partial class CreMaestro
    {
        public int CodigoEmpresa { get; set; }
        public string? NumeroOperacion { get; set; }
        public string? CodigoCliente { get; set; }
        public int? TipoCredito { get; set; }
        public string? NombreCliente { get; set; }
        public double? Tasa { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public double? Saldo { get; set; }
        public int? CodigoTipoGarantia { get; set; }
        public int? CodigoClaseCredito { get; set; }
        public int? CodigoFormaPago { get; set; }
        public double? Cuota { get; set; }
        public DateTime? FechaRevisionTasa { get; set; }
        public int? CodigoTipoTasa { get; set; }
        public double? MontoApertura { get; set; }
        public DateTime? FechaArchivo { get; set; }
        public int? CodigoFacilidadCrediticia { get; set; }
        public int? CodigoTipoRelacion { get; set; }
        public int? CodigoTipoActividad { get; set; }
        public string? IdUsuario { get; set; }

        public virtual ParEmpresa CodigoEmpresaNavigation { get; set; }
    }
}
