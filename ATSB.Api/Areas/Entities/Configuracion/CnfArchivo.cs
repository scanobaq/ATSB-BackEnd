using System;
using System.Collections.Generic;
using ATSB.Api.Areas.Entities.Parametros;

namespace ATSB.Api.Areas.Entities.Configuracion
{
    public partial class CnfArchivo
    {
        public CnfArchivo()
        {
            CnfArchivocampos = new HashSet<CnfArchivocampo>();
        }

        public int CodigoEmpresa { get; set; }
        public int IdArchivo { get; set; }
        public string NombreArchivo { get; set; }
        public string DescripcionArchivo { get; set; }
        public string TablaDestino { get; set; }
        public string IdUsuario { get; set; }

        public virtual ParEmpresa CodigoEmpresaNavigation { get; set; }
        public virtual ICollection<CnfArchivocampo> CnfArchivocampos { get; set; }
    }
}
