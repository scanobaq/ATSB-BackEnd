using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATSB.Api.Models.Logs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ATSB.Api.Areas.Identity.Data;
using ATSB.Models;
using ATSB.Api.Areas.Entities.Logs;

using ATSB.Api.Helpers;
using ATSB.Api.Areas.Entities.Parametros;

namespace ATSB.Api.Areas.Repositories.Logs
{
    public class LogEjecucionProcesoRepository : ILogEjecucionProcesoRepository
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IConsecutivoHelper _ConsecutivoHelper;

        public LogEjecucionProcesoRepository
        (
            ATSBIdentityDbContext context,
            IConsecutivoHelper ConsecutivoHelper
        ) : base()

        {
            _context = context;
            _ConsecutivoHelper = ConsecutivoHelper;
        }

        public IQueryable GetLogEjecucionProcesos()
        {
            return _context.LogEjecucionprocesos
                .AsNoTracking()
                .Include(ep => ep.CnfEjecucionproceso); //EjecucionProceso
        }

        public async Task<LogEjecucionproceso> GetLogEjecucionProcesoAsync(int CodigoEmpresa, int CodigoProceso, int SecuenciaProceso, DateTime FechaInforme)
        {
            return await _context.LogEjecucionprocesos.Where(x => x.CodigoEmpresa == CodigoEmpresa && x.CodigoProceso == CodigoProceso && x.SecuenciaProceso == SecuenciaProceso && FechaInforme == FechaInforme)
                .AsNoTracking()
                .Include(ep => ep.CnfEjecucionproceso) //EjecucionProceso
                .FirstOrDefaultAsync();
        }

        public async Task<Response<object>> AddLogEjecucionProcesoAsync(LogEjecucionProcesoRequest logEjecucionProceso)
        {
            try
            {
                var logejecucionproceso = new LogEjecucionproceso
                {
                    CodigoEmpresa = logEjecucionProceso.CodigoEmpresa,
                    CodigoProceso = logEjecucionProceso.CodigoProceso,
                    SecuenciaProceso = logEjecucionProceso.SecuenciaProceso,
                    IdUsuario = logEjecucionProceso.IdUsuario,
                    FechaInforme = logEjecucionProceso.FechaInforme,
                    FechaEjecucion = logEjecucionProceso.FechaEjecucion,
                    CantidadRegistros = logEjecucionProceso.CantidadRegistros,
                    IndicadorEjecucionOk = logEjecucionProceso.IndicadorEjecucionOk == "true" ? true : false,
                    CodigoErrorDb = logEjecucionProceso.CodigoErrorDb,
                    MensajeOriginal = logEjecucionProceso.MensajeOriginal,
                    MensajeTarea = logEjecucionProceso.MensajeTarea
                };

                _context.LogEjecucionprocesos.Add(logejecucionproceso);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "El log de ejecucion procesos se creo con exito",
                    Result = logejecucionproceso
                });
            }
            catch (System.Exception ex)
            {
                throw new Exception("El log ejecucion procesos no fue creado");
            }
        }


    }
}
