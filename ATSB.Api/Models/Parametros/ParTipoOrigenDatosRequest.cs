using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSB.Api.Models.Parametros
{
    public class ParTipoOrigenDatosRequest
    {
        public int CodigoOrigenDatos { get; set; }
        public int CodigoEmpresa { get; set; }
        public string Descripcion { get; set; }
        public string DelimitadorDatos { get; set; }
    }
}
