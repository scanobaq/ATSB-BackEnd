using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATSB.Api.Areas.Entities.Liquidez;
using ATSB.Api.Models.Liquidez;
using ATSB.Models;

namespace ATSB.Api.Areas.Repositories.Liquidez
{
    public interface ILiqInstrumentoRubroRepository
    {
        IQueryable GetLiqInstrumentosRubros();
        Task<LiqInstrumentorubro> GetLiqInstrumentoRubroAsync(int CodigoEmpresa, string Instrumento, string CodigoRegion, int CodigoRubro);
        Task<Response<object>> AddLiqInstrumentoRubroAsync(LiqInstrumentoRubroRequest liqInstrumentoRubro);

        Task<Response<object>> EditLiqInstrumentoRubroAsync(LiqInstrumentoRubroRequest liqInstrumentoRubro);
        Task<Response<object>> DeleteLiqInstrumentoRubroAsync(LiqInstrumentoRubroRequest liqInstrumentoRubro);
    }
}
