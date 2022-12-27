using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Parametros
{
    public class ParPaisRequest
    {
        public int CodigoPais { get; set; }
        public string Nombre { get; set; }
        public int? CodigoIsonumerico { get; set; }
        public string CodigoIsoalfa2 { get; set; }
        public string CodigoIsoalfa3 { get; set; }
        public string FormatoTelefonoFijo { get; set; }
        public string FormatoTelefonoCelular { get; set; }
    }
}
