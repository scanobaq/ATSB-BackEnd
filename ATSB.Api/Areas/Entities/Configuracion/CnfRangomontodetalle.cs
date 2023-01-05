using System;
using System.Collections.Generic;
using ATSB.Api.Areas.Entities.Parametros;

namespace ATSB.Api.Areas.Entities.Configuracion
{
    public partial class CnfRangomontodetalle
    {
        public int CodigoEmpresa { get; set; }
        public int CodigoTabla { get; set; }
        public string? CodigoRango { get; set; }
        public string? Descripcion { get; set; }
        public double? RangoMinimo { get; set; }
        public double? RangoMaximo { get; set; }
        public string? RangoValor { get; set; }
        public int? CodigoEstado { get; set; }
        public string? IdUsuario { get; set; }

        public virtual CnfRangomontoencabezado Codigo { get; set; }
        public virtual ParEmpresa CodigoEmpresaNavigation { get; set; }
        public virtual ParEstado CodigoEstadoNavigation { get; set; }
    }
}
