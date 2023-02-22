using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATSB.Api.Areas.Entities.Configuracion;
using ATSB.Api.Areas.Entities.Contable;
using ATSB.Api.Models.Configuracion;
using ATSB.Api.Models.Contable;
using ATSB.Models;

namespace ATSB.Api.Areas.Repositories.Contable
{
    public interface IConCuentaLiquidezRepository
    {
        IQueryable GetConCuentasLiquidez();
        Task<ConCuentaliquidez> GetConCuentaLiquidezAsync(int CodigoEmpresa, int CuentaLiquidez, int CuentaContableLocal);
        Task<Response<object>> AddConCuentaLiquidezAsync(ConCuentaLiquidezRequest conCuentaLiquidez);

        Task<Response<object>> EditConCuentaLiquidezAsync(ConCuentaLiquidezRequest conCuentaLiquidez);
        Task<Response<object>> DeleteConCuentaLiquidezAsync(ConCuentaLiquidezRequest conCuentaLiquidez);
    }
}
