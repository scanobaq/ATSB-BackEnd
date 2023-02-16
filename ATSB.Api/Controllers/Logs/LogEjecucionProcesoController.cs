using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ATSB.Api.Areas.Entities.Logs;
using ATSB.Api.Areas.Identity.Data;
using System.Text.Json;
using Newtonsoft.Json;
using ATSB.Api.Areas.Repositories.Logs;
using ATSB.Models;
using ATSB.Api.Models.Logs;
using System.Text.Json.Serialization.Metadata;
using ATSB.Api.Areas.Entities.Parametros;

namespace ATSB.Api.Controllers.Logs
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogEjecucionProcesoController : ControllerBase
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly ILogEjecucionProcesoRepository _LogEjecucionProcesoRepository;

        public LogEjecucionProcesoController(ATSBIdentityDbContext context, ILogEjecucionProcesoRepository LogEjecucionProcesoRepository)
        {
            _context = context;
            _LogEjecucionProcesoRepository = LogEjecucionProcesoRepository;
        }

        // GET: api/LogEjecucionProceso
        [HttpGet("GetLogEjecucionProcesos")]
        public async Task<string> GetLogEjecucionprocesos()
        {
            var dataLogEjecucionProcesos = _LogEjecucionProcesoRepository.GetLogEjecucionProcesos();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strLogEjecucionProcesos = JsonConvert.SerializeObject(dataLogEjecucionProcesos, options);

            return await Task.Run(() =>
            {
                return strLogEjecucionProcesos;
            });
        }

        // GET: api/LogEjecucionProceso/5
        [HttpGet("GetLogEjecucionProceso/{CodigoEmpresa}/{CodigoProceso}/{SecuenciaProceso}/{FechaInforme}")]
        public async Task<string> GetLogEjecucionproceso(int CodigoEmpresa, int CodigoProceso, int SecuenciaProceso, DateTime FechaInforme)
        {
            var dataLogEjecucionProceso = await _LogEjecucionProcesoRepository.GetLogEjecucionProcesoAsync(CodigoEmpresa, CodigoProceso, SecuenciaProceso, FechaInforme);

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strLogEjecucionProceso = JsonConvert.SerializeObject(dataLogEjecucionProceso, options);

            return await Task.Run(() =>
            {
                return strLogEjecucionProceso;
            });
        }

        // POST: api/LogEjecucionProceso
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PostLogEjecucionProceso")]
        public async Task<string> PostLogEjecucionproceso(LogEjecucionProcesoRequest logEjecucionproceso)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _LogEjecucionProcesoRepository.AddLogEjecucionProcesoAsync(logEjecucionproceso);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        private bool LogEjecucionprocesoExists(int id)
        {
            return _context.LogEjecucionprocesos.Any(e => e.CodigoEmpresa == id);
        }
    }
}
