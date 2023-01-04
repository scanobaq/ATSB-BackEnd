using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATSB.Api.Areas.Entities.Configuracion;
using ATSB.Api.Models.Configuracion;
using ATSB.Models;

namespace ATSB.Api.Areas.Repositories.Configuracion
{
    public interface ICnfEjecucionReportesRepository
    {
        IQueryable GetCnfEjecucionReportes();
        Task<CnfEjecucionreporte> GetCnfEjecucionReporteAsync(int CodigoEmpresa, int Id);
        Task<Response<object>> AddCnfEjecucionReportesAsync(CnfEjecucionReportesRequest cnfEjecucionReportes);

        Task<Response<object>> EditCnfEjecucionReportesAsync(CnfEjecucionReportesRequest cnfEjecucionReportes);
        Task<Response<object>> DeleteCnfEjecucionReportesAsync(CnfEjecucionReportesRequest cnfEjecucionReportes);
    }
}
