using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATSB.Api.Areas.Entities.Seguridad;
using ATSB.Api.Models.Seguridad;
using ATSB.Models;

namespace ATSB.Api.Areas.Repositories.Seguridad
{
    public interface ISegAccesoRepository
    {
        IQueryable GetSegAccesos();
        Task<SegAcceso> GetSegAccesoAsync(int CodigoEmpresa, int CodigoTipoAcceso);
        Task<Response<object>> AddSegAccesoAsync(SegAccesoRequest segAcceso);

        Task<Response<object>> EditSegAccesoAsync(SegAccesoRequest segAcceso);
        Task<Response<object>> DeleteSegAccesoAsync(SegAccesoRequest segAcceso);
    }
}
