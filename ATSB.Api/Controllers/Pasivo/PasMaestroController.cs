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
using ATSB.Api.Areas.Repositories.Pasivo;
using ATSB.Api.Models.Pasivo;

namespace ATSB.Api.Controllers.Pasivo
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasMaestroController : ControllerBase
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IPasMaestroRepository _PasMaestroRepository;

        public PasMaestroController(ATSBIdentityDbContext context, IPasMaestroRepository PasMaestroRepository)
        {
            _context = context;
            _PasMaestroRepository = PasMaestroRepository;
        }

        // GET: api/PasMaestro
        [HttpGet("GetPasMaestros")]
        public async Task<string> GetPasMaestros()
        {
            var dataPasMaestros = _PasMaestroRepository.GetPasMaestros();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strMaestros = JsonConvert.SerializeObject(dataPasMaestros, options);

            return await Task.Run(() =>
            {
                return strMaestros;
            });
        }

        // GET: api/PasMaestro/5
        [HttpGet("GetPasMaestro/{CodigoEmpresa}/{NumeroCuenta}")]
        public async Task<string> GetPasMaestro(int CodigoEmpresa, string NumeroCuenta)
        {
            var pasMaestro = await _PasMaestroRepository.GetPasMaestroAsync(CodigoEmpresa, NumeroCuenta);

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strMaestro = JsonConvert.SerializeObject(pasMaestro, options);

            return await Task.Run(() =>
            {
                return strMaestro;
            });
        }

        // PUT: api/PasMaestro/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("PutPasMaestro")]
        public async Task<string> PutPasMaestro(PasMaestroRequest pasMaestro)
        {
            var response = new Response<object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _PasMaestroRepository.EditPasMaestroAsync(pasMaestro);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // POST: api/PasMaestro
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PostPasMaestro")]
        public async Task<string> PostPasMaestro(PasMaestroRequest pasMaestro)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _PasMaestroRepository.AddPasMaestroAsync(pasMaestro);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // DELETE: api/PasMaestro/5
        [HttpDelete("DeletePasMaestro")]
        public async Task<string> DeletePasMaestro(PasMaestroRequest pasMaestro)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _PasMaestroRepository.DeletePasMaestroAsync(pasMaestro);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        private bool PasMaestroExists(int id)
        {
            return _context.PasMaestros.Any(e => e.CodigoEmpresa == id);
        }
    }
}
