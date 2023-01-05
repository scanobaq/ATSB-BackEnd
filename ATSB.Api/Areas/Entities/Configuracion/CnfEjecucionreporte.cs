using System;
using System.Collections.Generic;
using ATSB.Api.Areas.Entities.Parametros;

namespace ATSB.Api.Areas.Entities.Configuracion
{
    public partial class CnfEjecucionreporte
    {
        public int CodigoEmpresa { get; set; }
        public int Id { get; set; }
        public int? IdGrupo { get; set; }
        public int? Proceso { get; set; }
        public string Nombre { get; set; }
        public string Titulo { get; set; }
        public string NombreHoja { get; set; }
        public string? Campos { get; set; }
        public string? Tabla { get; set; }
        public string? Condicion { get; set; }
        public bool? IndicadorFechaProceso { get; set; }
        public bool? IndicadorIncluirTitulo { get; set; }
        public bool? IndicadorIncluirEncabezados { get; set; }
        public bool? IndicadorFormato { get; set; }
        public bool? IndicadorAjustar { get; set; }
        public bool? IndicadorIncluirFecha { get; set; }
        public int? CodigoEstado { get; set; }
        public string IdUsuario { get; set; }
        public int? CodigoOrigenDatosSalida { get; set; }

        public virtual ParTipoorigendato Codigo { get; set; }
        public virtual ParEmpresa CodigoEmpresaNavigation { get; set; }
        public virtual ParEstado CodigoEstadoNavigation { get; set; }
    }
}
