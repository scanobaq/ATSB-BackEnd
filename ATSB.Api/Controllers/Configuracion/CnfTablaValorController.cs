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
    public class CnfTablaValorController : ControllerBase
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly ICnfTablaValorRepository _CnfTablaValorRepository;

        public CnfTablaValorController(ATSBIdentityDbContext context, ICnfTablaValorRepository CnfTablaValorRepository)
        {
            _context = context;
            _CnfTablaValorRepository = CnfTablaValorRepository;
        }

        // GET: api/CnfTablaValor
        [HttpGet("GetCnfTablaValores")]
        public async Task<string> GetCnfTablavalors()
        {
            var dataCnfTablaValores = _CnfTablaValorRepository.GetCnfTablaValores();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strTablaValores = JsonConvert.SerializeObject(dataCnfTablaValores, options);

            return await Task.Run(() =>
            {
                return strTablaValores;
            });
        }

        // GET: api/CnfTablaValor/5
        [HttpGet("GetCnfTablaValor/{CodigoEmpresa}/{CodigoTabla}/{IdValor}")]
        public async Task<string> GetCnfTablavalor(int CodigoEmpresa, int CodigoTabla, int IdValor)
        {
            var cnfTablaValor = await _CnfTablaValorRepository.GetCnfTablaValorAsync(CodigoEmpresa, CodigoTabla, IdValor);

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strTablaValor = JsonConvert.SerializeObject(cnfTablaValor, options);

            return await Task.Run(() =>
            {
                return strTablaValor;
            });
        }

        // PUT: api/CnfTablaValor/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("PutCnfTablaValor")]
        public async Task<string> PutCnfTablavalor(CnfTablaValorRequest cnfTablavalor)
        {
            var response = new Response<object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _CnfTablaValorRepository.EditCnfTablaValorAsync(cnfTablavalor);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // POST: api/CnfTablaValor
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PostCnfTablaValor")]
        public async Task<string> PostCnfTablavalor(CnfTablaValorRequest cnfTablavalor)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _CnfTablaValorRepository.AddCnfTablaValorAsync(cnfTablavalor);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // DELETE: api/CnfTablaValor/5
        [HttpDelete("DeleteCnfTablaValor")]
        public async Task<string> DeleteCnfTablavalor(CnfTablaValorRequest cnfTablavalor)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _CnfTablaValorRepository.DeleteCnfTablaValorAsync(cnfTablavalor);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        private bool CnfTablavalorExists(int id)
        {
            return _context.CnfTablavalors.Any(e => e.CodigoEmpresa == id);
        }
    }
}
