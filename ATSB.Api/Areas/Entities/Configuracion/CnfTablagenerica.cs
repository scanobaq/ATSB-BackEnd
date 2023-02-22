using System;
using System.Collections.Generic;
using ATSB.Api.Areas.Entities.Parametros;

namespace ATSB.Api.Areas.Entities.Configuracion
{
    public partial class CnfTablagenerica
    {
        public CnfTablagenerica()
        {
            CnfTablagenericacampos = new HashSet<CnfTablagenericacampo>();
            CnfTablagenericavalores = new HashSet<CnfTablagenericavalore>();
        }

        public int CodigoEmpresa { get; set; }
        public int IdTabla { get; set; }
        public string TablaParametros { get; set; }
        public string Descripcion { get; set; }
        public int? CantidadColumnas { get; set; }
        public string IdUsuario { get; set; }

        public virtual ParEmpresa CodigoEmpresaNavigation { get; set; }
        public virtual ICollection<CnfTablagenericacampo> CnfTablagenericacampos { get; set; }
        public virtual ICollection<CnfTablagenericavalore> CnfTablagenericavalores { get; set; }
    }
}
