using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Contable
{
    public class ConTipoCuentaRequest
    {
        public int CodigoEmpresa { get; set; }
        public int CodigoTipo { get; set; }
        public string? Descripcion { get; set; }
        public string? IdUsuario { get; set; }
    }
}
