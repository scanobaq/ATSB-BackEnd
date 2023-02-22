using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Configuracion
{
    public class CnfTablaValorRequest
    {
        public int CodigoEmpresa { get; set; }
        public int CodigoTabla { get; set; }
        public int IdValor { get; set; }
        public string Codigo { get; set; }
        public string Valor { get; set; }
        public int CodigoEstado { get; set; }
    }
}
