using System;
using System.Collections.Generic;

namespace ATSB.Api.Areas.Entities.Configuracion
{
    public partial class CnfTablagenericacampo
    {
        public int CodigoEmpresa { get; set; }
        public int IdTabla { get; set; }
        public string IdCampo { get; set; }
        public string NombreCampo { get; set; }
        public string Etiqueta { get; set; }
        public string IdUsuario { get; set; }

        public virtual CnfTablagenerica CnfTablagenerica { get; set; }
    }
}
