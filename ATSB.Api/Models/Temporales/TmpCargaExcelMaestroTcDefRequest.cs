using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
namespace ATSB.Api.Models.Temporales
{
    public class TmpCargaExcelMaestroTcDefRequest
    {
        public string NumeroTarjeta { get; set; }
        public string TipoIdentificacion { get; set; }
        public string CodigoCliente { get; set; }
        public string Identificacion { get; set; }
        public string NombreCliente { get; set; }
        public double CupoGlobal { get; set; }
        public double SaldoCapital { get; set; }
        public double SaldoTotal { get; set; }
        public double Intereses { get; set; }
        public double TasaIntereses { get; set; }
        public double InteresXfinanciamiento { get; set; }
        public double InteresesMora { get; set; }
        public double Cargo { get; set; }
        public double InteresExtracontable { get; set; }
        public double SaldoAFavor { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string EstadoTarjeta { get; set; }
        public string TipoTarjeta { get; set; }
        public string TcRelacionada { get; set; }
        public string TipoProducto { get; set; }
        public string Centalta { get; set; }
        public string Contrato { get; set; }
    }
}
