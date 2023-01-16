using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ATSB.Api.Areas.Entities.Credito;
using ATSB.Api.Areas.Identity.Data;
using System.Text.Json;
using Newtonsoft.Json;
using ATSB.Api.Areas.Repositories.Configuracion;
using ATSB.Models;
using ATSB.Api.Models.Credito;
using Microsoft.EntityFrameworkCore.Metadata;
using ATSB.Api.Areas.Repositories.Credito;
using ATSB.Api.Areas.Entities.Configuracion;

namespace ATSB.Api.Controllers.Credito
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreMaestroController : ControllerBase
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly ICreMaestroRepository _CreMaestroRepository;

        public CreMaestroController(ATSBIdentityDbContext context, ICreMaestroRepository CreMaestroRepository)
        {
            _context = context;
            _CreMaestroRepository = CreMaestroRepository;
        }

        // GET: api/CreMaestro
        [HttpGet("GetCreMaestros")]
        public async Task<string> GetCreMaestros()
        {
            var dataCreMaestros = _CreMaestroRepository.GetCreMaestros();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strMaestros = JsonConvert.SerializeObject(dataCreMaestros, options);

            return await Task.Run(() =>
            {
                return strMaestros;
            });
        }

        // GET: api/CreMaestro/5
        [HttpGet("GetCreMaestro/{CodigoEmpresa}/{NumeroOperacion}")]
        public async Task<string> GetCreMaestro(int CodigoEmpresa, string NumeroOperacion)
        {
            var creMaestro = await _CreMaestroRepository.GetCreMaestroAsync(CodigoEmpresa, NumeroOperacion);

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strMaestro = JsonConvert.SerializeObject(creMaestro, options);

            return await Task.Run(() =>
            {
                return strMaestro;
            });
        }

        // PUT: api/CreMaestro/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("PutCreMaestro")]
        public async Task<string> PutCreMaestro(CreMaestroRequest creMaestro)
        {
            var response = new Response<object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _CreMaestroRepository.EditCreMaestroAsync(creMaestro);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // POST: api/CreMaestro
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PostCreMaestro")]
        public async Task<string> PostCreMaestro(CreMaestroRequest creMaestro)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _CreMaestroRepository.AddCreMaestroAsync(creMaestro);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // DELETE: api/CreMaestro/5
        [HttpDelete("DeleteCreMaestro")]
        public async Task<string> DeleteCreMaestro(CreMaestroRequest creMaestro)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _CreMaestroRepository.DeleteCreMaestroAsync(creMaestro);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        private bool CreMaestroExists(int id)
        {
            return _context.CreMaestros.Any(e => e.CodigoEmpresa == id);
        }
    }
}
