using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ATSB.Api.Areas.Entities.Parametros;
using ATSB.Api.Areas.Identity.Data;
using System.Text.Json;
using Newtonsoft.Json;
using ATSB.Api.Areas.Repositories.Parametros;
using ATSB.Models;
using ATSB.Api.Models.Parametros;

namespace ATSB.Api.Controllers.Parametros
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParConsecutivoController : ControllerBase
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IParConsecutivoRepository _ParConsecutivoRepository;

        public ParConsecutivoController(ATSBIdentityDbContext context, IParConsecutivoRepository ParConsecutivoRepository)
        {
            _context = context;
            _ParConsecutivoRepository = ParConsecutivoRepository;
        }

        // GET: api/ParConsecutivo
        [HttpGet("GetParConsecutivos")]
        public async Task<string> GetParConsecutivos()
        {
            var dataParConsecutivos = _ParConsecutivoRepository.GetParConsecutivos();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strConsecutivos = JsonConvert.SerializeObject(dataParConsecutivos, options);

            return await Task.Run(() =>
            {
                return strConsecutivos;
            });
        }

        // GET: api/ParConsecutivo/5
        [HttpGet("GetParConsecutivo/{CodigoEmpresa}/{IdConsecutivo}")]
        public async Task<string> GetParConsecutivo(int CodigoEmpresa, string IdConsecutivo)
        {
            var parConsecutivo = await _ParConsecutivoRepository.GetParConsecutivoAsync(CodigoEmpresa, IdConsecutivo);

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strConsecutivo = JsonConvert.SerializeObject(parConsecutivo, options);

            return await Task.Run(() =>
            {
                return strConsecutivo;
            });
        }

        // PUT: api/ParConsecutivo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("PutParConsecutivo")]
        public async Task<string> PutParConsecutivo(ParConsecutivoRequest parConsecutivo)
        {
            var response = new Response<object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _ParConsecutivoRepository.EditParConsecutivoAsync(parConsecutivo);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // POST: api/ParConsecutivo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PostParConsecutivo")]
        public async Task<string> PostParConsecutivo(ParConsecutivoRequest parConsecutivo)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _ParConsecutivoRepository.AddParConsecutivoAsync(parConsecutivo);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // DELETE: api/ParConsecutivo/5
        [HttpDelete("DeleteParConsecutivo")]
        public async Task<string> DeleteParConsecutivo(ParConsecutivoRequest parConsecutivo)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _ParConsecutivoRepository.DeleteParConsecutivoAsync(parConsecutivo);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        private bool ParConsecutivoExists(int id)
        {
            return _context.ParConsecutivos.Any(e => e.CodigoEmpresa == id);
        }
    }
}
