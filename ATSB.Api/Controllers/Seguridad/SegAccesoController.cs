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
    public class SegAccesoController : ControllerBase
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly ISegAccesoRepository _SegAccesoRepository;

        public SegAccesoController(ATSBIdentityDbContext context, ISegAccesoRepository SegAccesoRepository)
        {
            _context = context;
            _SegAccesoRepository = SegAccesoRepository;
        }

        // GET: api/SegAcceso
        [HttpGet("GetSegAccesos")]
        public async Task<string> GetSegAccesos()
        {
            var dataSegAccesos = _SegAccesoRepository.GetSegAccesos();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strAccesos = JsonConvert.SerializeObject(dataSegAccesos, options);

            return await Task.Run(() =>
            {
                return strAccesos;
            });
        }

        // GET: api/SegAcceso/5
        [HttpGet("GetSegAcceso/{CodigoEmpresa}/{CodigoTipoAcceso}")]
        public async Task<string> GetSegAcceso(int CodigoEmpresa, int CodigoTipoAcceso)
        {
            var segAcceso = await _SegAccesoRepository.GetSegAccesoAsync(CodigoEmpresa, CodigoTipoAcceso);

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strAcceso = JsonConvert.SerializeObject(segAcceso, options);

            return await Task.Run(() =>
            {
                return strAcceso;
            });
        }

        // PUT: api/SegAcceso/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("PutSegAcceso")]
        public async Task<string> PutSegAcceso(SegAccesoRequest segAcceso)
        {
            var response = new Response<object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _SegAccesoRepository.EditSegAccesoAsync(segAcceso);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // POST: api/SegAcceso
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PostSegAcceso")]
        public async Task<string> PostSegAcceso(SegAccesoRequest segAcceso)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _SegAccesoRepository.AddSegAccesoAsync(segAcceso);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // DELETE: api/SegAcceso/5
        [HttpDelete("DeleteSegAcceso")]
        public async Task<string> DeleteSegAcceso(SegAccesoRequest segAcceso)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _SegAccesoRepository.DeleteSegAccesoAsync(segAcceso);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        private bool SegAccesoExists(int id)
        {
            return _context.SegAccesos.Any(e => e.CodigoEmpresa == id);
        }
    }
}
