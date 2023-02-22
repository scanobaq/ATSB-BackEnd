using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ATSB.Api.Areas.Entities.Temporales;
using ATSB.Api.Areas.Identity.Data;
using System.Text.Json;
using Newtonsoft.Json;
using ATSB.Api.Areas.Repositories.Temporales;
using ATSB.Models;
using ATSB.Api.Models.Temporales;
using System.Text.Json.Serialization.Metadata;
using ATSB.Api.Areas.Entities.Parametros;

namespace ATSB.Api.Controllers.Temporales
{
    [Route("api/[controller]")]
    [ApiController]
    public class TmpCargaTxtDepositoPlazoController : ControllerBase
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly ITmpCargaTxtDepositoPlazoRepository _TmpCargaTxtDepositoPlazoRepository;

        public TmpCargaTxtDepositoPlazoController(ATSBIdentityDbContext context, ITmpCargaTxtDepositoPlazoRepository TmpCargaTxtDepositoPlazoRepository)
        {
            _context = context;
            _TmpCargaTxtDepositoPlazoRepository = TmpCargaTxtDepositoPlazoRepository;
        }

        // GET: api/TmpCargaTxtDepositoPlazo
        [HttpGet("GetTmpCargaTxtDepositoPlazos")]
        public async Task<string> GetTmpCargaTxtDepositoplazos()
        {
            var dataTmpCargaTxtDepositoPlazos = _TmpCargaTxtDepositoPlazoRepository.GetTmpCargaTxtDepositoPlazos();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strTmpCargaTxtDepositoPlazos = JsonConvert.SerializeObject(dataTmpCargaTxtDepositoPlazos, options);

            return await Task.Run(() =>
            {
                return strTmpCargaTxtDepositoPlazos;
            });
        }

        // GET: api/TmpCargaTxtDepositoPlazo/5
        [HttpGet("GetTmpCargaTxtDepositoPlazo/{CodigoEmpresa}/{Cuenta}")]
        public async Task<string> GetTmpCargaTxtDepositoplazo(int CodigoEmpresa, string Cuenta)
        {
            var dataTmpCargaTxtDepositoPlazo = await _TmpCargaTxtDepositoPlazoRepository.GetTmpCargaTxtDepositoPlazoAsync(CodigoEmpresa, Cuenta);

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strTmpCargaTxtDepositoPlazo = JsonConvert.SerializeObject(dataTmpCargaTxtDepositoPlazo, options);

            return await Task.Run(() =>
            {
                return strTmpCargaTxtDepositoPlazo;
            });
        }

        private bool TmpCargaTxtDepositoplazoExists(int id)
        {
            return _context.TmpCargaTxtDepositoplazos.Any(e => e.CodigoEmpresa == id);
        }
    }
}
