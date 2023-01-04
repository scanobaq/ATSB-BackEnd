using System;
using System.Collections.Generic;
using ATSB.Api.Areas.Entities.Parametros;

namespace ATSB.Api.Areas.Entities.Configuracion
{
    public partial class CnfTablagenericavalore
    {
        public int CodigoEmpresa { get; set; }
        public int IdTabla { get; set; }
        public int IdValor { get; set; }
        public string? CodigoValor { get; set; }
        public string? Descripcion1 { get; set; }
        public string? Descripcion2 { get; set; }
        public string? Descripcion3 { get; set; }
        public string? Descripcion4 { get; set; }
        public string? Descripcion5 { get; set; }
        public int? CodigoEstado { get; set; }
        public string? IdUsuario { get; set; }

        public virtual CnfTablagenerica CnfTablagenerica { get; set; }
        public virtual ParEstado CodigoEstadoNavigation { get; set; }
    }
}
