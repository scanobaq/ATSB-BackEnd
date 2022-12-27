using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATSB.Api.Areas.Entities.Parametros;
using ATSB.Api.Models.Parametros;
using ATSB.Models;

namespace ATSB.Api.Areas.Repositories.Parametros
{
    public interface IParEmpresaRepository
    {
        IQueryable GetParEmpresas();
        Task<ParEmpresa> GetParEmpresaAsync(int CodigoEmpresa);
        Task<Response<object>> AddParEmpresaAsync(ParEmpresaRequest parEmpresa);

        Task<Response<object>> EditParEmpresaAsync(ParEmpresaRequest parEmpresa);
        Task<Response<object>> DeleteParEmpresaAsync(ParEmpresaRequest parEmpresa);
    }
}
