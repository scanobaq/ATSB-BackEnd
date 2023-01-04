using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Configuracion
{
    public class CnfTablaGenericaValoresRequest
    {
        public int CodigoEmpresa { get; set; }
        public int IdTabla { get; set; }
        public int IdValor { get; set; }
        public string CodigoValor { get; set; }
        public string Descripcion1 { get; set; }
        public string Descripcion2 { get; set; }
        public string Descripcion3 { get; set; }
        public string Descripcion4 { get; set; }
        public string Descripcion5 { get; set; }
        public int? CodigoEstado { get; set; }
        public string IdUsuario { get; set; }
    }
}
