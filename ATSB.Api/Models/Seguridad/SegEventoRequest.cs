using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Seguridad
{
    public class SegEventoRequest
    {
        public int CodigoEmpresa { get; set; }
        public int IdEvento { get; set; }
        public string? Descripción { get; set; }
    }
}
