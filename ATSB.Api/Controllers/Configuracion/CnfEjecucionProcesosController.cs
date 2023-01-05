using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ATSB.Api.Areas.Entities.Configuracion;
using ATSB.Api.Areas.Identity.Data;
using System.Text.Json;
using Newtonsoft.Json;
using ATSB.Api.Areas.Repositories.Configuracion;
using ATSB.Models;
using ATSB.Api.Models.Configuracion;
using Microsoft.EntityFrameworkCore.Metadata;
using NuGet.Packaging;

namespace ATSB.Api.Controllers.Configuracion
{
    [Route("api/[controller]")]
    [ApiController]
    public class CnfEjecucionProcesosController : ControllerBase
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly ICnfEjecucionProcesosRepository _CnfEjecucionProcesosRepository;

        public CnfEjecucionProcesosController(ATSBIdentityDbContext context, ICnfEjecucionProcesosRepository CnfEjecucionProcesosRepository)
        {
            _context = context;
            _CnfEjecucionProcesosRepository = CnfEjecucionProcesosRepository;
        }

        // GET: api/CnfEjecucionProcesos
        [HttpGet("GetCnfEjecucionProcesos")]
        public async Task<string> GetCnfEjecucionprocesos()
        {
            var dataCnfEjecucionProcesos = _CnfEjecucionProcesosRepository.GetCnfEjecucionProcesos();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strEjecucionProcesos = JsonConvert.SerializeObject(dataCnfEjecucionProcesos, options);

            return await Task.Run(() =>
            {
                return strEjecucionProcesos;
            });
        }

        // GET: api/CnfEjecucionProcesos/5
        [HttpGet("GetCnfEjecucionProceso/{CodigoEmpresa}/{CodigoProceso}/{SecuenciaProceso}")]
        public async Task<string> GetCnfEjecucionproceso(int CodigoEmpresa, int CodigoProceso, int SecuenciaProceso)
        {
            var cnfEjecucionProceso = await _CnfEjecucionProcesosRepository.GetCnfEjecucionProcesoAsync(CodigoEmpresa, CodigoProceso, SecuenciaProceso);

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strEjecucionProceso = JsonConvert.SerializeObject(cnfEjecucionProceso, options);

            return await Task.Run(() =>
            {
                return strEjecucionProceso;
            });
        }

        // PUT: api/CnfEjecucionProcesos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("PutCnfEjecucionProcesos")]
        public async Task<string> PutCnfEjecucionproceso(CnfEjecucionProcesoRequest cnfEjecucionproceso)
        {
            var response = new Response<object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _CnfEjecucionProcesosRepository.EditCnfEjecucionProcesosAsync(cnfEjecucionproceso);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // POST: api/CnfEjecucionProcesos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PostCnfEjecucionProcesos")]
        public async Task<string> PostCnfEjecucionproceso(CnfEjecucionProcesoRequest cnfEjecucionproceso)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _CnfEjecucionProcesosRepository.AddCnfEjecucionProcesoAsync(cnfEjecucionproceso);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // DELETE: api/CnfEjecucionProcesos/5
        [HttpDelete("DeleteCnfEjecucionProcesos")]
        public async Task<string> DeleteCnfEjecucionproceso(CnfEjecucionProcesoRequest cnfEjecucionproceso)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _CnfEjecucionProcesosRepository.DeleteCnfEjecucionProcesosAsync(cnfEjecucionproceso);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        private bool CnfEjecucionprocesoExists(int id)
        {
            return _context.CnfEjecucionprocesos.Any(e => e.CodigoEmpresa == id);
        }
    }
}
