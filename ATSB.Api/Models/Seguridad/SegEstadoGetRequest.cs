using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Seguridad
{
    public class SegEstadoGetRequest
    {
        public int CodigoEmpresa { get; set; }
        public string? CodigoEstado { get; set; }
    }
}
