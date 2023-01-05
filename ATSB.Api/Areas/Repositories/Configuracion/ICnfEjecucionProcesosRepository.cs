using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATSB.Api.Areas.Entities.Configuracion;
using ATSB.Api.Models.Configuracion;
using ATSB.Models;

namespace ATSB.Api.Areas.Repositories.Configuracion
{
    public interface ICnfEjecucionProcesosRepository
    {
        IQueryable GetCnfEjecucionProcesos();
        Task<CnfEjecucionproceso> GetCnfEjecucionProcesoAsync(int CodigoEmpresa, int CodigoProceso, int SecuenciaProceso);
        Task<Response<object>> AddCnfEjecucionProcesoAsync(CnfEjecucionProcesoRequest cnfEjecucionProceso);

        Task<Response<object>> EditCnfEjecucionProcesosAsync(CnfEjecucionProcesoRequest cnfEjecucionProceso);
        Task<Response<object>> DeleteCnfEjecucionProcesosAsync(CnfEjecucionProcesoRequest cnfEjecucionProceso);
    }
}
