using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Pasivo
{
    public class PasDetalleHistoricoGetRequest
    {
        public int CodigoEmpresa { get; set; }
        public string? NumeroOperacion { get; set; }
        public string? Fecha { get; set; }
    }
}
