using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATSB.Api.Areas.Entities.Credito;
using ATSB.Api.Models.Credito;
using ATSB.Models;

namespace ATSB.Api.Areas.Repositories.Credito
{
    public interface ICreMaestroRepository
    {
        IQueryable GetCreMaestros();
        Task<CreMaestro> GetCreMaestroAsync(int CodigoEmpresa, string NumeroOperacion);
        Task<Response<object>> AddCreMaestroAsync(CreMaestroRequest creMaestro);

        Task<Response<object>> EditCreMaestroAsync(CreMaestroRequest creMaestro);
        Task<Response<object>> DeleteCreMaestroAsync(CreMaestroRequest creMaestro);
    }
}
