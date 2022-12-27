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
    public class ParTipoOrigenDatosController : ControllerBase
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IParTipoOrigenDatosRepository _ParTipoOrigenDatosRepository;

        public ParTipoOrigenDatosController(ATSBIdentityDbContext context, IParTipoOrigenDatosRepository ParTipoOrigenDatosRepository)
        {
            _context = context;
            _ParTipoOrigenDatosRepository = ParTipoOrigenDatosRepository;
        }

        // GET: api/ParTipoOrigenDatos
        [HttpGet("GetParTiposOrigenDatos")]
        public async Task<string> GetParTipoorigendatos()
        {
            var dataParTiposOrigenDatos = _ParTipoOrigenDatosRepository.GetParTiposOrigenDatos();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strTiposOrigenDatos = JsonConvert.SerializeObject(dataParTiposOrigenDatos, options);

            return await Task.Run(() =>
            {
                return strTiposOrigenDatos;
            });
        }

        // GET: api/ParTipoOrigenDatos/5
        [HttpGet("GetParTipoOrigenDatos/{CodigoEmpresa}/{CodigoOrigenDatos}")]
        public async Task<string> GetParTipoorigendato(int CodigoEmpresa, int CodigoOrigenDatos)
        {
            var parTipoOrigenDatos = await _ParTipoOrigenDatosRepository.GetParTipoOrigenDatosAsync(CodigoEmpresa, CodigoOrigenDatos);

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strTipoOrigenDatos = JsonConvert.SerializeObject(parTipoOrigenDatos, options);

            return await Task.Run(() =>
            {
                return strTipoOrigenDatos;
            });
        }

        // PUT: api/ParTipoOrigenDatos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("PutParTipoOrigenDatos")]
        public async Task<string> PutParTipoorigendato(ParTipoOrigenDatosRequest parTipoorigendato)
        {
            var response = new Response<object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _ParTipoOrigenDatosRepository.EditParTipoOrigenDatosAsync(parTipoorigendato);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // POST: api/ParTipoOrigenDatos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PostParTipoOrigenDatos")]
        public async Task<string> PostParTipoorigendato(ParTipoOrigenDatosRequest parTipoorigendato)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _ParTipoOrigenDatosRepository.AddParTipoOrigenDatosAsync(parTipoorigendato);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // DELETE: api/ParTipoOrigenDatos/5
        [HttpDelete("DeleteParTipoOrigenDatos")]
        public async Task<string> DeleteParTipoorigendato(ParTipoOrigenDatosRequest parTipoorigendato)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _ParTipoOrigenDatosRepository.DeleteParTipoOrigenDatosAsync(parTipoorigendato);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        private bool ParTipoorigendatoExists(int id)
        {
            return _context.ParTipoorigendatos.Any(e => e.CodigoOrigenDatos == id);
        }
    }
}
