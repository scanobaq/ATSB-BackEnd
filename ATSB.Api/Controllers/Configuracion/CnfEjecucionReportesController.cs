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

namespace ATSB.Api.Controllers.Configuracion
{
    [Route("api/[controller]")]
    [ApiController]
    public class CnfEjecucionReportesController : ControllerBase
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly ICnfEjecucionReportesRepository _CnfEjecucionReportesRepository;

        public CnfEjecucionReportesController(ATSBIdentityDbContext context, ICnfEjecucionReportesRepository CnfEjecucionReportesRepository)
        {
            _context = context;
            _CnfEjecucionReportesRepository = CnfEjecucionReportesRepository;
        }

        // GET: api/CnfEjecucionReportes
        [HttpGet("GetCnfEjecucionReportes")]
        public async Task<string> GetCnfEjecucionreportes()
        {
            var dataCnfEjecucionReportes = _CnfEjecucionReportesRepository.GetCnfEjecucionReportes();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strEjecucionReportes = JsonConvert.SerializeObject(dataCnfEjecucionReportes, options);

            return await Task.Run(() =>
            {
                return strEjecucionReportes;
            });
        }

        // GET: api/CnfEjecucionReportes/5
        [HttpGet("GetCnfEjecucionReporte/{CodigoEmpresa}/{Id}")]
        public async Task<string> GetCnfEjecucionreporte(int CodigoEmpresa, int Id)
        {
            var cnfEjecucionReporte = await _CnfEjecucionReportesRepository.GetCnfEjecucionReporteAsync(CodigoEmpresa, Id);

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strEjecucionReporte = JsonConvert.SerializeObject(cnfEjecucionReporte, options);

            return await Task.Run(() =>
            {
                return strEjecucionReporte;
            });
        }

        // PUT: api/CnfEjecucionReportes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("PutCnfEjecucionReportes")]
        public async Task<string> PutCnfEjecucionreporte(CnfEjecucionReportesRequest cnfEjecucionreportes)
        {
            var response = new Response<object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _CnfEjecucionReportesRepository.EditCnfEjecucionReportesAsync(cnfEjecucionreportes);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // POST: api/CnfEjecucionReportes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PostCnfEjecucionReportes")]
        public async Task<string> PostCnfEjecucionreporte(CnfEjecucionReportesRequest cnfEjecucionreportes)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _CnfEjecucionReportesRepository.AddCnfEjecucionReportesAsync(cnfEjecucionreportes);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // DELETE: api/CnfEjecucionReportes/5
        [HttpDelete("DeleteCnfEjecucionReportes")]
        public async Task<string> DeleteCnfEjecucionreporte(CnfEjecucionReportesRequest cnfEjecucionreportes)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _CnfEjecucionReportesRepository.DeleteCnfEjecucionReportesAsync(cnfEjecucionreportes);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        private bool CnfEjecucionreporteExists(int id)
        {
            return _context.CnfEjecucionreportes.Any(e => e.CodigoEmpresa == id);
        }
    }
}
