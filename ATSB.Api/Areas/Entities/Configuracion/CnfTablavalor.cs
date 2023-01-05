using System;
using System.Collections.Generic;
using ATSB.Api.Areas.Entities.Parametros;

namespace ATSB.Api.Areas.Entities.Configuracion
{
    public partial class CnfTablavalor
    {
        public int CodigoEmpresa { get; set; }
        public int CodigoTabla { get; set; }
        public int IdValor { get; set; }
        public string Codigo { get; set; }
        public string Valor { get; set; }
        public int CodigoEstado { get; set; }

        public virtual ParEstado CodigoEstadoNavigation { get; set; }
        public virtual CnfTabla CodigoNavigation { get; set; }
    }
}
