using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATSB.Api.Areas.Entities.Pasivo;
using ATSB.Api.Models.Credito;
using ATSB.Api.Models.Pasivo;
using ATSB.Models;

namespace ATSB.Api.Areas.Repositories.Pasivo
{
    public interface IPasDetalleHistoricoRepository
    {
        IQueryable GetPasDetallesHistoricos();
        Task<PasDetallehistorico> GetPasDetalleHistoricoAsync(int CodigoEmpresa, string NumeroOperacion, string Fecha);
        Task<Response<object>> AddPasDetalleHistoricoAsync(PasDetalleHistoricoRequest pasDetalleHistorico);

        Task<Response<object>> EditPasDetalleHistoricoAsync(PasDetalleHistoricoRequest pasDetalleHistorico);
        Task<Response<object>> DeletePasDetalleHistoricoAsync(PasDetalleHistoricoRequest pasDetalleHistorico);
    }
}
