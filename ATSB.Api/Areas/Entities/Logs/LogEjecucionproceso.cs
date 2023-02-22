using System;
using System.Collections.Generic;
using ATSB.Api.Areas.Entities.Configuracion;

namespace ATSB.Api.Areas.Entities.Logs
{
    public partial class LogEjecucionproceso
    {
        public int CodigoEmpresa { get; set; }
        public int CodigoProceso { get; set; }
        public int SecuenciaProceso { get; set; }
        public string? IdUsuario { get; set; }
        public DateTime FechaInforme { get; set; }
        public DateTime? FechaEjecucion { get; set; }
        public string? CantidadRegistros { get; set; }
        public bool? IndicadorEjecucionOk { get; set; }
        public int? CodigoErrorDb { get; set; }
        public string? MensajeOriginal { get; set; }
        public string? MensajeTarea { get; set; }

        public virtual CnfEjecucionproceso CnfEjecucionproceso { get; set; }
    }
}
