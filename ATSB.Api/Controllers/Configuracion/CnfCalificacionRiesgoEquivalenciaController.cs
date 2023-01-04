using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ATSB.Api.Areas.Entities.Configuracion;
using ATSB.Api.Areas.Identity.Data;
using System.Text.Json;
using Newtonsoft.Json;
using ATSB.Api.Areas.Repositories.Configuracion;
using ATSB.Models;
using ATSB.Api.Models.Configuracion;

namespace ATSB.Api.Controllers.Configuracion
{
    [Route("api/[controller]")]
    [ApiController]
    public class CnfCalificacionRiesgoEquivalenciaController : ControllerBase
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly ICnfCalificacionRiesgoEquivalenciaRepository _CnfCalificacionRiesgoEquivalenciaRepository;

        public CnfCalificacionRiesgoEquivalenciaController(ATSBIdentityDbContext context, ICnfCalificacionRiesgoEquivalenciaRepository CnfCalificacionRiesgoEquivalenciaRepository)
        {
            _context = context;
            _CnfCalificacionRiesgoEquivalenciaRepository = CnfCalificacionRiesgoEquivalenciaRepository;
        }

        // GET: api/CnfCalificacionRiesgoEquivalencia
        [HttpGet("GetCnfCalificacionRiesgoEquivalencias")]
        public async Task<string> GetCnfCalificacionriesgoequivalencia()
        {
            var dataCnfCalificacion = _CnfCalificacionRiesgoEquivalenciaRepository.GetCnfCalificacionRiesgoEquivalencias();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strCalificacion = JsonConvert.SerializeObject(dataCnfCalificacion, options);

            return await Task.Run(() =>
            {
                return strCalificacion;
            });
        }

        // GET: api/CnfCalificacionRiesgoEquivalencia/5
        [HttpGet("GetCnfCalificacionRiesgoEquivalencia/{CodigoEmpresa}/{CalificacionOrigen}")]
        public async Task<string> GetCnfCalificacionriesgoequivalencium(int CodigoEmpresa, string CalificacionOrigen)
        {
            var cnfCalificacion = await _CnfCalificacionRiesgoEquivalenciaRepository.GetCnfCalificacionRiesgoEquivalenciaAsync(CodigoEmpresa, CalificacionOrigen);

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strCalificacion = JsonConvert.SerializeObject(cnfCalificacion, options);

            return await Task.Run(() =>
            {
                return strCalificacion;
            });
        }

        // PUT: api/CnfCalificacionRiesgoEquivalencia/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("PutCnfCalificacionRiesgoEquivalencia")]
        public async Task<string> PutCnfCalificacionriesgoequivalencium(CnfCalificacionRiesgoEquivalenciaRequest cnfCalificacionriesgoequivalencium)
        {
            var response = new Response<object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _CnfCalificacionRiesgoEquivalenciaRepository.EditCnfCalificacionRiesgoEquivalenciaAsync(cnfCalificacionriesgoequivalencium);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // POST: api/CnfCalificacionRiesgoEquivalencia
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PostCnfCalificacionRiesgoEquivalencia")]
        public async Task<string> PostCnfCalificacionriesgoequivalencium(CnfCalificacionRiesgoEquivalenciaRequest cnfCalificacionriesgoequivalencium)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _CnfCalificacionRiesgoEquivalenciaRepository.AddCnfCalificacionRiesgoEquivalenciaAsync(cnfCalificacionriesgoequivalencium);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // DELETE: api/CnfCalificacionRiesgoEquivalencia/5
        [HttpDelete("DeleteCnfCalificacionRiesgoEquivalencia")]
        public async Task<string> DeleteCnfCalificacionriesgoequivalencium(CnfCalificacionRiesgoEquivalenciaRequest cnfCalificacionriesgoequivalencium)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _CnfCalificacionRiesgoEquivalenciaRepository.DeleteCnfCalificacionRiesgoEquivalenciaAsync(cnfCalificacionriesgoequivalencium);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        private bool CnfCalificacionriesgoequivalenciumExists(int id)
        {
            return _context.CnfCalificacionriesgoequivalencia.Any(e => e.CodigoEmpresa == id);
        }
    }
}
