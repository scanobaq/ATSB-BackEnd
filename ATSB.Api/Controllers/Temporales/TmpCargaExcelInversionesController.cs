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
    public class TmpCargaExcelInversionesController : ControllerBase
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly ITmpCargaExcelInversionesRepository _TmpCargaExcelInversionesRepository;

        public TmpCargaExcelInversionesController(ATSBIdentityDbContext context, ITmpCargaExcelInversionesRepository TmpCargaExcelInversionesRepository)
        {
            _context = context;
            _TmpCargaExcelInversionesRepository = TmpCargaExcelInversionesRepository;
        }

        // GET: api/TmpCargaExcelInversiones
        [HttpGet("GetListaTmpCargaExcelInversiones")]
        public async Task<string> GetTmpCargaExcelInversiones()
        {
            var dataListaTmpCargaExcelInversiones = _TmpCargaExcelInversionesRepository.GetListaTmpCargaExcelInversiones();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strListaTmpCargaExcelInversiones = JsonConvert.SerializeObject(dataListaTmpCargaExcelInversiones, options);

            return await Task.Run(() =>
            {
                return strListaTmpCargaExcelInversiones;
            });
        }

        // GET: api/TmpCargaExcelInversiones/5
        [HttpGet("GetTmpCargaExcelInversiones/{Llave}")]
        public async Task<string> GetTmpCargaExcelInversione(Guid Llave)
        {
            var dataTmpCargaExcelInversiones = await _TmpCargaExcelInversionesRepository.GetTmpCargaExcelInversionesAsync(Llave);

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strTmpCargaExcelInversiones = JsonConvert.SerializeObject(dataTmpCargaExcelInversiones, options);

            return await Task.Run(() =>
            {
                return strTmpCargaExcelInversiones;
            });
        }

        private bool TmpCargaExcelInversioneExists(Guid id)
        {
            return _context.TmpCargaExcelInversiones.Any(e => e.Llave == id);
        }
    }
}
