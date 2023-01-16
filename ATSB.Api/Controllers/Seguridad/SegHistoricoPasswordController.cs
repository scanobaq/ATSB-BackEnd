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
using ATSB.Api.Models.Seguridad;
using Microsoft.EntityFrameworkCore.Metadata;
using ATSB.Api.Areas.Repositories.Seguridad;
using ATSB.Api.Areas.Entities.Seguridad;

namespace ATSB.Api.Controllers.Seguridad
{
    [Route("api/[controller]")]
    [ApiController]
    public class SegHistoricoPasswordController : ControllerBase
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly ISegHistoricoPasswordRepository _SegHistoricoPasswordRepository;

        public SegHistoricoPasswordController(ATSBIdentityDbContext context, ISegHistoricoPasswordRepository SegHistoricoPasswordRepository)
        {
            _context = context;
            _SegHistoricoPasswordRepository = SegHistoricoPasswordRepository;
        }

        // GET: api/SegHistoricoPassword
        [HttpGet("GetSegHistoricosPassword")]
        public async Task<string> GetSegHistoricopasswords()
        {
            var dataSegHistoricos = _SegHistoricoPasswordRepository.GetSegHistoricosPassword();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strHistoricos = JsonConvert.SerializeObject(dataSegHistoricos, options);

            return await Task.Run(() =>
            {
                return strHistoricos;
            });
        }

        // GET: api/SegHistoricoPassword/5
        [HttpGet("GetSegHistoricoPassword/{CodigoEmpresa}/{IdUsuario}/{FechaHoraCambio}")]
        public async Task<string> GetSegHistoricopassword(int CodigoEmpresa, string IdUsuario, DateTime FechaHoraCambio)
        {
            var segHistorico = await _SegHistoricoPasswordRepository.GetSegHistoricoPasswordAsync(CodigoEmpresa, IdUsuario, FechaHoraCambio);

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strHistorico = JsonConvert.SerializeObject(segHistorico, options);

            return await Task.Run(() =>
            {
                return strHistorico;
            });
        }

        // POST: api/SegHistoricoPassword
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PostSegHistoricoPassword")]
        public async Task<string> PostSegHistoricopassword(SegHistoricoPasswordRequest segHistoricoPassword)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _SegHistoricoPasswordRepository.AddSegHistoricoPasswordAsync(segHistoricoPassword);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        private bool SegHistoricopasswordExists(int id)
        {
            return _context.SegHistoricopasswords.Any(e => e.CodigoEmpresa == id);
        }
    }
}
