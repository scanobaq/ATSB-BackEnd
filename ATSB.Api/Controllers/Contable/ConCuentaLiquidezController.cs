using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ATSB.Api.Areas.Entities.Contable;
using ATSB.Api.Areas.Identity.Data;
using System.Text.Json;
using Newtonsoft.Json;
using ATSB.Api.Areas.Repositories.Contable;
using ATSB.Models;
using ATSB.Api.Models.Contable;
using Microsoft.EntityFrameworkCore.Metadata;
using ATSB.Api.Areas.Entities.Configuracion;

namespace ATSB.Api.Controllers.Contable
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConCuentaLiquidezController : ControllerBase
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IConCuentaLiquidezRepository _ConCuentaLiquidezRepository;

        public ConCuentaLiquidezController(ATSBIdentityDbContext context, IConCuentaLiquidezRepository ConCuentaLiquidezRepository)
        {
            _context = context;
            _ConCuentaLiquidezRepository = ConCuentaLiquidezRepository;
        }

        // GET: api/ConCuentaLiquidez
        [HttpGet("GetConCuentasLiquidez")]
        public async Task<string> GetConCuentaliquidezs()
        {
            var dataConCuentasLiquidez = _ConCuentaLiquidezRepository.GetConCuentasLiquidez();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strCuentaLiquidez = JsonConvert.SerializeObject(dataConCuentasLiquidez, options);

            return await Task.Run(() =>
            {
                return strCuentaLiquidez;
            });
        }

        // GET: api/ConCuentaLiquidez/5
        [HttpGet("GetConCuentaLiquidez/{CodigoEmpresa}/{CuentaLiquidez}/{CuentaContableLocal}")]
        public async Task<string> GetConCuentaliquidez(int CodigoEmpresa, int CuentaLiquidez, int CuentaContableLocal)
        {
            var conCuentaLiquidez = await _ConCuentaLiquidezRepository.GetConCuentaLiquidezAsync(CodigoEmpresa, CuentaLiquidez, CuentaContableLocal);

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strCuentaLiquidez = JsonConvert.SerializeObject(conCuentaLiquidez, options);

            return await Task.Run(() =>
            {
                return strCuentaLiquidez;
            });
        }

        // PUT: api/ConCuentaLiquidez/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("PutConCuentaLiquidez")]
        public async Task<string> PutConCuentaliquidez(ConCuentaLiquidezRequest conCuentaLiquidez)
        {
            var response = new Response<object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _ConCuentaLiquidezRepository.EditConCuentaLiquidezAsync(conCuentaLiquidez);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // POST: api/ConCuentaLiquidez
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PostConCuentaLiquidez")]
        public async Task<string> PostConCuentaliquidez(ConCuentaLiquidezRequest conCuentaLiquidez)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _ConCuentaLiquidezRepository.AddConCuentaLiquidezAsync(conCuentaLiquidez);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // DELETE: api/ConCuentaLiquidez/5
        [HttpDelete("DeleteConCuentaLiquidez")]
        public async Task<string> DeleteConCuentaliquidez(ConCuentaLiquidezRequest conCuentaLiquidez)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _ConCuentaLiquidezRepository.DeleteConCuentaLiquidezAsync(conCuentaLiquidez);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        private bool ConCuentaliquidezExists(int id)
        {
            return _context.ConCuentaliquidezs.Any(e => e.CodigoEmpresa == id);
        }
    }
}
