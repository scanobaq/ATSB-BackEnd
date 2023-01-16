using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Seguridad
{
    public class SegEstadoRequest
    {
        public int CodigoEmpresa { get; set; }
        public string? CodigoEstado { get; set; }
        public string? Descripcion { get; set; }
    }
}
