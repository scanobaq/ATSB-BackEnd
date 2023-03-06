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
    public class TmpCargaExcelCreditoCalificacionesController : ControllerBase
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly ITmpCargaExcelCreditoCalificacionesRepository _TmpCargaExcelCreditoCalificacionesRepository;

        public TmpCargaExcelCreditoCalificacionesController(ATSBIdentityDbContext context, ITmpCargaExcelCreditoCalificacionesRepository TmpCargaExcelCreditoCalificacionesRepository)
        {
            _context = context;
            _TmpCargaExcelCreditoCalificacionesRepository = TmpCargaExcelCreditoCalificacionesRepository;
        }

        // GET: api/TmpCargaExcelCreditoCalificaciones
        [HttpGet("GetTmpCargaExcelCreditosCalificaciones")]
        public async Task<string> GetTmpCargaExcelCreditoCalificaciones()
        {
            var dataTmpCargaExcelCreditosCalificaciones = _TmpCargaExcelCreditoCalificacionesRepository.GetTmpCargaExcelCreditosCalificaciones();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strTmpCargaExcelCreditosCalificaciones = JsonConvert.SerializeObject(dataTmpCargaExcelCreditosCalificaciones, options);

            return await Task.Run(() =>
            {
                return strTmpCargaExcelCreditosCalificaciones;
            });
        }

        // GET: api/TmpCargaExcelCreditoCalificaciones/5
        [HttpGet("GetTmpCargaExcelCreditoCalificaciones/{NumOper}")]
        public async Task<string> GetTmpCargaExcelCreditoCalificacione(string NumOper)
        {
            var dataTmpCargaExcelCreditoCalificaciones = await _TmpCargaExcelCreditoCalificacionesRepository.GetTmpCargaExcelCreditoCalificacionesAsync(NumOper);

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strTmpCargaExcelCreditoCalificaciones = JsonConvert.SerializeObject(dataTmpCargaExcelCreditoCalificaciones, options);

            return await Task.Run(() =>
            {
                return strTmpCargaExcelCreditoCalificaciones;
            });
        }

        private bool TmpCargaExcelCreditoCalificacioneExists(string id)
        {
            return _context.TmpCargaExcelCreditoCalificaciones.Any(e => e.NumOper == id);
        }
    }
}
