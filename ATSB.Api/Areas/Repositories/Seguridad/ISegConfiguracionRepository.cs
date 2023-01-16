using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATSB.Api.Areas.Entities.Seguridad;
using ATSB.Api.Models.Seguridad;
using ATSB.Models;

namespace ATSB.Api.Areas.Repositories.Seguridad
{
    public interface ISegConfiguracionRepository
    {
        IQueryable GetSegConfiguraciones();
        Task<SegConfiguracion> GetSegConfiguracionAsync(int CodigoEmpresa, int IdParametro);
        Task<Response<object>> AddSegConfiguracionAsync(SegConfiguracionRequest segConfiguracion);

    }
}
