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
    public class ConCatalogoEquivalenciaController : ControllerBase
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IConCatalogoEquivalenciaRepository _ConCatalogoEquivalenciaRepository;

        public ConCatalogoEquivalenciaController(ATSBIdentityDbContext context, IConCatalogoEquivalenciaRepository ConCatalogoEquivalenciaRepository)
        {
            _context = context;
            _ConCatalogoEquivalenciaRepository = ConCatalogoEquivalenciaRepository;
        }

        // GET: api/ConCatalogoEquivalencia
        [HttpGet("GetConCatalogosEquivalencia")]
        public async Task<string> GetConCatalogoequivalencia()
        {
            var dataConCatalogos = _ConCatalogoEquivalenciaRepository.GetConCatalogosEquivalencia();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strCatalogos = JsonConvert.SerializeObject(dataConCatalogos, options);

            return await Task.Run(() =>
            {
                return strCatalogos;
            });
        }

        // GET: api/ConCatalogoEquivalencia/5
        [HttpGet("GetConCatalogoEquivalencia/{CodigoEmpresa}/{IdCuenta}")]
        public async Task<string> GetConCatalogoequivalencium(int CodigoEmpresa, int IdCuenta)
        {
            var conCatalogo = await _ConCatalogoEquivalenciaRepository.GetConCatalogoEquivalenciaAsync(CodigoEmpresa, IdCuenta);

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strCatalogo = JsonConvert.SerializeObject(conCatalogo, options);

            return await Task.Run(() =>
            {
                return strCatalogo;
            });
        }

        // PUT: api/ConCatalogoEquivalencia/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("PutConCatalogoEquivalencia")]
        public async Task<string> PutConCatalogoequivalencium(ConCatalogoEquivalenciaRequest conCatalogoEquivalencia)
        {
            var response = new Response<object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _ConCatalogoEquivalenciaRepository.EditConCatalogoEquivalenciaAsync(conCatalogoEquivalencia);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // POST: api/ConCatalogoEquivalencia
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PostConCatalogoEquivalencia")]
        public async Task<string> PostConCatalogoequivalencium(ConCatalogoEquivalenciaRequest conCatalogoEquivalencia)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _ConCatalogoEquivalenciaRepository.AddConCatalogoEquivalenciaAsync(conCatalogoEquivalencia);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // DELETE: api/ConCatalogoEquivalencia/5
        [HttpDelete("DeleteConCatalogoEquivalencia")]
        public async Task<string> DeleteConCatalogoequivalencium(ConCatalogoEquivalenciaRequest conCatalogoEquivalencia)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _ConCatalogoEquivalenciaRepository.DeleteConCatalogoEquivalenciaAsync(conCatalogoEquivalencia);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        private bool ConCatalogoequivalenciumExists(int id)
        {
            return _context.ConCatalogoequivalencia.Any(e => e.CodigoEmpresa == id);
        }
    }
}
