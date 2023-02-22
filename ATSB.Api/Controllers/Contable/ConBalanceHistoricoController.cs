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
    public class ConBalanceHistoricoController : ControllerBase
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IConBalanceHistoricoRepository _ConBalanceHistoricoRepository;

        public ConBalanceHistoricoController(ATSBIdentityDbContext context, IConBalanceHistoricoRepository ConBalanceHistoricoRepository)
        {
            _context = context;
            _ConBalanceHistoricoRepository = ConBalanceHistoricoRepository;
        }

        // GET: api/ConBalanceHistorico
        [HttpGet("GetConBalancesHistorico")]
        public async Task<string> GetConBalancehistoricos()
        {
            var dataConBalancesHistorico = _ConBalanceHistoricoRepository.GetConBalancesHistorico();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strBalancesHistorico = JsonConvert.SerializeObject(dataConBalancesHistorico, options);

            return await Task.Run(() =>
            {
                return strBalancesHistorico;
            });
        }

        // GET: api/ConBalanceHistorico/5
        [HttpGet("GetConBalanceHistorico/{CodigoEmpresa}/{Fecha}/{CodigoCuentaContable}")]
        public async Task<string> GetConBalancehistorico(int CodigoEmpresa, DateTime Fecha, int CodigoCuentaContable)
        {
            var conBalanceHistorico = await _ConBalanceHistoricoRepository.GetConBalanceHistoricoAsync(CodigoEmpresa, Fecha, CodigoCuentaContable);

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strBalanceHistorico = JsonConvert.SerializeObject(conBalanceHistorico, options);

            return await Task.Run(() =>
            {
                return strBalanceHistorico;
            });
        }

        // PUT: api/ConBalanceHistorico/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("PutConBalanceHistorico")]
        public async Task<string> PutConBalancehistorico(ConBalanceHistoricoRequest conBalanceHistorico)
        {
            var response = new Response<object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _ConBalanceHistoricoRepository.EditConBalanceHistoricoAsync(conBalanceHistorico);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // POST: api/ConBalanceHistorico
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PostConBalanceHistorico")]
        public async Task<string> PostConBalancehistorico(ConBalanceHistoricoRequest conBalanceHistorico)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _ConBalanceHistoricoRepository.AddConBalanceHistoricoAsync(conBalanceHistorico);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // DELETE: api/ConBalanceHistorico/5
        [HttpDelete("DeleteConBalanceHistorico")]
        public async Task<string> DeleteConBalancehistorico(ConBalanceHistoricoRequest conBalanceHistorico)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _ConBalanceHistoricoRepository.DeleteConBalanceHistoricoAsync(conBalanceHistorico);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        private bool ConBalancehistoricoExists(int id)
        {
            return _context.ConBalancehistoricos.Any(e => e.CodigoEmpresa == id);
        }
    }
}
