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
using Microsoft.EntityFrameworkCore.Metadata;
using System.Runtime.InteropServices;

namespace ATSB.Api.Controllers.Configuracion
{
    [Route("api/[controller]")]
    [ApiController]
    public class CnfRangoMontoEncabezadoController : ControllerBase
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly ICnfRangoMontoEncabezadoRepository _CnfRangoMontoEncabezadoRepository;

        public CnfRangoMontoEncabezadoController(ATSBIdentityDbContext context, ICnfRangoMontoEncabezadoRepository CnfRangoMontoEncabezadoRepository)
        {
            _context = context;
            _CnfRangoMontoEncabezadoRepository = CnfRangoMontoEncabezadoRepository;
        }

        // GET: api/CnfRangoMontoEncabezado
        [HttpGet("GetCnfRangoMontosEncabezados")]
        public async Task<string> GetCnfRangomontoencabezados()
        {
            var dataCnfRangos = _CnfRangoMontoEncabezadoRepository.GetCnfRangoMontosEncabezados();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strRangos = JsonConvert.SerializeObject(dataCnfRangos, options);

            return await Task.Run(() =>
            {
                return strRangos;
            });
        }

        // GET: api/CnfRangoMontoEncabezado/5
        [HttpGet("GetCnfRangoMontoEncabezado/{CodigoEmpresa}/{CodigoTabla}")]
        public async Task<string> GetCnfRangomontoencabezado(int CodigoEmpresa, int CodigoTabla)
        {
            var cnfRango = await _CnfRangoMontoEncabezadoRepository.GetCnfRangoMontoEncabezadoAsync(CodigoEmpresa, CodigoTabla);

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strRango = JsonConvert.SerializeObject(cnfRango, options);

            return await Task.Run(() =>
            {
                return strRango;
            });
        }

        // PUT: api/CnfRangoMontoEncabezado/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("PutCnfRangoMontoEncabezado")]
        public async Task<string> PutCnfRangomontoencabezado(CnfRangoMontoEncabezadoRequest cnfRangomontoencabezado)
        {
            var response = new Response<object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _CnfRangoMontoEncabezadoRepository.EditCnfRangoMontoEncabezadoAsync(cnfRangomontoencabezado);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // POST: api/CnfRangoMontoEncabezado
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PostCnfRangoMontoEncabezado")]
        public async Task<string> PostCnfRangomontoencabezado(CnfRangoMontoEncabezadoRequest cnfRangomontoencabezado)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _CnfRangoMontoEncabezadoRepository.AddCnfRangoMontoEncabezadoAsync(cnfRangomontoencabezado);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // DELETE: api/CnfRangoMontoEncabezado/5
        [HttpDelete("DeleteCnfRangoMontoEncabezado")]
        public async Task<string> DeleteCnfRangomontoencabezado(CnfRangoMontoEncabezadoRequest cnfRangomontoencabezado)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _CnfRangoMontoEncabezadoRepository.DeleteCnfRangoMontoEncabezadoAsync(cnfRangomontoencabezado);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        private bool CnfRangomontoencabezadoExists(int id)
        {
            return _context.CnfRangomontoencabezados.Any(e => e.CodigoEmpresa == id);
        }
    }
}
