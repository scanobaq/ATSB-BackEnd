using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATSB.Api.Areas.Entities.Logs;
using ATSB.Api.Models.Logs;
using ATSB.Models;

namespace ATSB.Api.Areas.Repositories.Logs
{
    public interface ILogEjecucionProcesoRepository
    {
        IQueryable GetLogEjecucionProcesos();
        Task<LogEjecucionproceso> GetLogEjecucionProcesoAsync(int CodigoEmpresa, int CodigoProceso, int SecuenciaProceso, DateTime FechaInforme);
        Task<Response<object>> AddLogEjecucionProcesoAsync(LogEjecucionProcesoRequest logEjecucionProceso);
    }
}
