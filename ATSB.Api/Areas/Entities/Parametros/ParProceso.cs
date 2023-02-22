using System;
using System.Collections.Generic;
using ATSB.Api.Areas.Entities.Configuracion;
using ATSB.Api.Areas.Entities.Temporales;

namespace ATSB.Api.Areas.Entities.Parametros
{
    public partial class ParProceso
    {
        public ParProceso()
        {
            CnfEjecucionprocesos = new HashSet<CnfEjecucionproceso>();
            TmpCargaTxtBalancecontables = new HashSet<TmpCargaTxtBalancecontable>();
            TmpCargaTxtCreditos = new HashSet<TmpCargaTxtCredito>();
            TmpCargaTxtDepositoplazos = new HashSet<TmpCargaTxtDepositoplazo>();
            TmpCargaTxtDepositoplazopignorados = new HashSet<TmpCargaTxtDepositoplazopignorado>();
            TmpCargaTxtCreditocalces = new HashSet<TmpCargaTxtCreditocalce>();
        }

        public int CodigoProceso { get; set; }
        public int CodigoEmpresa { get; set; }
        public string Descripcion { get; set; }
        public string NombreProceso { get; set; }
        public string TablaDestino { get; set; }

        public virtual ParEmpresa CodigoEmpresaNavigation { get; set; }
        public virtual ICollection<CnfEjecucionproceso> CnfEjecucionprocesos { get; set; }
        public virtual ICollection<TmpCargaTxtBalancecontable> TmpCargaTxtBalancecontables { get; set; }
        public virtual ICollection<TmpCargaTxtCredito> TmpCargaTxtCreditos { get; set; }
        public virtual ICollection<TmpCargaTxtDepositoplazo> TmpCargaTxtDepositoplazos { get; set; }
        public virtual ICollection<TmpCargaTxtDepositoplazopignorado> TmpCargaTxtDepositoplazopignorados { get; set; }
        public virtual ICollection<TmpCargaTxtCreditocalce> TmpCargaTxtCreditocalces { get; set; }
    }
}
