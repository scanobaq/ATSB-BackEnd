using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATSB.Api.Areas.Entities.Seguridad;
using ATSB.Api.Models.Seguridad;
using ATSB.Models;

namespace ATSB.Api.Areas.Repositories.Seguridad
{
    public interface ISegHistoricoPasswordRepository
    {
        IQueryable GetSegHistoricosPassword();
        Task<SegHistoricopassword> GetSegHistoricoPasswordAsync(int CodigoEmpresa, string idUsuario, DateTime FechaHoraCambio);
        Task<Response<object>> AddSegHistoricoPasswordAsync(SegHistoricoPasswordRequest segHistoricoPassword);
    }
}
