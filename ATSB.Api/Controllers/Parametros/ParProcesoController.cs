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
    public class ParProcesoController : ControllerBase
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IParProcesoRepository _ParProcesoRepository;

        public ParProcesoController(ATSBIdentityDbContext context, IParProcesoRepository ParProcesoRepository)
        {
            _context = context;
            _ParProcesoRepository = ParProcesoRepository;
        }

        // GET: api/ParProceso
        [HttpGet("GetParProcesos")]
        public async Task<string> GetParProcesos()
        {
            var dataParProcesos = _ParProcesoRepository.GetParProcesos();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strProcesos = JsonConvert.SerializeObject(dataParProcesos, options);

            return await Task.Run(() =>
            {
                return strProcesos;
            });
        }

        // GET: api/ParProceso/5
        [HttpGet("GetParProceso/{CodigoEmpresa}/{CodigoProceso}")]
        public async Task<string> GetParProceso(int CodigoEmpresa, int CodigoProceso)
        {
            var parProceso = await _ParProcesoRepository.GetParProcesoAsync(CodigoEmpresa, CodigoProceso);

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strProceso = JsonConvert.SerializeObject(parProceso, options);

            return await Task.Run(() =>
            {
                return strProceso;
            });
        }

        // PUT: api/ParProceso/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("PutParProceso")]
        public async Task<string> PutParProceso(ParProcesoRequest parProceso)
        {
            var response = new Response<object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _ParProcesoRepository.EditParProcesoAsync(parProceso);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // POST: api/ParProceso
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PostParProceso")]
        public async Task<string> PostParProceso(ParProcesoRequest parProceso)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _ParProcesoRepository.AddParProcesoAsync(parProceso);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // DELETE: api/ParProceso/5
        [HttpDelete("DeleteParProceso")]
        public async Task<string> DeleteParProceso(ParProcesoRequest parProceso)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _ParProcesoRepository.DeleteParProcesoAsync(parProceso);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        private bool ParProcesoExists(int id)
        {
            return _context.ParProcesos.Any(e => e.CodigoProceso == id);
        }
    }
}
