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
    public class CnfArchivoController : ControllerBase
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly ICnfArchivoRepository _CnfArchivoRepository;

        public CnfArchivoController(ATSBIdentityDbContext context, ICnfArchivoRepository CnfArchivoRepository)
        {
            _context = context;
            _CnfArchivoRepository = CnfArchivoRepository;
        }

        // GET: api/CnfArchivo
        [HttpGet("GetCnfArchivos")]
        public async Task<string> GetCnfArchivos()
        {
            var dataCnfArchivos = _CnfArchivoRepository.GetCnfArchivos();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strArchivos = JsonConvert.SerializeObject(dataCnfArchivos, options);

            return await Task.Run(() =>
            {
                return strArchivos;
            });
        }

        // GET: api/CnfArchivo/5
        [HttpGet("GetCnfArchivo/{CodigoEmpresa}/{IdArchivo}")]
        public async Task<string> GetCnfArchivo(int CodigoEmpresa, int IdArchivo)
        {
            var cnfArchivo = await _CnfArchivoRepository.GetCnfArchivoAsync(CodigoEmpresa, IdArchivo);

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strArchivo = JsonConvert.SerializeObject(cnfArchivo, options);

            return await Task.Run(() =>
            {
                return strArchivo;
            });
        }

        // PUT: api/CnfArchivo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("PutCnfArchivo")]
        public async Task<string> PutCnfArchivo(CnfArchivoRequest cnfArchivo)
        {
            var response = new Response<object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _CnfArchivoRepository.EditCnfArchivoAsync(cnfArchivo);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // POST: api/CnfArchivo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PostCnfArchivo")]
        public async Task<string> PostCnfArchivo(CnfArchivoRequest cnfArchivo)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _CnfArchivoRepository.AddCnfArchivoAsync(cnfArchivo);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // DELETE: api/CnfArchivo/5
        [HttpDelete("DeleteCnfArchivo")]
        public async Task<string> DeleteCnfArchivo(CnfArchivoRequest cnfArchivo)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _CnfArchivoRepository.DeleteCnfArchivoAsync(cnfArchivo);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        private bool CnfArchivoExists(int id)
        {
            return _context.CnfArchivos.Any(e => e.CodigoEmpresa == id);
        }
    }
}
