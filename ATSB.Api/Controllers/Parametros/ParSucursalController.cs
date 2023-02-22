using Microsoft.AspNetCore.Mvc;
using ATSB.Api.Areas.Identity.Data;
using Newtonsoft.Json;
using ATSB.Api.Areas.Repositories.Parametros;
using ATSB.Models;
using ATSB.Api.Models.Parametros;

namespace ATSB.Api.Controllers.Parametros
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParSucursalController : ControllerBase
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IParSucursalRepository _ParSucursalRepository;

        public ParSucursalController(ATSBIdentityDbContext context, IParSucursalRepository ParSucursalRepository)
        {
            _context = context;
            _ParSucursalRepository = ParSucursalRepository;
        }

        // GET: api/ParSucursal
        [HttpGet("GetParSucursales")]
        public async Task<string> GetParSucursales()
        {
            var dataParSucursales = _ParSucursalRepository.GetParSucursales();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strSucursales = JsonConvert.SerializeObject(dataParSucursales, options);

            return await Task.Run(() =>
            {
                return strSucursales;
            });
        }

        // GET: api/ParSucursal/5
        [HttpGet("GetParSucursal/{CodigoEmpresa}/{CodigoBanco}/{CodigoSucursal}")]
        public async Task<string> GetParSucursal(int CodigoEmpresa, int CodigoBanco, int CodigoSucursal)
        {
            var parSucursal = await _ParSucursalRepository.GetParSucursalAsync(CodigoEmpresa, CodigoBanco, CodigoSucursal);

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strSucursal = JsonConvert.SerializeObject(parSucursal, options);

            return await Task.Run(() =>
            {
                return strSucursal;
            });
        }

        // PUT: api/ParSucursal/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("PutParSucursal")]
        public async Task<string> PutParSucursal(ParSucursalRequest parSucursal)
        {
            var response = new Response<object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _ParSucursalRepository.EditParSucursalAsync(parSucursal);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // POST: api/ParSucursal
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PostParSucursal")]
        public async Task<string> PostParSucursal(ParSucursalRequest parSucursal)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _ParSucursalRepository.AddParSucursalAsync(parSucursal);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        // DELETE: api/ParSucursal/5
        [HttpDelete("DeleteParSucursal")]
        public async Task<string> DeleteParSucursal(ParSucursalRequest parSucursal)
        {
            var response = new Response<Object>();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var res = await _ParSucursalRepository.DeleteParSucursalAsync(parSucursal);
            response.IsSuccess = res.IsSuccess;
            response.Message = res.Message;
            response.Result = res.Result;

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });
        }

        private bool ParSucursalExists(int id)
        {
            return _context.ParSucursals.Any(e => e.CodigoEmpresa == id);
        }
    }
}
