using System;
using System.Collections.Generic;
using ATSB.Api.Areas.Entities.Parametros;

namespace ATSB.Api.Areas.Entities.Temporales
{
    public partial class TmpCargaTxtBalancecontable
    {
        public int CodigoEmpresa { get; set; }
        public string Fecha { get; set; }
        public string Cuenta { get; set; }
        public string Detalle { get; set; }
        public double SaldoInicial { get; set; }
        public double Debitos { get; set; }
        public double Creditos { get; set; }
        public double Movimiento { get; set; }
        public double SaldoFinal { get; set; }
        public string IdUsuario { get; set; }
        public int? CodigoProceso { get; set; }
        public bool? Actualizado { get; set; }

        public virtual ParProceso Codigo { get; set; }
        public virtual ParEmpresa CodigoEmpresaNavigation { get; set; }
    }
}
