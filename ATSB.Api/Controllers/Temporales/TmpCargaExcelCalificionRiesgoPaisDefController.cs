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
    public class TmpCargaExcelCalificionRiesgoPaisDefController : ControllerBase
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly ITmpCargaExcelCalificionRiesgoPaisDefRepository _TmpCargaExcelCalificionRiesgoPaisDefRepository;

        public TmpCargaExcelCalificionRiesgoPaisDefController(ATSBIdentityDbContext context, ITmpCargaExcelCalificionRiesgoPaisDefRepository TmpCargaExcelCalificionRiesgoPaisDefRepository)
        {
            _context = context;
            _TmpCargaExcelCalificionRiesgoPaisDefRepository = TmpCargaExcelCalificionRiesgoPaisDefRepository;
        }

        // GET: api/TmpCargaExcelCalificionRiesgoPaisDef
        [HttpGet("GetTmpCargaExcelCalificionesRiesgoPaisDef")]
        public async Task<string> GetTmpCargaExcelCalificionriesgopaisDefs()
        {
            var dataTmpCargaExcelCalificionesRiesgoPaisDef = _TmpCargaExcelCalificionRiesgoPaisDefRepository.GetTmpCargaExcelCalificionesRiesgoPaisDef();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strTmpCargaExcelCalificionesRiesgoPaisDef = JsonConvert.SerializeObject(dataTmpCargaExcelCalificionesRiesgoPaisDef, options);

            return await Task.Run(() =>
            {
                return strTmpCargaExcelCalificionesRiesgoPaisDef;
            });
        }

        // GET: api/TmpCargaExcelCalificionRiesgoPaisDef/5
        [HttpGet("GetTmpCargaExcelCalificionRiesgoPaisDef/{Llave}")]
        public async Task<string> GetTmpCargaExcelCalificionriesgopaisDef(Guid Llave)
        {
            var dataTmpCargaExcelCalificionRiesgoPaisDef = await _TmpCargaExcelCalificionRiesgoPaisDefRepository.GetTmpCargaExcelCalificionRiesgoPaisDefAsync(Llave);

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strTmpCargaExcelCalificionRiesgoPaisDef = JsonConvert.SerializeObject(dataTmpCargaExcelCalificionRiesgoPaisDef, options);

            return await Task.Run(() =>
            {
                return strTmpCargaExcelCalificionRiesgoPaisDef;
            });
        }

        private bool TmpCargaExcelCalificionriesgopaisDefExists(Guid? id)
        {
            return _context.TmpCargaExcelCalificionriesgopaisDefs.Any(e => e.Llave == id);
        }
    }
}
