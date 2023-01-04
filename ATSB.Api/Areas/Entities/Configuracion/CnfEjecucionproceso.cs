using System;
using System.Collections.Generic;
using ATSB.Api.Areas.Entities.Parametros;

namespace ATSB.Api.Areas.Entities.Configuracion
{
    public partial class CnfEjecucionproceso
    {
        public int CodigoEmpresa { get; set; }
        public int CodigoProceso { get; set; }
        public int SecuenciaProceso { get; set; }
        public string? Descripcion { get; set; }
        public int? CodigoOrigenDatos { get; set; }
        public string? TablaDestino { get; set; }
        public string? DescripcionOrigenDatos { get; set; }
        public bool? BorrarAntes { get; set; }
        public string? EjecutaProcedimiento { get; set; }
        public string? Condicion { get; set; }
        public bool? TieneEnbabezado { get; set; }
        public int? CantidadLineasEncabezado { get; set; }
        public bool? ProcesoRequerido { get; set; }
        public int? CodigoEstado { get; set; }
        public bool? IndicadorPaquete { get; set; }

        public virtual ParTipoorigendato Codigo { get; set; }
        public virtual ParEmpresa CodigoEmpresaNavigation { get; set; }
        public virtual ParEstado CodigoEstadoNavigation { get; set; }
        public virtual ParProceso CodigoNavigation { get; set; }
    }
}
