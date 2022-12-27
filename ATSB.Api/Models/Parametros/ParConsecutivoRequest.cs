using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Parametros
{
    public class ParConsecutivoRequest
    {
        public int CodigoEmpresa { get; set; }
        public string IdConsecutivo { get; set; }
        public int NumeroConsecutivo { get; set; }
    }
}
