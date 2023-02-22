using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATSB.Api.Areas.Entities.Seguridad;
using ATSB.Api.Models.Seguridad;
using ATSB.Models;

namespace ATSB.Api.Areas.Repositories.Seguridad
{
    public interface ISegEventoRepository
    {
        IQueryable GetSegEventos();
        Task<SegEvento> GetSegEventoAsync(int CodigoEmpresa, int idEvento);
        Task<Response<object>> AddSegEventoAsync(SegEventoRequest segEvento);

        Task<Response<object>> EditSegEventoAsync(SegEventoRequest segEvento);
        Task<Response<object>> DeleteSegEventoAsync(SegEventoRequest segEvento);
    }
}
