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
    public class ParTipoCambioController : ControllerBase
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IParTipoCambioRepository _ParTipoCambioRepository;

        public ParTipoCambioController(ATSBIdentityDbContext context, IParTipoCambioRepository ParTipoCambioRepository)
        {
            _context = context;
            _ParTipoCambioRepository = ParTipoCambioRepository;
        }

        // GET: api/ParTipoCambio
        [HttpGet("GetParTiposCambio")]
        public async Task<string> GetParTipocambios()
        {
            var dataParTiposCambio = _ParTipoCambioRepository.GetParTiposCambio();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strTiposCambio = JsonConvert.SerializeObject(dataParTiposCambio, options);

            return await Task.Run(() =>
            {
                return strTiposCambio;
            });
        }

        // GET: api/ParTipoCambio/5
        [HttpGet("GetParTipoCambio/{CodigoEmpresa}/{Fecha}/{CodigoMoneda}")]
        public async Task<string> GetParTipocambio(int CodigoEmpresa, DateTime Fecha, int CodigoMoneda)
        {
            var parEmpresa = await _ParTipoCambioRepository.GetParTipoCambioAsync(CodigoEmpresa, Fecha, CodigoMoneda);

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

        // PUT: api/ParTipoCambio/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("PutParTipoCambio")]
        public async Task<string> PutParTipocambio(ParTipoCambioRequest parTipocambio)
        {
            var response = new Response<object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _ParTipoCambioRepository.EditParTipoCambioAsync(parTipocambio);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // POST: api/ParTipoCambio
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PostParTipoCambio")]
        public async Task<string> PostParTipocambio(ParTipoCambioRequest parTipocambio)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _ParTipoCambioRepository.AddParTipoCambioAsync(parTipocambio);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // DELETE: api/ParTipoCambio/5
        [HttpDelete("DeleteParTipoCambio")]
        public async Task<string> DeleteParTipocambio(ParTipoCambioRequest parTipocambio)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _ParTipoCambioRepository.DeleteParTipoCambioAsync(parTipocambio);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        private bool ParTipocambioExists(int id)
        {
            return _context.ParTipocambios.Any(e => e.CodigoEmpresa == id);
        }
    }
}
