using System;
using System.Collections.Generic;

namespace ATSB.Api.Areas.Entities.Parametros
{
    public partial class ParMonedum
    {
        public ParMonedum()
        {
            ParTipocambios = new HashSet<ParTipocambio>();
        }

        public int CodigoEmpresa { get; set; }
        public int CodigoMoneda { get; set; }
        public string Descripcion { get; set; }
        public string DescripcionCorta { get; set; }
        public string IdUsuario { get; set; }

        public virtual ParEmpresa CodigoEmpresaNavigation { get; set; }
        public virtual ICollection<ParTipocambio> ParTipocambios { get; set; }
    }
}
