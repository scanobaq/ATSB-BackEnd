using System;
using System.Collections.Generic;
using ATSB.Api.Areas.Entities.Parametros;

namespace ATSB.Api.Areas.Entities.Configuracion
{
    public partial class CnfRangomontoencabezado
    {
        public CnfRangomontoencabezado()
        {
            CnfRangomontodetalles = new HashSet<CnfRangomontodetalle>();
        }

        public int CodigoEmpresa { get; set; }
        public int CodigoTabla { get; set; }
        public string NombreTabla { get; set; }
        public string DescripcionProceso { get; set; }
        public string IdUsuario { get; set; }

        public virtual ParEmpresa CodigoEmpresaNavigation { get; set; }
        public virtual ICollection<CnfRangomontodetalle> CnfRangomontodetalles { get; set; }
    }
}
