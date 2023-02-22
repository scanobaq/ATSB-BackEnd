using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATSB.Api.Areas.Entities.Liquidez;
using ATSB.Api.Models.Liquidez;
using ATSB.Models;

namespace ATSB.Api.Areas.Repositories.Liquidez
{
    public interface ILiqRubroProcesoRepository
    {
        IQueryable GetLiqRubroProcesos();
        Task<LiqRubroproceso> GetLiqRubroProcesoAsync(int CodigoEmpresa, int Rubro);
        Task<Response<object>> AddLiqRubroProcesoAsync(LiqRubroProcesoRequest liqRubroProceso);

        Task<Response<object>> EditLiqRubroProcesoAsync(LiqRubroProcesoRequest liqRubroProceso);
        Task<Response<object>> DeleteLiqRubroProcesoAsync(LiqRubroProcesoRequest liqRubroProceso);
    }
}
