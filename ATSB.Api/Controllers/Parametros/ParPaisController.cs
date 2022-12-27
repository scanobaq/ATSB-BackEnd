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
    public class ParPaisController : ControllerBase
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IParPaisRepository _ParPaisRepository;

        public ParPaisController(ATSBIdentityDbContext context, IParPaisRepository ParPaisRepository)
        {
            _context = context;
            _ParPaisRepository = ParPaisRepository; 
        }

        // GET: api/ParPais
        [HttpGet("GetParPaises")]
        public async Task<string> GetParPais()
        {
            var dataParPaises = _ParPaisRepository.GetParPaises();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strPaises = JsonConvert.SerializeObject(dataParPaises, options);

            return await Task.Run(() =>
            {
                return strPaises;
            });
        }

        // GET: api/ParPais/5
        [HttpGet("GetParPais/{CodigoPais}")]
        public async Task<string> GetParPai(int CodigoPais)
        {
            var parPais = await _ParPaisRepository.GetParPaisAsync(CodigoPais);

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strPais = JsonConvert.SerializeObject(parPais, options);

            return await Task.Run(() =>
            {
                return strPais;
            });
        }

        // PUT: api/ParPais/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("PutParPais")]
        public async Task<string> PutParPai(ParPaisRequest parPais)
        {
            var response = new Response<object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _ParPaisRepository.EditParPaisAsync(parPais);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // POST: api/ParPais
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PostParPais")]
        public async Task<string> PostParPai(ParPaisRequest parPais)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _ParPaisRepository.AddParPaisAsync(parPais);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // DELETE: api/ParPais/5
        [HttpDelete("DeleteParPais")]
        public async Task<string> DeleteParPai(ParPaisRequest parPais)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _ParPaisRepository.DeleteParPaisAsync(parPais);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        private bool ParPaiExists(int id)
        {
            return _context.ParPais.Any(e => e.CodigoPais == id);
        }
    }
}
