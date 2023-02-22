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
    public class PasDetalleHistoricoController : ControllerBase
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IPasDetalleHistoricoRepository _PasDetalleHistoricoRepository;

        public PasDetalleHistoricoController(ATSBIdentityDbContext context, IPasDetalleHistoricoRepository PasDetalleHistoricoRepository)
        {
            _context = context;
            _PasDetalleHistoricoRepository = PasDetalleHistoricoRepository;
        }

        // GET: api/PasDetalleHistorico
        [HttpGet("GetPasDetallesHistoricos")]
        public async Task<string> GetPasDetallehistoricos()
        {
            var dataPasDetallesHistoricos = _PasDetalleHistoricoRepository.GetPasDetallesHistoricos();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strDetallesHistoricos = JsonConvert.SerializeObject(dataPasDetallesHistoricos, options);

            return await Task.Run(() =>
            {
                return strDetallesHistoricos;
            });
        }

        // GET: api/PasDetalleHistorico/5
        [HttpGet("GetPasDetalleHistorico/{CodigoEmpresa}/{NumeroOperacion}/{Fecha}")]
        public async Task<string> GetPasDetallehistorico(int CodigoEmpresa, string NumeroOperacion, string Fecha)
        {
            var pasDetalleHistorico = await _PasDetalleHistoricoRepository.GetPasDetalleHistoricoAsync(CodigoEmpresa, NumeroOperacion, Fecha);

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strDetalleHistorico = JsonConvert.SerializeObject(pasDetalleHistorico, options);

            return await Task.Run(() =>
            {
                return strDetalleHistorico;
            });
        }

        // PUT: api/PasDetalleHistorico/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("PutPasDetalleHistorico")]
        public async Task<string> PutPasDetallehistorico(PasDetalleHistoricoRequest pasDetalleHistorico)
        {
            var response = new Response<object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _PasDetalleHistoricoRepository.EditPasDetalleHistoricoAsync(pasDetalleHistorico);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // POST: api/PasDetalleHistorico
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PostPasDetalleHistorico")]
        public async Task<string> PostPasDetallehistorico(PasDetalleHistoricoRequest pasDetalleHistorico)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _PasDetalleHistoricoRepository.AddPasDetalleHistoricoAsync(pasDetalleHistorico);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // DELETE: api/PasDetalleHistorico/5
        [HttpDelete("DeletePasDetalleHistorico")]
        public async Task<string> DeletePasDetallehistorico(PasDetalleHistoricoRequest pasDetalleHistorico)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _PasDetalleHistoricoRepository.DeletePasDetalleHistoricoAsync(pasDetalleHistorico);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        private bool PasDetallehistoricoExists(int id)
        {
            return _context.PasDetallehistoricos.Any(e => e.CodigoEmpresa == id);
        }
    }
}
