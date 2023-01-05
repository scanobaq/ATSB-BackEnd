using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Configuracion
{
    public class CnfTablaGenericaRequest
    {
        public int CodigoEmpresa { get; set; }
        public int IdTabla { get; set; }
        public string TablaParametros { get; set; }
        public string Descripcion { get; set; }
        public int? CantidadColumnas { get; set; }
        public string IdUsuario { get; set; }
    }
}
