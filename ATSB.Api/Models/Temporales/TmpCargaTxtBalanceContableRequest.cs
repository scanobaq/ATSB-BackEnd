using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Temporales
{
    public class TmpCargaTxtBalanceContableRequest
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
        public string? Actualizado { get; set; }
    }
}
