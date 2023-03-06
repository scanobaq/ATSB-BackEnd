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
    public class TmpCargaExcelCalificionRiesgoPaisController : ControllerBase
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly ITmpCargaExcelCalificionRiesgoPaisRepository _TmpCargaExcelCalificionRiesgoPaisRepository;

        public TmpCargaExcelCalificionRiesgoPaisController(ATSBIdentityDbContext context, ITmpCargaExcelCalificionRiesgoPaisRepository TmpCargaExcelCalificionRiesgoPaisRepository)
        {
            _context = context;
            _TmpCargaExcelCalificionRiesgoPaisRepository = TmpCargaExcelCalificionRiesgoPaisRepository;
        }

        // GET: api/TmpCargaExcelCalificionRiesgoPais
        [HttpGet("GetListaTmpCargaExcelCalificionRiesgoPais")]
        public async Task<string> GetTmpCargaExcelCalificionriesgopais()
        {
            var dataListaTmpCargaExcelCalificionRiesgoPais = _TmpCargaExcelCalificionRiesgoPaisRepository.GetTmpCargaExcelCalificionRiesgoPais();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strListaTmpCargaExcelCalificionRiesgoPais = JsonConvert.SerializeObject(dataListaTmpCargaExcelCalificionRiesgoPais, options);

            return await Task.Run(() =>
            {
                return strListaTmpCargaExcelCalificionRiesgoPais;
            });
        }

        // GET: api/TmpCargaExcelCalificionRiesgoPais/5
        [HttpGet("GetTmpCargaExcelCalificionRiesgoPais/{Llave}")]
        public async Task<string> GetTmpCargaExcelCalificionriesgopai(Guid Llave)
        {
            var dataTmpCargaExcelCalificionRiesgoPais = await _TmpCargaExcelCalificionRiesgoPaisRepository.GetTmpCargaExcelCalificionRiesgoPaisAsync(Llave);

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strTmpCargaExcelCalificionRiesgoPais = JsonConvert.SerializeObject(dataTmpCargaExcelCalificionRiesgoPais, options);

            return await Task.Run(() =>
            {
                return strTmpCargaExcelCalificionRiesgoPais;
            });
        }

        private bool TmpCargaExcelCalificionriesgopaiExists(Guid id)
        {
            return _context.TmpCargaExcelCalificionriesgopais.Any(e => e.Llave == id);
        }
    }
}
