using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATSB.Api.Areas.Entities.Pasivo;
using ATSB.Api.Models.Credito;
using ATSB.Api.Models.Pasivo;
using ATSB.Models;

namespace ATSB.Api.Areas.Repositories.Pasivo
{
    public interface IPasCuentaLiquidezRepository
    {
        IQueryable GetPasCuentasLiquidez();
        Task<PasCuentaliquidez> GetPasCuentaLiquidezAsync(int CodigoEmpresa, int TipoDeposito, int TipoCliente, int CodigoCuentaLiquidez, string DestinoLocalExtranjero);
        Task<Response<object>> AddPasCuentaLiquidezAsync(PasCuentaLiquidezRequest pasCuentaLiquidez);

        Task<Response<object>> EditPasCuentaLiquidezAsync(PasCuentaLiquidezRequest pasCuentaLiquidez);
        Task<Response<object>> DeletePasCuentaLiquidezAsync(PasCuentaLiquidezRequest pasCuentaLiquidez);
    }
}
