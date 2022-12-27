using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATSB.Api.Areas.Entities.Parametros;
using ATSB.Api.Models.Parametros;
using ATSB.Models;

namespace ATSB.Api.Areas.Repositories.Parametros
{
    public interface IParEstadoRepository
    {
        IQueryable GetParEstados();
        Task<ParEstado> GetParEstadoAsync(int CodigoEstado);
        Task<Response<object>> AddParEstadoAsync(ParEstadoRequest parEstado);

        Task<Response<object>> EditParEstadoAsync(ParEstadoRequest parEstado);
        Task<Response<object>> DeleteParEstadoAsync(ParEstadoRequest parEstado);
    }
}
