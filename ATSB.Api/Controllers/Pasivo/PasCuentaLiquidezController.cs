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
    public class PasCuentaLiquidezController : ControllerBase
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IPasCuentaLiquidezRepository _PasCuentaLiquidezRepository;

        public PasCuentaLiquidezController(ATSBIdentityDbContext context, IPasCuentaLiquidezRepository PasCuentaLiquidezRepository)
        {
            _context = context;
            _PasCuentaLiquidezRepository = PasCuentaLiquidezRepository;
        }

        // GET: api/PasCuentaLiquidez
        [HttpGet("GetPasCuentasLiquidez")]
        public async Task<string> GetPasCuentaliquidezs()
        {
            var dataPasCuentas = _PasCuentaLiquidezRepository.GetPasCuentasLiquidez();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strCuentas = JsonConvert.SerializeObject(dataPasCuentas, options);

            return await Task.Run(() =>
            {
                return strCuentas;
            });
        }

        // GET: api/PasCuentaLiquidez/5
        [HttpGet("GetPasCuentaLiquidez/{CodigoEmpresa}/{TipoDeposito}/{TipoCliente}/{CodigoCuentaLiquidez}/{DestinoLocalExtranjero}")]
        public async Task<string> GetPasCuentaliquidez(int CodigoEmpresa, int TipoDeposito, int TipoCliente, int CodigoCuentaLiquidez, string DestinoLocalExtranjero)
        {
            var pasCuenta = await _PasCuentaLiquidezRepository.GetPasCuentaLiquidezAsync(CodigoEmpresa, TipoDeposito, TipoCliente, CodigoCuentaLiquidez, DestinoLocalExtranjero);

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strCuenta = JsonConvert.SerializeObject(pasCuenta, options);

            return await Task.Run(() =>
            {
                return strCuenta;
            });
        }

        // PUT: api/PasCuentaLiquidez/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("PutPasCuentaLiquidez")]
        public async Task<string> PutPasCuentaliquidez(PasCuentaLiquidezRequest pasCuentaLiquidez)
        {
            var response = new Response<object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _PasCuentaLiquidezRepository.EditPasCuentaLiquidezAsync(pasCuentaLiquidez);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // POST: api/PasCuentaLiquidez
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PostPasCuentaLiquidez")]
        public async Task<string> PostPasCuentaliquidez(PasCuentaLiquidezRequest pasCuentaLiquidez)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _PasCuentaLiquidezRepository.AddPasCuentaLiquidezAsync(pasCuentaLiquidez);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // DELETE: api/PasCuentaLiquidez/5
        [HttpDelete("DeletePasCuentaLiquidez")]
        public async Task<string> DeletePasCuentaliquidez(PasCuentaLiquidezRequest pasCuentaLiquidez)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _PasCuentaLiquidezRepository.DeletePasCuentaLiquidezAsync(pasCuentaLiquidez);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        private bool PasCuentaliquidezExists(int id)
        {
            return _context.PasCuentaliquidezs.Any(e => e.CodigoEmpresa == id);
        }
    }
}
