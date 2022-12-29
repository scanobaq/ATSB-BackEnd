using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATSB.Api.Areas.Entities.Parametros;
using ATSB.Api.Models.Parametros;
using ATSB.Models;

namespace ATSB.Api.Areas.Repositories.Parametros
{
    public interface IParMonedaRepository
    {
        IQueryable GetParMonedas();
        Task<ParMonedum> GetParMonedaAsync(int CodigoEmpresa, int CodigoMoneda);
        Task<Response<object>> AddParMonedaAsync(ParMonedaRequest parMoneda);

        Task<Response<object>> EditParMonedaAsync(ParMonedaRequest parMoneda);
        Task<Response<object>> DeleteParMonedaAsync(ParMonedaRequest parMoneda);
    }
}
