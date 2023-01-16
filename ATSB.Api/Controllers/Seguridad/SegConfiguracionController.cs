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
    public class SegConfiguracionController : ControllerBase
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly ISegConfiguracionRepository _SegConfiguracionRepository;

        public SegConfiguracionController(ATSBIdentityDbContext context, ISegConfiguracionRepository SegConfiguracionRepository)
        {
            _context = context;
            _SegConfiguracionRepository = SegConfiguracionRepository;
        }

        // GET: api/SegConfiguracion
        [HttpGet("GetSegConfiguraciones")]
        public async Task<string> GetSegConfiguracions()
        {
            var dataSegConfiguraciones = _SegConfiguracionRepository.GetSegConfiguraciones();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strConfiguraciones = JsonConvert.SerializeObject(dataSegConfiguraciones, options);

            return await Task.Run(() =>
            {
                return strConfiguraciones;
            });
        }

        // GET: api/SegConfiguracion/5
        [HttpGet("GetSegConfiguracion/{CodigoEmpresa}/{IdParametro}")]
        public async Task<string> GetSegConfiguracion(int CodigoEmpresa, int IdParametro)
        {
            var segConfiguracion = await _SegConfiguracionRepository.GetSegConfiguracionAsync(CodigoEmpresa, IdParametro);

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strConfiguracion = JsonConvert.SerializeObject(segConfiguracion, options);

            return await Task.Run(() =>
            {
                return strConfiguracion;
            });
        }

        // POST: api/SegConfiguracion
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PostSegConfiguracion")]
        public async Task<string> PostSegConfiguracion(SegConfiguracionRequest segConfiguracion)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _SegConfiguracionRepository.AddSegConfiguracionAsync(segConfiguracion);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        private bool SegConfiguracionExists(int id)
        {
            return _context.SegConfiguracions.Any(e => e.CodigoEmpresa == id);
        }
    }
}
