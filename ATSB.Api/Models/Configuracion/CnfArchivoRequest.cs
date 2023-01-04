using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Configuracion
{
    public class CnfArchivoRequest
    {
        public int CodigoEmpresa { get; set; }
        public int IdArchivo { get; set; }
        public string NombreArchivo { get; set; }
        public string DescripcionArchivo { get; set; }
        public string TablaDestino { get; set; }
        public string IdUsuario { get; set; }
    }
}
