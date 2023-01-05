using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Configuracion
{
    public class CnfEjecucionReportesRequest
    {
        public int CodigoEmpresa { get; set; }
        public int Id { get; set; }
        public int IdGrupo { get; set; }
        public int Proceso { get; set; }
        public string? Nombre { get; set; }
        public string? Titulo { get; set; }
        public string? NombreHoja { get; set; }
        public string? Campos { get; set; }
        public string? Tabla { get; set; }
        public string? Condicion { get; set; }
        public string? IndicadorFechaProceso { get; set; }
        public string? IndicadorIncluirTitulo { get; set; }
        public string? IndicadorIncluirEncabezados { get; set; }
        public string? IndicadorFormato { get; set; }
        public string? IndicadorAjustar { get; set; }
        public string? IndicadorIncluirFecha { get; set; }
        public int CodigoEstado { get; set; }
        public string IdUsuario { get; set; }
        public int CodigoOrigenDatosSalida { get; set; }
    }
}
