using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATSB.Api.Areas.Entities.Parametros;
using ATSB.Api.Models.Parametros;
using ATSB.Models;

namespace ATSB.Api.Areas.Repositories.Parametros
{
    public interface IParTipoIdentificacionRepository
    {
        IQueryable GetParTipoIdentificaciones();
        Task<ParTipoidentificacion> GetParTipoIdentificacionAsync(int CodigoPais, int CodigoTipoIdentificacion);
        Task<Response<object>> AddParTipoIdentificacionAsync(ParTipoIdentificacionRequest parTipoIdentificacion);

        Task<Response<object>> EditParTipoIdentificacionAsync(ParTipoIdentificacionRequest parTipoIdentificacion);
        Task<Response<object>> DeleteParTipoIdentificacionAsync(ParTipoIdentificacionRequest parTipoIdentificacion);
    }
}
