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
    public class ParEstadoController : ControllerBase
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IParEstadoRepository _ParEstadoRepository;

        public ParEstadoController(ATSBIdentityDbContext context, IParEstadoRepository ParEstadoRepository)
        {
            _context = context;
            _ParEstadoRepository = ParEstadoRepository;
        }

        // GET: api/ParEstado
        [HttpGet("GetParEstados")]
        public async Task<string> GetParEstados()
        {
            var dataParEstados = _ParEstadoRepository.GetParEstados();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strEstados = JsonConvert.SerializeObject(dataParEstados, options);

            return await Task.Run(() =>
            {
                return strEstados;
            });
        }

        // GET: api/ParEstado/5
        [HttpGet("GetParEstado/{CodigoEstado}")]
        public async Task<string> GetParEstado(int CodigoEstado)
        {
            var parEstado = await _ParEstadoRepository.GetParEstadoAsync(CodigoEstado);

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strEstado = JsonConvert.SerializeObject(parEstado, options);

            return await Task.Run(() =>
            {
                return strEstado;
            });
        }

        // PUT: api/ParEstado/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("PutParEstado")]
        public async Task<string> PutParEstado(ParEstadoRequest parEstado)
        {
            var response = new Response<object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _ParEstadoRepository.EditParEstadoAsync(parEstado);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // POST: api/ParEstado
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PostParEstado")]
        public async Task<string> PostParEstado(ParEstadoRequest parEstado)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _ParEstadoRepository.AddParEstadoAsync(parEstado);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // DELETE: api/ParEstado/5
        [HttpDelete("DeleteParEstado")]
        public async Task<string> DeleteParEstado(ParEstadoRequest parEstado)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _ParEstadoRepository.DeleteParEstadoAsync(parEstado);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        private bool ParEstadoExists(int id)
        {
            return _context.ParEstados.Any(e => e.CodigoEstado == id);
        }
    }
}
