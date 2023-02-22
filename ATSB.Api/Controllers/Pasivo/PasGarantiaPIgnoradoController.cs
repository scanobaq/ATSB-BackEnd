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
using ATSB.Api.Areas.Entities.Pasivo;

namespace ATSB.Api.Controllers.Pasivo
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasGarantiaPIgnoradoController : ControllerBase
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IPasGarantiaPIgnoradoRepository _PasGarantiaPIgnoradoRepository;

        public PasGarantiaPIgnoradoController(ATSBIdentityDbContext context, IPasGarantiaPIgnoradoRepository PasGarantiaPIgnoradoRepository)
        {
            _context = context;
            _PasGarantiaPIgnoradoRepository = PasGarantiaPIgnoradoRepository;
        }

        // GET: api/PasGarantiaPIgnorado
        [HttpGet("GetPasGarantiasPIgnorado")]
        public async Task<string> GetPasGarantiapignorados()
        {
            var dataPasGarantias = _PasGarantiaPIgnoradoRepository.GetPasGarantiasPIgnorado();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strGarantias = JsonConvert.SerializeObject(dataPasGarantias, options);

            return await Task.Run(() =>
            {
                return strGarantias;
            });
        }

        // GET: api/PasGarantiaPIgnorado/5
        [HttpGet("GetPasGarantiaPIgnorado/{CodigoEmpresa}/{NumeroCuenta}/{NumeroOperacionGarantia}")]
        public async Task<string> GetPasGarantiapignorado(int CodigoEmpresa, string NumeroCuenta, string NumeroOperacionGarantia)
        {
            var pasGarantia = await _PasGarantiaPIgnoradoRepository.GetPasGarantiaPIgnoradoAsync(CodigoEmpresa, NumeroCuenta, NumeroOperacionGarantia);

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strGarantia = JsonConvert.SerializeObject(pasGarantia, options);

            return await Task.Run(() =>
            {
                return strGarantia;
            });
        }

        // PUT: api/PasGarantiaPIgnorado/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("PutPasGarantiaPIgnorado")]
        public async Task<string> PutPasGarantiapignorado(PasGarantiaPIgnoradoRequest pasGarantiaPIgnorado)
        {
            var response = new Response<object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _PasGarantiaPIgnoradoRepository.EditPasGarantiaPIgnoradoAsync(pasGarantiaPIgnorado);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // POST: api/PasGarantiaPIgnorado
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PostPasGarantiaPIgnorado")]
        public async Task<string> PostPasGarantiapignorado(PasGarantiaPIgnoradoRequest pasGarantiaPIgnorado)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _PasGarantiaPIgnoradoRepository.AddPasGarantiaPIgnoradoAsync(pasGarantiaPIgnorado);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // DELETE: api/PasGarantiaPIgnorado/5
        [HttpDelete("DeletePasGarantiaPIgnorado")]
        public async Task<string> DeletePasGarantiapignorado(PasGarantiaPIgnoradoRequest pasGarantiaPIgnorado)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _PasGarantiaPIgnoradoRepository.DeletePasGarantiaPIgnoradoAsync(pasGarantiaPIgnorado);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        private bool PasGarantiapignoradoExists(int id)
        {
            return _context.PasGarantiapignorados.Any(e => e.CodigoEmpresa == id);
        }
    }
}
