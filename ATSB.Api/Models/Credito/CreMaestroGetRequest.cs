using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Credito
{
    public class CreMaestroGetRequest
    {
        public int CodigoEmpresa { get; set; }
        public string? NumeroOperacion { get; set; }
    }
}
