using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATSB.Api.Areas.Entities.Parametros;
using ATSB.Api.Models.Parametros;
using ATSB.Models;

namespace ATSB.Api.Areas.Repositories.Parametros
{
    public interface IParCalificacionRiesgoRepository
    {
        IQueryable GetParCalificacionRiesgos();
        Task<ParCalificacionriesgo> GetParCalificacionRiesgoAsync(int CodigoEmpresa, int Id);
        Task<Response<object>> AddParCalificacionRiesgoAsync(ParCalificacionRiesgoRequest parCalificacionRiesgo);

        Task<Response<object>> EditParCalificacionRiesgoAsync(ParCalificacionRiesgoRequest parCalificacionRiesgo);
        Task<Response<object>> DeleteParCalificacionRiesgoAsync(ParCalificacionRiesgoRequest parCalificacionRiesgo);
    }
}
