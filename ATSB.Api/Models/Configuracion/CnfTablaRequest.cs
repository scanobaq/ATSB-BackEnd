using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Configuracion
{
    public class CnfTablaRequest
    {
        public int CodigoEmpresa { get; set; }
        public int CodigoTabla { get; set; }
        public string Tabla { get; set; }
        public string Descripcion { get; set; }
    }
}
