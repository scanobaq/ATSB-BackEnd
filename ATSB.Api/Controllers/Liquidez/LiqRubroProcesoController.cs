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
    public class LiqRubroProcesoController : ControllerBase
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly ILiqRubroProcesoRepository _LiqRubroProcesoRepository;

        public LiqRubroProcesoController(ATSBIdentityDbContext context, ILiqRubroProcesoRepository LiqRubroProcesoRepository)
        {
            _context = context;
            _LiqRubroProcesoRepository = LiqRubroProcesoRepository;
        }

        // GET: api/LiqRubroProceso
        [HttpGet("GetLiqRubroProcesos")]
        public async Task<string> GetLiqRubroprocesos()
        {
            var dataLisRubroProcesos = _LiqRubroProcesoRepository.GetLiqRubroProcesos();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strRubroProcesos = JsonConvert.SerializeObject(dataLisRubroProcesos, options);

            return await Task.Run(() =>
            {
                return strRubroProcesos;
            });
        }

        // GET: api/LiqRubroProceso/5
        [HttpGet("GetLiqRubroProceso/{CodigoEmpresa}/{Rubro}")]
        public async Task<string> GetLiqRubroproceso(int CodigoEmpresa, int Rubro)
        {
            var liqRubroProceso = await _LiqRubroProcesoRepository.GetLiqRubroProcesoAsync(CodigoEmpresa, Rubro);

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strRubroProceso = JsonConvert.SerializeObject(liqRubroProceso, options);

            return await Task.Run(() =>
            {
                return strRubroProceso;
            });
        }

        // PUT: api/LiqRubroProceso/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("PutLiqRubroProceso")]
        public async Task<string> PutLiqRubroproceso(LiqRubroProcesoRequest liqRubroProceso)
        {
            var response = new Response<object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _LiqRubroProcesoRepository.EditLiqRubroProcesoAsync(liqRubroProceso);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // POST: api/LiqRubroProceso
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PostLiqRubroProceso")]
        public async Task<string> PostLiqRubroproceso(LiqRubroProcesoRequest liqRubroProceso)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _LiqRubroProcesoRepository.AddLiqRubroProcesoAsync(liqRubroProceso);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // DELETE: api/LiqRubroProceso/5
        [HttpDelete("DeleteLiqRubroProceso")]
        public async Task<string> DeleteLiqRubroproceso(LiqRubroProcesoRequest liqRubroProceso)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _LiqRubroProcesoRepository.DeleteLiqRubroProcesoAsync(liqRubroProceso);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        private bool LiqRubroprocesoExists(int id)
        {
            return _context.LiqRubroprocesos.Any(e => e.CodigoEmpresa == id);
        }
    }
}
