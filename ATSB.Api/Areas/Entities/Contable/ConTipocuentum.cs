using System;
using System.Collections.Generic;
using ATSB.Api.Areas.Entities.Parametros;

namespace ATSB.Api.Areas.Entities.Contable
{
    public partial class ConTipocuentum
    {
        public ConTipocuentum()
        {
            ConCatalogoequivalencia = new HashSet<ConCatalogoequivalencium>();
        }

        public int CodigoEmpresa { get; set; }
        public int CodigoTipo { get; set; }
        public string? Descripcion { get; set; }
        public string? IdUsuario { get; set; }

        public virtual ParEmpresa CodigoEmpresaNavigation { get; set; }
        public virtual ICollection<ConCatalogoequivalencium> ConCatalogoequivalencia { get; set; }
    }
}
