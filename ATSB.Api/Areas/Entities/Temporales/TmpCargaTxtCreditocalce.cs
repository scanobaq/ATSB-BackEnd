using System;
using System.Collections.Generic;
using ATSB.Api.Areas.Entities.Parametros;

namespace ATSB.Api.Areas.Entities.Temporales
{
    public partial class TmpCargaTxtCreditocalce
    {
        public int CodigoEmpresa { get; set; }
        public string? CodigoTipo { get; set; }
        public string? NumeroCredito { get; set; }
        public double Rango1 { get; set; }
        public double Rango2 { get; set; }
        public double Rango3 { get; set; }
        public double Rango4 { get; set; }
        public double Rango5 { get; set; }
        public double Rango6 { get; set; }
        public double Rango7 { get; set; }
        public double Rango8 { get; set; }
        public double Rango9 { get; set; }
        public double Rango10 { get; set; }
        public double Rango11 { get; set; }
        public string? IdUsuario { get; set; }
        public int? CodigoProceso { get; set; }

        public virtual ParProceso Codigo { get; set; }
        public virtual ParEmpresa CodigoEmpresaNavigation { get; set; }
    }
}
