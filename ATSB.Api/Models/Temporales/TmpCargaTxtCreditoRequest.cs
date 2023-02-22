using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Temporales
{
    public class TmpCargaTxtCreditoRequest
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
    }
}
