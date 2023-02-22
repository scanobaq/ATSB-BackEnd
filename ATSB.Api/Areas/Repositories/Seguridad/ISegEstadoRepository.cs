using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATSB.Api.Areas.Entities.Seguridad;
using ATSB.Api.Models.Seguridad;
using ATSB.Models;

namespace ATSB.Api.Areas.Repositories.Seguridad
{
    public interface ISegEstadoRepository
    {
        IQueryable GetSegEstados();
        Task<SegEstado> GetSegEstadoAsync(int CodigoEmpresa, string CodigoEstado);
        Task<Response<object>> AddSegEstadoAsync(SegEstadoRequest segEstado);

        Task<Response<object>> EditSegEstadoAsync(SegEstadoRequest segEstado);
        Task<Response<object>> DeleteSegEstadoAsync(SegEstadoRequest segEstado);
    }
}
