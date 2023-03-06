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
    public class TmpCargaExcelInversionesDefController : ControllerBase
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly ITmpCargaExcelInversionesDefRepository _TmpCargaExcelInversionesDefRepository;

        public TmpCargaExcelInversionesDefController(ATSBIdentityDbContext context, ITmpCargaExcelInversionesDefRepository TmpCargaExcelInversionesDefRepository)
        {
            _context = context;
            _TmpCargaExcelInversionesDefRepository = TmpCargaExcelInversionesDefRepository;
        }

        // GET: api/TmpCargaExcelInversionesDef
        [HttpGet("GetListaTmpCargaExcelInversionesDef")]
        public async Task<string> GetTmpCargaExcelInversionesDefs()
        {
            var dataListaTmpCargaExcelInversionesDef = _TmpCargaExcelInversionesDefRepository.GetTmpCargaExcelInversionesDef();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strListaTmpCargaExcelInversionesDef = JsonConvert.SerializeObject(dataListaTmpCargaExcelInversionesDef, options);

            return await Task.Run(() =>
            {
                return strListaTmpCargaExcelInversionesDef;
            });
        }

        // GET: api/TmpCargaExcelInversionesDef/5
        [HttpGet("GetTmpCargaExcelInversionesDef/{Llave}")]
        public async Task<string> GetTmpCargaExcelInversionesDef(Guid Llave)
        {
            var dataTmpCargaExcelInversionesDef = await _TmpCargaExcelInversionesDefRepository.GetTmpCargaExcelInversionesDefAsync(Llave);

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strTmpCargaExcelInversionesDef = JsonConvert.SerializeObject(dataTmpCargaExcelInversionesDef, options);

            return await Task.Run(() =>
            {
                return strTmpCargaExcelInversionesDef;
            });
        }

        private bool TmpCargaExcelInversionesDefExists(Guid? id)
        {
            return _context.TmpCargaExcelInversionesDefs.Any(e => e.Llave == id);
        }
    }
}
