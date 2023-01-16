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
    public class LiqIndiceController : ControllerBase
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly ILiqIndiceRepository _LiqIndiceRepository;

        public LiqIndiceController(ATSBIdentityDbContext context, ILiqIndiceRepository LiqIndiceRepository)
        {
            _context = context;
            _LiqIndiceRepository = LiqIndiceRepository;
        }

        // GET: api/LiqIndice
        [HttpGet("GetLiqIndices")]
        public async Task<string> GetLiqIndice()
        {
            var dataLiqIndices = _LiqIndiceRepository.GetLiqIndices();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strIndices = JsonConvert.SerializeObject(dataLiqIndices, options);

            return await Task.Run(() =>
            {
                return strIndices;
            });
        }

        // GET: api/LiqIndice/5
        [HttpGet("GetLiqIndice/{CodigoEmpresa}/{Tipo}/{Rubro}")]
        public async Task<string> GetLiqIndie(int CodigoEmpresa, string Tipo, int Rubro)
        {
            var liqIndice = await _LiqIndiceRepository.GetLiqIndiceAsync(CodigoEmpresa, Tipo, Rubro);

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strIndice = JsonConvert.SerializeObject(liqIndice, options);

            return await Task.Run(() =>
            {
                return strIndice;
            });
        }

        // PUT: api/LiqIndice/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("PutLiqIndice")]
        public async Task<string> PutLiqIndie(LiqIndiceRequest liqIndice)
        {
            var response = new Response<object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _LiqIndiceRepository.EditLiqIndiceAsync(liqIndice);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // POST: api/LiqIndice
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PostLiqIndice")]
        public async Task<string> PostLiqIndie(LiqIndiceRequest liqIndice)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _LiqIndiceRepository.AddLiqIndiceAsync(liqIndice);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // DELETE: api/LiqIndice/5
        [HttpDelete("DeleteLiqIndice")]
        public async Task<string> DeleteLiqIndie(LiqIndiceRequest liqIndice)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _LiqIndiceRepository.DeleteLiqIndiceAsync(liqIndice);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        private bool LiqIndieExists(int id)
        {
            return _context.LiqIndice.Any(e => e.CodigoEmpresa == id);
        }
    }
}
