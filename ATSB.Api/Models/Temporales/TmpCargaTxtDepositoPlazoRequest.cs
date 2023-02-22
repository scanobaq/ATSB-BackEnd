using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Temporales
{
    public class TmpCargaTxtDepositoPlazoRequest
    {
        public int CodigoEmpresa { get; set; }
        public string Cuenta { get; set; }
        public string CodigoCliente { get; set; }
        public string NombreCliente { get; set; }
        public double Balance { get; set; }
        public double Plazo { get; set; }
        public double Tasa { get; set; }
        public double InteresAcumulado { get; set; }
        public DateTime FechaApertura { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string CodigoSectorEconomico { get; set; }
        public short CodigoClaseCliente { get; set; }
        public string CodigoEstado { get; set; }
        public double InteresAcumuladoPeriodo { get; set; }
        public double PagoAnticipado { get; set; }
        public string FormaPago { get; set; }
        public DateTime FechaArchivo { get; set; }
        public string IdUsuario { get; set; }
        public int? CodigoProceso { get; set; }
    }
}
