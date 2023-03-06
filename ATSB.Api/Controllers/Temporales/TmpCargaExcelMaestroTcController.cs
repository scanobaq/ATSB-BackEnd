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
    public class TmpCargaExcelMaestroTcController : ControllerBase
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly ITmpCargaExcelMaestroTcRepository _TmpCargaExcelMaestroTcRepository;

        public TmpCargaExcelMaestroTcController(ATSBIdentityDbContext context, ITmpCargaExcelMaestroTcRepository TmpCargaExcelMaestroTcRepository)
        {
            _context = context;
            _TmpCargaExcelMaestroTcRepository = TmpCargaExcelMaestroTcRepository;
        }

        // GET: api/TmpCargaExcelMaestroTc
        [HttpGet("GetTmpCargaExcelMaestrosTc")]
        public async Task<string> GetTmpCargaExcelMaestroTcs()
        {
            var dataTmpCargaExcelMaestrosTc = _TmpCargaExcelMaestroTcRepository.GetTmpCargaExcelMaestrosTc();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strTmpCargaExcelMaestrosTc = JsonConvert.SerializeObject(dataTmpCargaExcelMaestrosTc, options);

            return await Task.Run(() =>
            {
                return strTmpCargaExcelMaestrosTc;
            });
        }

        // GET: api/TmpCargaExcelMaestroTc/5
        [HttpGet("GetTmpCargaExcelMaestroTc/{NumeroTarjeta}")]
        public async Task<string> GetTmpCargaExcelMaestroTc(string NumeroTarjeta)
        {
            var dataTmpCargaExcelMaestroTc = await _TmpCargaExcelMaestroTcRepository.GetTmpCargaExcelMaestroTcAsync(NumeroTarjeta);

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strTmpCargaExcelMaestroTc = JsonConvert.SerializeObject(dataTmpCargaExcelMaestroTc, options);

            return await Task.Run(() =>
            {
                return strTmpCargaExcelMaestroTc;
            });
        }

        private bool TmpCargaExcelMaestroTcExists(string id)
        {
            return _context.TmpCargaExcelMaestroTcs.Any(e => e.NumeroTarjeta == id);
        }
    }
}
