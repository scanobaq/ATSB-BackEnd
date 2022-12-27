using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATSB.Api.Areas.Entities.Parametros;
using ATSB.Api.Models.Parametros;
using ATSB.Models;

namespace ATSB.Api.Areas.Repositories.Parametros
{
    public interface IParTipoCambioRepository
    {
        IQueryable GetParTiposCambio();
        Task<ParTipocambio> GetParTipoCambioAsync(int CodigoEmpresa, DateTime Fecha, int CodigoMoneda);
        Task<Response<object>> AddParTipoCambioAsync(ParTipoCambioRequest parTipoCambio);

        Task<Response<object>> EditParTipoCambioAsync(ParTipoCambioRequest parTipoCambio);
        Task<Response<object>> DeleteParTipoCambioAsync(ParTipoCambioRequest parTipoCambio);
    }
}
