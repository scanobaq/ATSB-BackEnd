using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Pasivo
{
    public class PasMaestroGetRequest
    {
        public int CodigoEmpresa { get; set; }
        public string? NumeroCuenta { get; set; }
    }
}
