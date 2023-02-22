using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Configuracion
{
    public class CnfTablaGenericaCamposGetRequest
    {
        public int CodigoEmpresa { get; set; }
        public int IdTabla { get; set; }
        public string IdCampo { get; set; }
    }
}
