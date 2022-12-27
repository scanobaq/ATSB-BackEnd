using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ATSB.Api.Areas.Entities.Parametros;
using ATSB.Api.Areas.Identity.Data;
using System.Text.Json;
using Newtonsoft.Json;
using ATSB.Api.Areas.Repositories.Parametros;
using ATSB.Models;
using ATSB.Api.Models.Parametros;

namespace ATSB.Api.Controllers.Parametros
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParTipoIdentificacionController : ControllerBase
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IParTipoIdentificacionRepository _ParTipoIdentificacionRepository;

        public ParTipoIdentificacionController(ATSBIdentityDbContext context, IParTipoIdentificacionRepository ParTipoIdentificacionRepository)
        {
            _context = context;
            _ParTipoIdentificacionRepository = ParTipoIdentificacionRepository;
        }

        // GET: api/ParTipoIdentificacion
        [HttpGet("GetParTipoIdentificaciones")]
        public async Task<string> GetParTipoidentificacions()
        {
            var dataParTipoIdentificaciones = _ParTipoIdentificacionRepository.GetParTipoIdentificaciones();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strTipoIdentificaciones = JsonConvert.SerializeObject(dataParTipoIdentificaciones, options);

            return await Task.Run(() =>
            {
                return strTipoIdentificaciones;
            });
        }

        // GET: api/ParTipoIdentificacion/5
        [HttpGet("GetParTipoIdentificacion/{CodigoPais}/{CodigoTipoIdentificacion}")]
        public async Task<string> GetParTipoidentificacion(int CodigoPais, int CodigoTipoIdentificacion)
        {
            var parTipoIdentificacion = await _ParTipoIdentificacionRepository.GetParTipoIdentificacionAsync(CodigoPais, CodigoTipoIdentificacion);

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strTipoIdentificacion = JsonConvert.SerializeObject(parTipoIdentificacion, options);

            return await Task.Run(() =>
            {
                return strTipoIdentificacion;
            });
        }

        // PUT: api/ParTipoIdentificacion/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("PutParTipoIdentificacion")]
        public async Task<string> PutParTipoidentificacion(ParTipoIdentificacionRequest parTipoidentificacion)
        {
            var response = new Response<object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _ParTipoIdentificacionRepository.EditParTipoIdentificacionAsync(parTipoidentificacion);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // POST: api/ParTipoIdentificacion
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PostParTipoIdentificacion")]
        public async Task<string> PostParTipoidentificacion(ParTipoIdentificacionRequest parTipoidentificacion)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _ParTipoIdentificacionRepository.AddParTipoIdentificacionAsync(parTipoidentificacion);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // DELETE: api/ParTipoIdentificacion/5
        [HttpDelete("DeleteParTipoIdentificacion")]
        public async Task<string> DeleteParTipoidentificacion(ParTipoIdentificacionRequest parTipoidentificacion)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _ParTipoIdentificacionRepository.DeleteParTipoIdentificacionAsync(parTipoidentificacion);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        private bool ParTipoidentificacionExists(int id)
        {
            return _context.ParTipoidentificacions.Any(e => e.CodigoTipoIdentificacion == id);
        }
    }
}
