using System;
using System.Collections.Generic;
using ATSB.Api.Areas.Entities.Parametros;

namespace ATSB.Api.Areas.Entities.Configuracion
{
    public partial class CnfArchivocampo
    {
        public int CodigoEmpresa { get; set; }
        public int IdArchivo { get; set; }
        public int IdCampo { get; set; }
        public bool? IndicadorCampo { get; set; }
        public string NombreCampo { get; set; }
        public string NombrePatron { get; set; }
        public string? Patron { get; set; }
        public string? CondicionPatron { get; set; }
        public int? PosicionInicial { get; set; }
        public int? Largo { get; set; }
        public int? CodigoEstado { get; set; }

        public virtual CnfArchivo CnfArchivo { get; set; }
        public virtual ParEstado CodigoEstadoNavigation { get; set; }
    }
}
