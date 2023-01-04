using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Configuracion
{
    public class CnfArchivoCampoGetRequest
    {
        public int CodigoEmpresa { get; set; }
        public int IdArchivo { get; set; }
        public int IdCampo { get; set; }
    }
}
