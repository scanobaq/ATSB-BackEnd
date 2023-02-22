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
    public class TmpCargaExcelCreditoCalificacionesDefController : ControllerBase
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly ITmpCargaExcelCreditoCalificacionesDefRepository _TmpCargaExcelCreditoCalificacionesDefRepository;

        public TmpCargaExcelCreditoCalificacionesDefController(ATSBIdentityDbContext context, ITmpCargaExcelCreditoCalificacionesDefRepository TmpCargaExcelCreditoCalificacionesDefRepository)
        {
            _context = context;
            _TmpCargaExcelCreditoCalificacionesDefRepository = TmpCargaExcelCreditoCalificacionesDefRepository;
        }

        // GET: api/TmpCargaExcelCreditoCalificacionesDef
        [HttpGet("GetTmpCargaExcelCreditosCalificacionesDef")]
        public async Task<string> GetTmpCargaExcelCreditoCalificacionesDefs()
        {
            var dataTmpCargaExcelCreditosCalificacionesDef = _TmpCargaExcelCreditoCalificacionesDefRepository.GetTmpCargaExcelCreditosCalificacionesDef();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strTmpCargaExcelCreditosCalificacionesDef = JsonConvert.SerializeObject(dataTmpCargaExcelCreditosCalificacionesDef, options);

            return await Task.Run(() =>
            {
                return strTmpCargaExcelCreditosCalificacionesDef;
            });
        }

        // GET: api/TmpCargaExcelCreditoCalificacionesDef/5
        [HttpGet("GetTmpCargaExcelCreditoCalificacionesDef/{NumOper}")]
        public async Task<string> GetTmpCargaExcelCreditoCalificacionesDef(string NumOper)
        {
            var dataTmpCargaExcelCreditoCalificacionesDef = await _TmpCargaExcelCreditoCalificacionesDefRepository.GetTmpCargaExcelCreditoCalificacionesDefAsync(NumOper);

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strTmpCargaExcelCreditoCalificacionesDef = JsonConvert.SerializeObject(dataTmpCargaExcelCreditoCalificacionesDef, options);

            return await Task.Run(() =>
            {
                return strTmpCargaExcelCreditoCalificacionesDef;
            });
        }

        private bool TmpCargaExcelCreditoCalificacionesDefExists(string id)
        {
            return _context.TmpCargaExcelCreditoCalificacionesDefs.Any(e => e.NumOper == id);
        }
    }
}
