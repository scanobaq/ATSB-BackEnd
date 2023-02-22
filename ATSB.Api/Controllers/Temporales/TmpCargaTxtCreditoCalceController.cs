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
    public class TmpCargaTxtCreditoCalceController : ControllerBase
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly ITmpCargaTxtCreditoCalceRepository _TmpCargaTxtCreditoCalceRepository;

        public TmpCargaTxtCreditoCalceController(ATSBIdentityDbContext context, ITmpCargaTxtCreditoCalceRepository TmpCargaTxtCreditoCalceRepository)
        {
            _context = context;
            _TmpCargaTxtCreditoCalceRepository = TmpCargaTxtCreditoCalceRepository;
        }

        // GET: api/TmpCargaTxtCreditoCalce
        [HttpGet("GetTmpCargaTxtCreditosCalce")]
        public async Task<string> GetTmpCargaTxtCreditocalces()
        {
            var dataTmpCargaTxtCreditosCalce = _TmpCargaTxtCreditoCalceRepository.GetTmpCargaTxtCreditosCalce();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strTmpCargaTxtCreditosCalce = JsonConvert.SerializeObject(dataTmpCargaTxtCreditosCalce, options);

            return await Task.Run(() =>
            {
                return strTmpCargaTxtCreditosCalce;
            });
        }

        // GET: api/TmpCargaTxtCreditoCalce/5
        [HttpGet("GetTmpCargaTxtCreditoCalce/{CodigoEmpresa}/{CodigoTipo}/{NumeroCredito}")]
        public async Task<string> GetTmpCargaTxtCreditocalce(int CodigoEmpresa, string CodigoTipo, string NumeroCredito)
        {
            var dataTmpCargaTxtCreditoCalce = await _TmpCargaTxtCreditoCalceRepository.GetTmpCargaTxtCreditoCalceAsync(CodigoEmpresa, CodigoTipo, NumeroCredito);

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strTmpCargaTxtCreditoCalce = JsonConvert.SerializeObject(dataTmpCargaTxtCreditoCalce, options);

            return await Task.Run(() =>
            {
                return strTmpCargaTxtCreditoCalce;
            });
        }

        private bool TmpCargaTxtCreditocalceExists(int id)
        {
            return _context.TmpCargaTxtCreditocalces.Any(e => e.CodigoEmpresa == id);
        }
    }
}
