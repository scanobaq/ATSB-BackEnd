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
    public class CnfTablaGenericaCamposController : ControllerBase
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly ICnfTablaGenericaCamposRepository _CnfTablaGenericaCamposRepository;

        public CnfTablaGenericaCamposController(ATSBIdentityDbContext context, ICnfTablaGenericaCamposRepository CnfTablaGenericaCamposRepository)
        {
            _context = context;
            _CnfTablaGenericaCamposRepository = CnfTablaGenericaCamposRepository;
        }

        // GET: api/CnfTablaGenericaCampos
        [HttpGet("GetCnfTablasGenericasCampos")]
        public async Task<string> GetCnfTablagenericacampos()
        {
            var dataCnfTablasGenericasCampos = _CnfTablaGenericaCamposRepository.GetCnfTablasGenericasCampos();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strTablasGCampos = JsonConvert.SerializeObject(dataCnfTablasGenericasCampos, options);

            return await Task.Run(() =>
            {
                return strTablasGCampos;
            });
        }

        // GET: api/CnfTablaGenericaCampos/5
        [HttpGet("GetCnfTablaGenericaCampos/{CodigoEmpresa}/{IdTabla}/{IdCampo}")]
        public async Task<string> GetCnfTablagenericacampo(int CodigoEmpresa, int IdTabla, string IdCampo)
        {
            var cnfTablaGenericaCampos = await _CnfTablaGenericaCamposRepository.GetCnfTablaGenericaCamposAsync(CodigoEmpresa, IdTabla, IdCampo);

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strTablaGCampos = JsonConvert.SerializeObject(cnfTablaGenericaCampos, options);

            return await Task.Run(() =>
            {
                return strTablaGCampos;
            });
        }

        // PUT: api/CnfTablaGenericaCampos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("PutCnfTablaGenericaCampos")]
        public async Task<string> PutCnfTablagenericacampo(CnfTablaGenericaCamposRequest cnfTablagenericacampo)
        {
            var response = new Response<object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _CnfTablaGenericaCamposRepository.EditCnfTablaGenericaCamposAsync(cnfTablagenericacampo);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // POST: api/CnfTablaGenericaCampos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PostCnfTablaGenericaCampos")]
        public async Task<string> PostCnfTablagenericacampo(CnfTablaGenericaCamposRequest cnfTablagenericacampo)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _CnfTablaGenericaCamposRepository.AddCnfTablaGenericaCamposAsync(cnfTablagenericacampo);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // DELETE: api/CnfTablaGenericaCampos/5
        [HttpDelete("DeleteCnfTablaGenericaCampos")]
        public async Task<string> DeleteCnfTablagenericacampo(CnfTablaGenericaCamposRequest cnfTablagenericacampo)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _CnfTablaGenericaCamposRepository.DeleteCnfTablaGenericaCamposAsync(cnfTablagenericacampo);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        private bool CnfTablagenericacampoExists(int id)
        {
            return _context.CnfTablagenericacampos.Any(e => e.CodigoEmpresa == id);
        }
    }
}
