using System;
using System.Collections.Generic;
using ATSB.Api.Areas.Entities.Parametros;

namespace ATSB.Api.Areas.Entities.Liquidez
{
    public partial class LiqInstrumentorubro
    {
        public int CodigoEmpresa { get; set; }
        public string? Instrumento { get; set; }
        public string? CodigoRegion { get; set; }
        public int CodigoRubro { get; set; }
        public bool? CodigoEstado { get; set; }
        public string? IdUsuario { get; set; }

        public virtual ParEmpresa CodigoEmpresaNavigation { get; set; }
    }
}
