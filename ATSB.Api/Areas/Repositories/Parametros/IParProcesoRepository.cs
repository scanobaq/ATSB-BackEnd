using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATSB.Api.Areas.Entities.Parametros;
using ATSB.Api.Models.Parametros;
using ATSB.Models;

namespace ATSB.Api.Areas.Repositories.Parametros
{
    public interface IParProcesoRepository
    {
        IQueryable GetParProcesos();
        Task<ParProceso> GetParProcesoAsync(int CodigoEmpresa, int CodigoProceso);
        Task<Response<object>> AddParProcesoAsync(ParProcesoRequest parProceso);

        Task<Response<object>> EditParProcesoAsync(ParProcesoRequest parProceso);
        Task<Response<object>> DeleteParProcesoAsync(ParProcesoRequest parProceso);
    }
}
