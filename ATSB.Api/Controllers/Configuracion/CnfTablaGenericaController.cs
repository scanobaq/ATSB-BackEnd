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

namespace ATSB.Api.Controllers.Configuracion
{
    [Route("api/[controller]")]
    [ApiController]
    public class CnfTablaGenericaController : ControllerBase
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly ICnfTablaGenericaRepository _CnfTablaGenericaRepository;

        public CnfTablaGenericaController(ATSBIdentityDbContext context, ICnfTablaGenericaRepository CnfTablaGenericaRepository)
        {
            _context = context;
            _CnfTablaGenericaRepository = CnfTablaGenericaRepository;
        }

        // GET: api/CnfTablaGenerica
        [HttpGet("GetCnfTablasGenericas")]
        public async Task<string> GetCnfTablagenericas()
        {
            var dataCnfTablasGenericas = _CnfTablaGenericaRepository.GetCnfTablasGenericas();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strTablas = JsonConvert.SerializeObject(dataCnfTablasGenericas, options);

            return await Task.Run(() =>
            {
                return strTablas;
            });
        }

        // GET: api/CnfTablaGenerica/5
        [HttpGet("GetCnfTablaGenerica/{CodigoEmpresa}/{IdTabla}")]
        public async Task<string> GetCnfTablagenerica(int CodigoEmpresa, int IdTabla)
        {
            var cnfTablaGenerica = await _CnfTablaGenericaRepository.GetCnfTablaGenericaAsync(CodigoEmpresa, IdTabla);

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strTabla = JsonConvert.SerializeObject(cnfTablaGenerica, options);

            return await Task.Run(() =>
            {
                return strTabla;
            });
        }

        // PUT: api/CnfTablaGenerica/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("PutCnfTablaGenerica")]
        public async Task<string> PutCnfTablagenerica(CnfTablaGenericaRequest cnfTablagenerica)
        {
            var response = new Response<object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _CnfTablaGenericaRepository.EditCnfTablaGenericaAsync(cnfTablagenerica);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // POST: api/CnfTablaGenerica
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PostCnfTablaGenerica")]
        public async Task<string> PostCnfTablagenerica(CnfTablaGenericaRequest cnfTablagenerica)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _CnfTablaGenericaRepository.AddCnfTablaGenericaAsync(cnfTablagenerica);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // DELETE: api/CnfTablaGenerica/5
        [HttpDelete("DeleteCnfTablaGenerica")]
        public async Task<string> DeleteCnfTablagenerica(CnfTablaGenericaRequest cnfTablagenerica)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _CnfTablaGenericaRepository.DeleteCnfTablaGenericaAsync(cnfTablagenerica);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        private bool CnfTablagenericaExists(int id)
        {
            return _context.CnfTablagenericas.Any(e => e.CodigoEmpresa == id);
        }
    }
}
