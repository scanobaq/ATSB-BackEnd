using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Temporales
{
    public class TmpCargaTxtDepositoPlazoPIgnoradoRequest
    {
        public int CodigoEmpresa { get; set; }
        public string TipoDeposito { get; set; }
        public string NumeroCuenta { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string CodigoCliente { get; set; }
        public string NombreCliente { get; set; }
        public double Balance { get; set; }
        public double MontoPignorado { get; set; }
        public string CodigoTipoGarantia { get; set; }
        public string IdUsuario { get; set; }
        public int? CodigoProceso { get; set; }
    }
}
