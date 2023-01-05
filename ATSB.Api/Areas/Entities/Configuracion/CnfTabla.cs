using System;
using System.Collections.Generic;
using ATSB.Api.Areas.Entities.Parametros;

namespace ATSB.Api.Areas.Entities.Configuracion
{
    public partial class CnfTabla
    {
        public CnfTabla()
        {
            CnfTablavalors = new HashSet<CnfTablavalor>();
        }

        public int CodigoEmpresa { get; set; }
        public int CodigoTabla { get; set; }
        public string Tabla { get; set; }
        public string Descripcion { get; set; }

        public virtual ParEmpresa CodigoEmpresaNavigation { get; set; }
        public virtual ICollection<CnfTablavalor> CnfTablavalors { get; set; }
    }
}
