using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Logs
{
    public class LogEjecucionProcesoRequest
    {
        public int CodigoEmpresa { get; set; }
        public int CodigoProceso { get; set; }
        public int SecuenciaProceso { get; set; }
        public string? IdUsuario { get; set; }
        public DateTime FechaInforme { get; set; }
        public DateTime? FechaEjecucion { get; set; }
        public string? CantidadRegistros { get; set; }
        public string? IndicadorEjecucionOk { get; set; }
        public int? CodigoErrorDb { get; set; }
        public string? MensajeOriginal { get; set; }
        public string? MensajeTarea { get; set; }
    }
}
