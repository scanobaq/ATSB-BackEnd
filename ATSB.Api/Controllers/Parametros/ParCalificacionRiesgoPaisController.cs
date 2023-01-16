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
using System.Text.Json.Serialization.Metadata;

namespace ATSB.Api.Controllers.Parametros
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParCalificacionRiesgoPaisController : ControllerBase
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IParCalificacionRiesgoPaisRepository _ParCalificacionRiesgoPaisRepository;

        public ParCalificacionRiesgoPaisController(ATSBIdentityDbContext context, IParCalificacionRiesgoPaisRepository ParCalificacionRiesgoPaisRepository)
        {
            _context = context;
            _ParCalificacionRiesgoPaisRepository = ParCalificacionRiesgoPaisRepository;
        }

        // GET: api/ParCalificacionRiesgoPais
        [HttpGet("GetParCalificacionRiesgoPaises")]
        public async Task<string> GetParCalificacionriesgopais()
        {
            var dataParCalificacionRiesgoPaises = _ParCalificacionRiesgoPaisRepository.GetParCalificacionRiesgoPaises();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strCalificacionRiesgoPaises = JsonConvert.SerializeObject(dataParCalificacionRiesgoPaises, options);

            return await Task.Run(() =>
            {
                return strCalificacionRiesgoPaises;
            });
        }

        // GET: api/ParCalificacionRiesgoPais/5
        [HttpGet("GetParCalificacionRiesgoPais/{CodigoEmpresa}/{CodigoPais}")]
        public async Task<string> GetParCalificacionriesgopai(int CodigoEmpresa, int CodigoPais)
        {
            var parCalificacionRiesgoPais = await _ParCalificacionRiesgoPaisRepository.GetParCalificacionRiesgoPaisAsync(CodigoEmpresa, CodigoPais);

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strCalificacionRiesgoPais = JsonConvert.SerializeObject(parCalificacionRiesgoPais, options);

            return await Task.Run(() =>
            {
                return strCalificacionRiesgoPais;
            });
        }

        // PUT: api/ParCalificacionRiesgoPais/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("PutParCalificacionRiesgoPais")]
        public async Task<string> PutParCalificacionriesgopai(ParCalificacionRiesgoPaisRequest parCalificacionRiesgoPais)
        {
            var response = new Response<object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _ParCalificacionRiesgoPaisRepository.EditParCalificacionRiesgoPaisAsync(parCalificacionRiesgoPais);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // POST: api/ParCalificacionRiesgoPais
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PostParCalificacionRiesgoPais")]
        public async Task<string> PostParCalificacionriesgopai(ParCalificacionRiesgoPaisRequest parCalificacionRiesgoPais)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _ParCalificacionRiesgoPaisRepository.AddParCalificacionRiesgoPaisAsync(parCalificacionRiesgoPais);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // DELETE: api/ParCalificacionRiesgoPais/5
        [HttpDelete("DeleteParCalificacionRiesgoPais")]
        public async Task<string> DeleteParCalificacionriesgopai(ParCalificacionRiesgoPaisRequest parCalificacionRiesgoPais)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _ParCalificacionRiesgoPaisRepository.DeleteParCalificacionRiesgoPaisAsync(parCalificacionRiesgoPais);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        private bool ParCalificacionriesgopaiExists(int id)
        {
            return _context.ParCalificacionriesgopais.Any(e => e.CodigoEmpresa == id);
        }
    }
}
