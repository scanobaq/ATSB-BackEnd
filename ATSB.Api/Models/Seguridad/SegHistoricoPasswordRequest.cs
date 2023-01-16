using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Seguridad
{
    public class SegHistoricoPasswordRequest
    {
        public int CodigoEmpresa { get; set; }
        public string? IdUsuario { get; set; }
        public DateTime FechaHoraCambio { get; set; }
        public string? DescripcionPassword { get; set; }
    }
}
