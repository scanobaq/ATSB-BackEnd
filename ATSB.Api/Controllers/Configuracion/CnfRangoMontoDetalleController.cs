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
    public class CnfRangoMontoDetalleController : ControllerBase
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly ICnfRangoMontoDetalleRepository _CnfRangoMontoDetalleRepository;

        public CnfRangoMontoDetalleController(ATSBIdentityDbContext context, ICnfRangoMontoDetalleRepository CnfRangoMontoDetalleRepository)
        {
            _context = context;
            _CnfRangoMontoDetalleRepository = CnfRangoMontoDetalleRepository;
        }

        // GET: api/CnfRangoMontoDetalle
        [HttpGet("GetCnfRangoMontosDetalles")]
        public async Task<string> GetCnfRangomontodetalles()
        {
            var dataCnfRangos = _CnfRangoMontoDetalleRepository.GetCnfRangoMontosDetalles();

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

        // GET: api/CnfRangoMontoDetalle/5
        [HttpGet("GetCnfRangoMontoDetalle/{CodigoEmpresa}/{CodigoTabla}/{CodigoRango}")]
        public async Task<string> GetCnfRangomontodetalle(int CodigoEmpresa, int CodigoTabla, string CodigoRango)
        {
            var cnfRango = await _CnfRangoMontoDetalleRepository.GetCnfRangoMontoDetalleAsync(CodigoEmpresa, CodigoTabla, CodigoRango);

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

        // PUT: api/CnfRangoMontoDetalle/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("PutCnfRangoMontoDetalle")]
        public async Task<string> PutCnfRangomontodetalle(CnfRangoMontoDetalleRequest cnfRangomontodetalle)
        {
            var response = new Response<object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _CnfRangoMontoDetalleRepository.EditCnfRangoMontoDetalleAsync(cnfRangomontodetalle);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // POST: api/CnfRangoMontoDetalle
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PostCnfRangoMontoDetalle")]
        public async Task<string> PostCnfRangomontodetalle(CnfRangoMontoDetalleRequest cnfRangomontodetalle)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _CnfRangoMontoDetalleRepository.AddCnfRangoMontoDetalleAsync(cnfRangomontodetalle);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // DELETE: api/CnfRangoMontoDetalle/5
        [HttpDelete("DeleteCnfRangoMontoDetalle")]
        public async Task<string> DeleteCnfRangomontodetalle(CnfRangoMontoDetalleRequest cnfRangomontodetalle)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _CnfRangoMontoDetalleRepository.DeleteCnfRangoMontoDetalleAsync(cnfRangomontodetalle);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        private bool CnfRangomontodetalleExists(int id)
        {
            return _context.CnfRangomontodetalles.Any(e => e.CodigoEmpresa == id);
        }
    }
}
