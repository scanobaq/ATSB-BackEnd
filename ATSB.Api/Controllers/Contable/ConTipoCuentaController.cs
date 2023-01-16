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
    public class ConTipoCuentaController : ControllerBase
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IConTipoCuentaRepository _ConTipoCuentaRepository;

        public ConTipoCuentaController(ATSBIdentityDbContext context, IConTipoCuentaRepository ConTipoCuentaRepository)
        {
            _context = context;
            _ConTipoCuentaRepository = ConTipoCuentaRepository;
        }

        // GET: api/ConTipoCuenta
        [HttpGet("GetConTiposCuenta")]
        public async Task<string> GetConTipocuenta()
        {
            var dataConTiposCuenta = _ConTipoCuentaRepository.GetConTiposCuenta();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            
            string strTiposCuenta = JsonConvert.SerializeObject(dataConTiposCuenta, options);

            return await Task.Run(() =>
            {
                return strTiposCuenta;
            });
        }

        // GET: api/ConTipoCuenta/5
        [HttpGet("GetConTipoCuenta/{CodigoEmpresa}/{CodigoTipo}")]
        public async Task<string> GetConTipocuentum(int CodigoEmpresa, int CodigoTipo)
        {
            var conTipoCuenta = await _ConTipoCuentaRepository.GetConTipoCuentaAsync(CodigoEmpresa, CodigoTipo);

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strTipoCuenta = JsonConvert.SerializeObject(conTipoCuenta, options);

            return await Task.Run(() =>
            {
                return strTipoCuenta;
            });
        }

        // PUT: api/ConTipoCuenta/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("PutConTipoCuenta")]
        public async Task<string> PutConTipocuentum(ConTipoCuentaRequest conTipoCuenta)
        {
            var response = new Response<object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _ConTipoCuentaRepository.EditConTipoCuentaAsync(conTipoCuenta);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // POST: api/ConTipoCuenta
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PostConTipoCuenta")]
        public async Task<string> PostConTipocuentum(ConTipoCuentaRequest conTipoCuenta)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _ConTipoCuentaRepository.AddConTipoCuentaAsync(conTipoCuenta);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // DELETE: api/ConTipoCuenta/5
        [HttpDelete("DeleteConTipoCuenta")]
        public async Task<string> DeleteConTipocuentum(ConTipoCuentaRequest conTipoCuenta)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _ConTipoCuentaRepository.DeleteConTipoCuentaAsync(conTipoCuenta);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        private bool ConTipocuentumExists(int id)
        {
            return _context.ConTipocuenta.Any(e => e.CodigoEmpresa == id);
        }
    }
}
