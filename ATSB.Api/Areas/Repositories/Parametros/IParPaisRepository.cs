using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATSB.Api.Areas.Entities.Parametros;
using ATSB.Api.Models.Parametros;
using ATSB.Models;

namespace ATSB.Api.Areas.Repositories.Parametros
{
    public interface IParPaisRepository
    {
        IQueryable GetParPaises();
        Task<ParPai> GetParPaisAsync(int CodigoPais);
        Task<Response<object>> AddParPaisAsync(ParPaisRequest parPais);

        Task<Response<object>> EditParPaisAsync(ParPaisRequest parPais);
        Task<Response<object>> DeleteParPaisAsync(ParPaisRequest parPais);
    }
}
