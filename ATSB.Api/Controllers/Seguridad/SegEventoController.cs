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
    public class SegEventoController : ControllerBase
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly ISegEventoRepository _SegEventoRepository;

        public SegEventoController(ATSBIdentityDbContext context, ISegEventoRepository SegEventoRepository)
        {
            _context = context;
            _SegEventoRepository = SegEventoRepository;
        }

        // GET: api/SegEvento
        [HttpGet("GetSegEventos")]
        public async Task<string> GetSegEventos()
        {
            var dataSegEventos = _SegEventoRepository.GetSegEventos();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strEventos = JsonConvert.SerializeObject(dataSegEventos, options);

            return await Task.Run(() =>
            {
                return strEventos;
            });
        }

        // GET: api/SegEvento/5
        [HttpGet("GetSegEvento/{CodigoEmpresa}/{IdEvento}")]
        public async Task<string> GetSegEvento(int CodigoEmpresa, int IdEvento)
        {
            var segEvento = await _SegEventoRepository.GetSegEventoAsync(CodigoEmpresa, IdEvento);

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strEvento = JsonConvert.SerializeObject(segEvento, options);

            return await Task.Run(() =>
            {
                return strEvento;
            });
        }

        // PUT: api/SegEvento/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("PutSegEvento")]
        public async Task<string> PutSegEvento(SegEventoRequest segEvento)
        {
            var response = new Response<object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _SegEventoRepository.EditSegEventoAsync(segEvento);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // POST: api/SegEvento
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PostSegEvento")]
        public async Task<string> PostSegEvento(SegEventoRequest segEvento)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _SegEventoRepository.AddSegEventoAsync(segEvento);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // DELETE: api/SegEvento/5
        [HttpDelete("DeleteSegEvento")]
        public async Task<string> DeleteSegEvento(SegEventoRequest segEvento)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _SegEventoRepository.DeleteSegEventoAsync(segEvento);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        private bool SegEventoExists(int id)
        {
            return _context.SegEventos.Any(e => e.CodigoEmpresa == id);
        }
    }
}
