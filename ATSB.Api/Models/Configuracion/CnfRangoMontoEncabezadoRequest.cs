using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ATSB.Api.Models.Configuracion
{
    public class CnfRangoMontoEncabezadoRequest
    {
        public int CodigoEmpresa { get; set; }
        public int CodigoTabla { get; set; }
        public string NombreTabla { get; set; }
        public string DescripcionProceso { get; set; }
        public string IdUsuario { get; set; }
    }
}
