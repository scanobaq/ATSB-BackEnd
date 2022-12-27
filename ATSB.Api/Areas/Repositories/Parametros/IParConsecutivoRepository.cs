using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATSB.Api.Areas.Entities.Parametros;
using ATSB.Api.Models.Parametros;
using ATSB.Models;

namespace ATSB.Api.Areas.Repositories.Parametros
{
    public interface IParConsecutivoRepository
    {
        IQueryable GetParConsecutivos();
        Task<ParConsecutivo> GetParConsecutivoAsync(int CodigoEmpresa, string IdConsecutivo);
        Task<Response<object>> AddParConsecutivoAsync(ParConsecutivoRequest parConsecutivo);

        Task<Response<object>> EditParConsecutivoAsync(ParConsecutivoRequest parConsecutivo);
        Task<Response<object>> DeleteParConsecutivoAsync(ParConsecutivoRequest parConsecutivo);
    }
}
