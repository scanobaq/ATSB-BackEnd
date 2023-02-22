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
    public class TmpCargaExcelMaestroTcDefController : ControllerBase
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly ITmpCargaExcelMaestroTcDefRepository _TmpCargaExcelMaestroTcDefRepository;

        public TmpCargaExcelMaestroTcDefController(ATSBIdentityDbContext context, ITmpCargaExcelMaestroTcDefRepository TmpCargaExcelMaestroTcDefRepository)
        {
            _context = context;
            _TmpCargaExcelMaestroTcDefRepository = TmpCargaExcelMaestroTcDefRepository;
        }

        // GET: api/TmpCargaExcelMaestroTcDef
        [HttpGet("GetTmpCargaExcelMaestrosTcDef")]
        public async Task<string> GetTmpCargaExcelMaestroTcDefs()
        {
            var dataTmpCargaExcelMaestrosTcDef = _TmpCargaExcelMaestroTcDefRepository.GetTmpCargaExcelMaestrosTcDef();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strTmpCargaExcelMaestrosTcDef = JsonConvert.SerializeObject(dataTmpCargaExcelMaestrosTcDef, options);

            return await Task.Run(() =>
            {
                return strTmpCargaExcelMaestrosTcDef;
            });
        }

        // GET: api/TmpCargaExcelMaestroTcDef/5
        [HttpGet("GetTmpCargaExcelMaestroTcDef/{NumeroTarjeta}")]
        public async Task<string> GetTmpCargaExcelMaestroTcDef(string NumeroTarjeta)
        {
            var dataTmpCargaExcelMaestroTcDef = await _TmpCargaExcelMaestroTcDefRepository.GetTmpCargaExcelMaestroTcDefAsync(NumeroTarjeta);

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string TmpCargaExcelMaestroTcDef = JsonConvert.SerializeObject(dataTmpCargaExcelMaestroTcDef, options);

            return await Task.Run(() =>
            {
                return TmpCargaExcelMaestroTcDef;
            });
        }


        private bool TmpCargaExcelMaestroTcDefExists(string id)
        {
            return _context.TmpCargaExcelMaestroTcDefs.Any(e => e.NumeroTarjeta == id);
        }
    }
}
