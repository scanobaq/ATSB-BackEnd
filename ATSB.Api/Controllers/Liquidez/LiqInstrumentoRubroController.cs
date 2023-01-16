using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ATSB.Api.Areas.Entities.Liquidez;
using ATSB.Api.Areas.Identity.Data;
using System.Text.Json;
using Newtonsoft.Json;
using ATSB.Api.Areas.Repositories.Liquidez;
using ATSB.Models;
using ATSB.Api.Models.Liquidez;
using Microsoft.EntityFrameworkCore.Metadata;
using ATSB.Api.Areas.Entities.Credito;

namespace ATSB.Api.Controllers.Liquidez
{
    [Route("api/[controller]")]
    [ApiController]
    public class LiqInstrumentoRubroController : ControllerBase
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly ILiqInstrumentoRubroRepository _LiqInstrumentoRubroRepository;

        public LiqInstrumentoRubroController(ATSBIdentityDbContext context, ILiqInstrumentoRubroRepository LiqInstrumentoRubroRepository)
        {
            _context = context;
            _LiqInstrumentoRubroRepository = LiqInstrumentoRubroRepository;
        }

        // GET: api/LiqInstrumentoRubro
        [HttpGet("GetLiqInstrumentosRubros")]
        public async Task<string> GetLiqInstrumentorubros()
        {
            var dataLiqInstrumentosRubros = _LiqInstrumentoRubroRepository.GetLiqInstrumentosRubros();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strInstrumentosRubros = JsonConvert.SerializeObject(dataLiqInstrumentosRubros, options);

            return await Task.Run(() =>
            {
                return strInstrumentosRubros;
            });
        }

        // GET: api/LiqInstrumentoRubro/5
        [HttpGet("GetLiqInstrumentoRubro/{CodigoEmpresa}/{Instrumento}/{CodigoRegion}/{CodigoRubro}")]
        public async Task<string> GetLiqInstrumentorubro(int CodigoEmpresa, string Instrumento, string CodigoRegion, int CodigoRubro)
        {
            var liqInstrumentoRubro = await _LiqInstrumentoRubroRepository.GetLiqInstrumentoRubroAsync(CodigoEmpresa, Instrumento, CodigoRegion, CodigoRubro);

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strInstrumentoRubro = JsonConvert.SerializeObject(liqInstrumentoRubro, options);

            return await Task.Run(() =>
            {
                return strInstrumentoRubro;
            });
        }

        // PUT: api/LiqInstrumentoRubro/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("PutLiqInstrumentoRubro")]
        public async Task<string> PutLiqInstrumentorubro(LiqInstrumentoRubroRequest liqInstrumentoRubro)
        {
            var response = new Response<object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _LiqInstrumentoRubroRepository.EditLiqInstrumentoRubroAsync(liqInstrumentoRubro);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // POST: api/LiqInstrumentoRubro
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PostLiqInstrumentoRubro")]
        public async Task<string> PostLiqInstrumentorubro(LiqInstrumentoRubroRequest liqInstrumentoRubro)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _LiqInstrumentoRubroRepository.AddLiqInstrumentoRubroAsync(liqInstrumentoRubro);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // DELETE: api/LiqInstrumentoRubro/5
        [HttpDelete("DeleteLiqInstrumentoRubro")]
        public async Task<string> DeleteLiqInstrumentorubro(LiqInstrumentoRubroRequest liqInstrumentoRubro)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _LiqInstrumentoRubroRepository.DeleteLiqInstrumentoRubroAsync(liqInstrumentoRubro);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        private bool LiqInstrumentorubroExists(int id)
        {
            return _context.LiqInstrumentorubros.Any(e => e.CodigoEmpresa == id);
        }
    }
}
