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
    public class CnfTablaController : ControllerBase
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly ICnfTablaRepository _CnfTablaRepository;

        public CnfTablaController(ATSBIdentityDbContext context, ICnfTablaRepository CnfTablaRepository)
        {
            _context = context;
            _CnfTablaRepository = CnfTablaRepository;
        }

        // GET: api/CnfTabla
        [HttpGet("GetCnfTablas")]
        public async Task<string> GetCnfTablas()
        {
            var dataCnfTablas = _CnfTablaRepository.GetCnfTablas();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strTablas = JsonConvert.SerializeObject(dataCnfTablas, options);

            return await Task.Run(() =>
            {
                return strTablas;
            });
        }

        // GET: api/CnfTabla/5
        [HttpGet("GetCnfTabla/{CodigoEmpresa}/{CodigoTabla}")]
        public async Task<string> GetCnfTabla(int CodigoEmpresa, int CodigoTabla)
        {
            var cnfTabla = await _CnfTablaRepository.GetCnfTablaAsync(CodigoEmpresa, CodigoTabla);

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strTabla = JsonConvert.SerializeObject(cnfTabla, options);

            return await Task.Run(() =>
            {
                return strTabla;
            });
        }

        // PUT: api/CnfTabla/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("PutCnfTabla")]
        public async Task<string> PutCnfTabla(CnfTablaRequest cnfTabla)
        {
            var response = new Response<object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _CnfTablaRepository.EditCnfTablaAsync(cnfTabla);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // POST: api/CnfTabla
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PostCnfTabla")]
        public async Task<string> PostCnfTabla(CnfTablaRequest cnfTabla)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _CnfTablaRepository.AddCnfTablaAsync(cnfTabla);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // DELETE: api/CnfTabla/5
        [HttpDelete("DeleteCnfTabla")]
        public async Task<string> DeleteCnfTabla(CnfTablaRequest cnfTabla)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _CnfTablaRepository.DeleteCnfTablaAsync(cnfTabla);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        private bool CnfTablaExists(int id)
        {
            return _context.CnfTablas.Any(e => e.CodigoEmpresa == id);
        }
    }
}
