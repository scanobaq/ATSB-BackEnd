using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATSB.Api.Areas.Entities.Parametros;
using ATSB.Api.Models.Parametros;
using ATSB.Models;

namespace ATSB.Api.Areas.Repositories.Parametros
{
    public interface IParCalificacionRiesgoPaisRepository
    {
        IQueryable GetParCalificacionRiesgoPaises();
        Task<ParCalificacionriesgopai> GetParCalificacionRiesgoPaisAsync(int CodigoEmpresa, int CodigoPais);
        Task<Response<object>> AddParCalificacionRiesgoPaisAsync(ParCalificacionRiesgoPaisRequest parCalificacionRiesgoPais);

        Task<Response<object>> EditParCalificacionRiesgoPaisAsync(ParCalificacionRiesgoPaisRequest parCalificacionRiesgoPais);
        Task<Response<object>> DeleteParCalificacionRiesgoPaisAsync(ParCalificacionRiesgoPaisRequest parCalificacionRiesgoPais);
    }
}
