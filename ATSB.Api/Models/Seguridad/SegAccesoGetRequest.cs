using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Seguridad
{
    public class SegAccesoGetRequest
    {
        public int CodigoEmpresa { get; set; }
        public int CodigoTipoAcceso { get; set; }
    }
}
