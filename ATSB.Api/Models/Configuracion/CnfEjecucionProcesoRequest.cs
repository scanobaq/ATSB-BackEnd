using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Configuracion
{
    public class CnfEjecucionProcesoRequest
    {
        public int CodigoEmpresa { get; set; }
        public int CodigoProceso { get; set; }
        public int SecuenciaProceso { get; set; }
        public string? Descripcion { get; set; }
        public int? CodigoOrigenDatos { get; set; }
        public string? TablaDestino { get; set; }
        public string? DescripcionOrigenDatos { get; set; }
        public string? BorrarAntes { get; set; }
        public string? EjecutaProcedimiento { get; set; }
        public string? Condicion { get; set; }
        public string? TieneEnbabezado { get; set; }
        public int? CantidadLineasEncabezado { get; set; }
        public string? ProcesoRequerido { get; set; }
        public int? CodigoEstado { get; set; }
        public string? IndicadorPaquete { get; set; }
    }
}
