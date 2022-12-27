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
    public class ParMonedaController : ControllerBase
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IParMonedaRepository _ParMonedaRepository;

        public ParMonedaController(ATSBIdentityDbContext context, IParMonedaRepository ParMonedaRepository)
        {
            _context = context;
            _ParMonedaRepository = ParMonedaRepository;
        }

        // GET: api/ParMoneda
        [HttpGet("GetParMonedas")]
        public async Task<string> GetParMoneda()
        {
            var dataParMonedas = _ParMonedaRepository.GetParMonedas();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strMonedas = JsonConvert.SerializeObject(dataParMonedas, options);

            return await Task.Run(() =>
            {
                return strMonedas;
            });
        }

        // GET: api/ParMoneda/5
        [HttpGet("GetParMoneda/{CodigoEmpresa}/{CodigoMoneda}")]
        public async Task<string> GetParMonedum(int CodigoEmpresa, int CodigoMoneda)
        {
            var parMoneda = await _ParMonedaRepository.GetParMonedaAsync(CodigoEmpresa, CodigoMoneda);

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strMoneda = JsonConvert.SerializeObject(parMoneda, options);

            return await Task.Run(() =>
            {
                return strMoneda;
            });
        }

        // PUT: api/ParMoneda/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("PutParMoneda")]
        public async Task<string> PutParMonedum(ParMonedaRequest parMonedum)
        {
            var response = new Response<object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _ParMonedaRepository.EditParMonedaAsync(parMonedum);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // POST: api/ParMoneda
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PostParMoneda")]
        public async Task<string> PostParMonedum(ParMonedaRequest parMonedum)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _ParMonedaRepository.AddParMonedaAsync(parMonedum);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // DELETE: api/ParMoneda/5
        [HttpDelete("DeleteParMoneda")]
        public async Task<string> DeleteParMonedum(ParMonedaRequest parMonedum)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _ParMonedaRepository.DeleteParMonedaAsync(parMonedum);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        private bool ParMonedumExists(int id)
        {
            return _context.ParMoneda.Any(e => e.CodigoEmpresa == id);
        }
    }
}
