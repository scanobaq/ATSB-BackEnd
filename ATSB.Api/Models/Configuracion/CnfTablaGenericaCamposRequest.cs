using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Configuracion
{
    public class CnfTablaGenericaCamposRequest
    {
        public int CodigoEmpresa { get; set; }
        public int IdTabla { get; set; }
        public string IdCampo { get; set; }
        public string NombreCampo { get; set; }
        public string Etiqueta { get; set; }
        public string IdUsuario { get; set; }
    }
}
