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
    public class ParCalificacionRiesgoController : ControllerBase
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IParCalificacionRiesgoRepository _ParCalificacionRiesgoRepository;

        public ParCalificacionRiesgoController(ATSBIdentityDbContext context, IParCalificacionRiesgoRepository ParCalificacionRiesgoRepository)
        {
            _context = context;
            _ParCalificacionRiesgoRepository = ParCalificacionRiesgoRepository;
        }

        // GET: api/ParCalificacionRiesgo
        [HttpGet("GetParCalificacionRiesgos")]
        public async Task<string> GetParCalificacionriesgos()
        {
            var dataParCalificacionRiesgos = _ParCalificacionRiesgoRepository.GetParCalificacionRiesgos();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strCalificacionRiesgos = JsonConvert.SerializeObject(dataParCalificacionRiesgos, options);

            return await Task.Run(() =>
            {
                return strCalificacionRiesgos;
            });
        }

        // GET: api/ParCalificacionRiesgo/5
        [HttpGet("GetParCalificacionRiesgo/{CodigoEmpresa}/{Id}")]
        public async Task<string> GetParCalificacionriesgo(int CodigoEmpresa, int Id)
        {
            var parCalificacionRiesgo = await _ParCalificacionRiesgoRepository.GetParCalificacionRiesgoAsync(CodigoEmpresa, Id);

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strCalificacionRiesgo = JsonConvert.SerializeObject(parCalificacionRiesgo, options);

            return await Task.Run(() =>
            {
                return strCalificacionRiesgo;
            });
        }

        // PUT: api/ParCalificacionRiesgo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("PutParCalificacionRiesgo")]
        public async Task<string> PutParCalificacionriesgo(ParCalificacionRiesgoRequest parCalificacionriesgo)
        {
            var response = new Response<object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _ParCalificacionRiesgoRepository.EditParCalificacionRiesgoAsync(parCalificacionriesgo);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // POST: api/ParCalificacionRiesgo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PostParCalificacionRiesgo")]
        public async Task<string> PostParCalificacionriesgo(ParCalificacionRiesgoRequest parCalificacionriesgo)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _ParCalificacionRiesgoRepository.AddParCalificacionRiesgoAsync(parCalificacionriesgo);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // DELETE: api/ParCalificacionRiesgo/5
        [HttpDelete("DeleteParCalificacionRiesgo")]
        public async Task<string> DeleteParCalificacionriesgo(ParCalificacionRiesgoRequest parCalificacionriesgo)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _ParCalificacionRiesgoRepository.DeleteParCalificacionRiesgoAsync(parCalificacionriesgo);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        private bool ParCalificacionriesgoExists(int id)
        {
            return _context.ParCalificacionriesgos.Any(e => e.CodigoEmpresa == id);
        }
    }
}
