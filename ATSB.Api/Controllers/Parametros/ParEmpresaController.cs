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
    public class ParEmpresaController : ControllerBase
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IParEmpresaRepository _ParEmpresaRepository;

        public ParEmpresaController(ATSBIdentityDbContext context, IParEmpresaRepository ParEmpresaRepository)
        {
            _context = context;
            _ParEmpresaRepository = ParEmpresaRepository;
        }

        // GET: api/ParEmpresa
        [HttpGet("GetParEmpresas")]
        public async Task<string> GetParEmpresas()
        {
            var dataParEmpresas = _ParEmpresaRepository.GetParEmpresas();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strEmpresas = JsonConvert.SerializeObject(dataParEmpresas, options);

            return await Task.Run(() =>
            {
                return strEmpresas;
            });
        }

        // GET: api/ParEmpresa/5
        [HttpGet("GetParEmpresa/{CodigoEmpresa}")]
        public async Task<string> GetParEmpresa(int CodigoEmpresa)
        {
            var parEmpresa = await _ParEmpresaRepository.GetParEmpresaAsync(CodigoEmpresa);

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strEmpresa = JsonConvert.SerializeObject(parEmpresa, options);

            return await Task.Run(() =>
            {
                return strEmpresa;
            });
        }

        // PUT: api/ParEmpresa/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("PutParEmpresa")]
        public async Task<string> PutParEmpresa(ParEmpresaRequest parEmpresa)
        {
            var response = new Response<object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _ParEmpresaRepository.EditParEmpresaAsync(parEmpresa);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // POST: api/ParEmpresa
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PostParEmpresa")]
        public async Task<string> PostParEmpresa(ParEmpresaRequest parEmpresa)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _ParEmpresaRepository.AddParEmpresaAsync(parEmpresa);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // DELETE: api/ParEmpresa/5
        [HttpDelete("DeleteParEmpresa")]
        public async Task<string> DeleteParEmpresa(ParEmpresaRequest parEmpresa)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _ParEmpresaRepository.DeleteParEmpresaAsync(parEmpresa);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        private bool ParEmpresaExists(int id)
        {
            return _context.ParEmpresas.Any(e => e.CodigoEmpresa == id);
        }
    }
}
