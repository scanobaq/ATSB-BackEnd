using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATSB.Api.Areas.Entities.Liquidez;
using ATSB.Api.Models.Liquidez;
using ATSB.Models;

namespace ATSB.Api.Areas.Repositories.Liquidez
{
    public interface ILiqIndiceRepository
    {
        IQueryable GetLiqIndices();
        Task<LiqIndie> GetLiqIndiceAsync(int CodigoEmpresa, string Tipo, int Rubro);
        Task<Response<object>> AddLiqIndiceAsync(LiqIndiceRequest liqIndice);

        Task<Response<object>> EditLiqIndiceAsync(LiqIndiceRequest liqIndice);
        Task<Response<object>> DeleteLiqIndiceAsync(LiqIndiceRequest liqIndice);
    }
}
