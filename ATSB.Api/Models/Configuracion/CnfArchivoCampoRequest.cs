using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Configuracion
{
    public class CnfArchivoCampoRequest
    {
        public int CodigoEmpresa { get; set; }
        public int IdArchivo { get; set; }
        public int IdCampo { get; set; }
        public string? IndicadorCampo { get; set; }
        public string NombreCampo { get; set; }
        public string NombrePatron { get; set; }
        public string Patron { get; set; }
        public string CondicionPatron { get; set; }
        public int? PosicionInicial { get; set; }
        public int? Largo { get; set; }
        public int? CodigoEstado { get; set; }
    }
}
