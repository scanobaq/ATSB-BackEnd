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
    public class CnfArchivoCampoController : ControllerBase
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly ICnfArchivoCampoRepository _CnfArchivoCampoRepository;

        public CnfArchivoCampoController(ATSBIdentityDbContext context, ICnfArchivoCampoRepository CnfArchivoCampoRepository)
        {
            _context = context;
            _CnfArchivoCampoRepository = CnfArchivoCampoRepository;
        }

        // GET: api/CnfArchivoCampo
        [HttpGet("GetCnfArchivoCampos")]
        public async Task<string> GetCnfArchivocampos()
        {
            var dataCnfArchivoCampos = _CnfArchivoCampoRepository.GetCnfArchivoCampos();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strArchivoCampos = JsonConvert.SerializeObject(dataCnfArchivoCampos, options);

            return await Task.Run(() =>
            {
                return strArchivoCampos;
            });
        }

        // GET: api/CnfArchivoCampo/5
        [HttpGet("GetCnfArchivoCampo/{CodigoEmpresa}/{IdArchivo}/{IdCampo}")]
        public async Task<string> GetCnfArchivocampo(int CodigoEmpresa, int IdArchivo, int IdCampo)
        {
            var cnfArchivoCampo = await _CnfArchivoCampoRepository.GetCnfArchivoCampoAsync(CodigoEmpresa, IdArchivo, IdCampo);

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strArchivoCampo = JsonConvert.SerializeObject(cnfArchivoCampo, options);

            return await Task.Run(() =>
            {
                return strArchivoCampo;
            });
        }

        // PUT: api/CnfArchivoCampo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("PutCnfArchivoCampo")]
        public async Task<string> PutCnfArchivocampo(CnfArchivoCampoRequest cnfArchivocampo)
        {
            var response = new Response<object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _CnfArchivoCampoRepository.EditCnfArchivoCampoAsync(cnfArchivocampo);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // POST: api/CnfArchivoCampo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PostCnfArchivoCampo")]
        public async Task<string> PostCnfArchivocampo(CnfArchivoCampoRequest cnfArchivocampo)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _CnfArchivoCampoRepository.AddCnfArchivoCampoAsync(cnfArchivocampo);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // DELETE: api/CnfArchivoCampo/5
        [HttpDelete("DeleteCnfArchivoCampo")]
        public async Task<string> DeleteCnfArchivocampo(CnfArchivoCampoRequest cnfArchivocampo)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _CnfArchivoCampoRepository.DeleteCnfArchivoCampoAsync(cnfArchivocampo);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        private bool CnfArchivocampoExists(int id)
        {
            return _context.CnfArchivocampos.Any(e => e.CodigoEmpresa == id);
        }
    }
}
