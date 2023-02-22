using System;
using System.Collections.Generic;
using ATSB.Api.Areas.Entities.Parametros;

namespace ATSB.Api.Areas.Entities.Temporales
{
    public partial class TmpCargaTxtCredito
    {
        public int CodigoEmpresa { get; set; }
        public string NumeroOperacion { get; set; }
        public string CodigoCliente { get; set; }
        public string NombreCliente { get; set; }
        public double Saldo { get; set; }
        public double Tasa { get; set; }
        public DateTime FechaApertura { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string ClasePrestamo { get; set; }
        public string TipoCredito { get; set; }
        public double MontoApertura { get; set; }
        public DateTime FechaArchivo { get; set; }
        public string IdUsuario { get; set; }
        public int? CodigoProceso { get; set; }

        public virtual ParProceso Codigo { get; set; }
        public virtual ParEmpresa CodigoEmpresaNavigation { get; set; }
    }
}
