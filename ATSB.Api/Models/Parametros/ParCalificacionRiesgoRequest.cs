using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Parametros
{
    public class ParCalificacionRiesgoRequest
    {
        public int CodigoEmpresa { get; set; }
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Moody { get; set; }
        public string Fitch { get; set; }
        public string Comp { get; set; }
        public string Sp { get; set; }
        public string IdUsuario { get; set; }
    }
}
