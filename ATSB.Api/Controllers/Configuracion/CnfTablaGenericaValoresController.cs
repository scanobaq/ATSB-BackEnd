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
    public class CnfTablaGenericaValoresController : ControllerBase
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly ICnfTablaGenericaValoresRepository _CnfTablaGenericaValoresRepository;

        public CnfTablaGenericaValoresController(ATSBIdentityDbContext context, ICnfTablaGenericaValoresRepository CnfTablaGenericaValoresRepository)
        {
            _context = context;
            _CnfTablaGenericaValoresRepository = CnfTablaGenericaValoresRepository;
        }

        // GET: api/CnfTablaGenericaValores
        [HttpGet("GetCnfTablasGenericasValores")]
        public async Task<string> GetCnfTablagenericavalores()
        {
            var dataCnfTablasGenericasValores = _CnfTablaGenericaValoresRepository.GetCnfTablasGenericasValores();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strTablas = JsonConvert.SerializeObject(dataCnfTablasGenericasValores, options);

            return await Task.Run(() =>
            {
                return strTablas;
            });
        }

        // GET: api/CnfTablaGenericaValores/5
        [HttpGet("GetCnfTablaGenericaValores/{CodigoEmpresa}/{IdTabla}/{IdValor}")]
        public async Task<string> GetCnfTablagenericavalore(int CodigoEmpresa, int IdTabla, int IdValor)
        {
            var cnfTablaGenericaValores = await _CnfTablaGenericaValoresRepository.GetCnfTablaGenericaValoresAsync(CodigoEmpresa, IdTabla, IdValor);

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strTabla = JsonConvert.SerializeObject(cnfTablaGenericaValores, options);

            return await Task.Run(() =>
            {
                return strTabla;
            });
        }

        // PUT: api/CnfTablaGenericaValores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("PutCnfTablaGenericaValores")]
        public async Task<string> PutCnfTablagenericavalore(CnfTablaGenericaValoresRequest cnfTablagenericavalores)
        {
            var response = new Response<object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _CnfTablaGenericaValoresRepository.EditCnfTablaGenericaValoresAsync(cnfTablagenericavalores);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // POST: api/CnfTablaGenericaValores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PostCnfTablaGenericaValores")]
        public async Task<string> PostCnfTablagenericavalore(CnfTablaGenericaValoresRequest cnfTablagenericavalores)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _CnfTablaGenericaValoresRepository.AddCnfTablaGenericaValoresAsync(cnfTablagenericavalores);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // DELETE: api/CnfTablaGenericaValores/5
        [HttpDelete("DeleteCnfTablaGenericaValores")]
        public async Task<string> DeleteCnfTablagenericavalore(CnfTablaGenericaValoresRequest cnfTablagenericavalores)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _CnfTablaGenericaValoresRepository.DeleteCnfTablaGenericaValoresAsync(cnfTablagenericavalores);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        private bool CnfTablagenericavaloreExists(int id)
        {
            return _context.CnfTablagenericavalores.Any(e => e.CodigoEmpresa == id);
        }
    }
}
