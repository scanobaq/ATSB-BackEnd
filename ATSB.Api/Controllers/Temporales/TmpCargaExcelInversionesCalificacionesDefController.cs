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
    public class TmpCargaExcelInversionesCalificacionesDefController : ControllerBase
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly ITmpCargaExcelInversionesCalificacionesDefRepository _TmpCargaExcelInversionesCalificacionesDefRepository;

        public TmpCargaExcelInversionesCalificacionesDefController(ATSBIdentityDbContext context, ITmpCargaExcelInversionesCalificacionesDefRepository TmpCargaExcelInversionesCalificacionesDefRepository)
        {
            _context = context;
            _TmpCargaExcelInversionesCalificacionesDefRepository = TmpCargaExcelInversionesCalificacionesDefRepository;
        }

        // GET: api/TmpCargaExcelInversionesCalificacionesDef
        [HttpGet("GetListaTmpCargaExcelInversionesCalificacionesDef")]
        public async Task<string> GetTmpCargaExcelInversionesCalificacionesDefs()
        {
            var dataListaTmpCargaExcelInversionesCalificacionesDef = _TmpCargaExcelInversionesCalificacionesDefRepository.GetTmpCargaExcelInversionesCalificacionesDef();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strListaTmpCargaExcelInversionesCalificacionesDef = JsonConvert.SerializeObject(dataListaTmpCargaExcelInversionesCalificacionesDef, options);

            return await Task.Run(() =>
            {
                return strListaTmpCargaExcelInversionesCalificacionesDef;
            });
        }

        // GET: api/TmpCargaExcelInversionesCalificacionesDef/5
        [HttpGet("GetTmpCargaExcelInversionesCalificacionesDef/{CodigoISIN}")]
        public async Task<string> GetTmpCargaExcelInversionesCalificacionesDef(string CodigoISIN)
        {
            var dataTmpCargaExcelInversionesCalificacionesDef = await _TmpCargaExcelInversionesCalificacionesDefRepository.GetTmpCargaExcelInversionesCalificacionesDefAsync(CodigoISIN);

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strTmpCargaExcelInversionesCalificacionesDef = JsonConvert.SerializeObject(dataTmpCargaExcelInversionesCalificacionesDef, options);

            return await Task.Run(() =>
            {
                return strTmpCargaExcelInversionesCalificacionesDef;
            });
        }

        private bool TmpCargaExcelInversionesCalificacionesDefExists(string id)
        {
            return _context.TmpCargaExcelInversionesCalificacionesDefs.Any(e => e.CodigoIsin == id);
        }
    }
}
