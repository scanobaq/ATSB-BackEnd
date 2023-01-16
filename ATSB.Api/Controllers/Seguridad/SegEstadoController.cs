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
    public class SegEstadoController : ControllerBase
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly ISegEstadoRepository _SegEstadoRepository;

        public SegEstadoController(ATSBIdentityDbContext context, ISegEstadoRepository SegEstadoRepository)
        {
            _context = context;
            _SegEstadoRepository = SegEstadoRepository;
        }

        // GET: api/SegEstado
        [HttpGet("GetSegEstados")]
        public async Task<string> GetSegEstados()
        {
            var dataSegEstados = _SegEstadoRepository.GetSegEstados();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strEstados = JsonConvert.SerializeObject(dataSegEstados, options);

            return await Task.Run(() =>
            {
                return strEstados;
            });
        }

        // GET: api/SegEstado/5
        [HttpGet("GetSegEstado/{CodigoEmpresa}/{CodigoEstado}")]
        public async Task<string> GetSegEstado(int CodigoEmpresa, string CodigoEstado)
        {
            var segEstado = await _SegEstadoRepository.GetSegEstadoAsync(CodigoEmpresa, CodigoEstado);

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strEstado = JsonConvert.SerializeObject(segEstado, options);

            return await Task.Run(() =>
            {
                return strEstado;
            });
        }

        // PUT: api/SegEstado/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("PutSegEstado")]
        public async Task<string> PutSegEstado(SegEstadoRequest segEstado)
        {
            var response = new Response<object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _SegEstadoRepository.EditSegEstadoAsync(segEstado);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // POST: api/SegEstado
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PostSegEstado")]
        public async Task<string> PostSegEstado(SegEstadoRequest segEstado)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _SegEstadoRepository.AddSegEstadoAsync(segEstado);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // DELETE: api/SegEstado/5
        [HttpDelete("DeleteSegEstado")]
        public async Task<string> DeleteSegEstado(SegEstadoRequest segEstado)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _SegEstadoRepository.DeleteSegEstadoAsync(segEstado);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        private bool SegEstadoExists(int id)
        {
            return _context.SegEstados.Any(e => e.CodigoEmpresa == id);
        }
    }
}
