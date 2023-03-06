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
    public class TmpCargaExcelInversionesCalificacionesController : ControllerBase
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly ITmpCargaExcelInversionesCalificacionesRepository _TmpCargaExcelInversionesCalificacionesRepository;

        public TmpCargaExcelInversionesCalificacionesController(ATSBIdentityDbContext context, ITmpCargaExcelInversionesCalificacionesRepository TmpCargaExcelInversionesCalificacionesRepository)
        {
            _context = context;
            _TmpCargaExcelInversionesCalificacionesRepository = TmpCargaExcelInversionesCalificacionesRepository;
        }

        // GET: api/TmpCargaExcelInversionesCalificaciones
        [HttpGet("GetListaTmpCargaExcelInversionesCalificaciones")]
        public async Task<string> GetTmpCargaExcelInversionesCalificaciones()
        {
            var dataListaTmpCargaExcelInversionesCalificaciones = _TmpCargaExcelInversionesCalificacionesRepository.GetListaTmpCargaExcelInversionesCalificaciones();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strListaTmpCargaExcelInversionesCalificaciones = JsonConvert.SerializeObject(dataListaTmpCargaExcelInversionesCalificaciones, options);

            return await Task.Run(() =>
            {
                return strListaTmpCargaExcelInversionesCalificaciones;
            });
        }

        // GET: api/TmpCargaExcelInversionesCalificaciones/5
        [HttpGet("GetTmpCargaExcelInversionesCalificaciones/{CodigoISIN}")]
        public async Task<string> GetTmpCargaExcelInversionesCalificacione(string CodigoISIN)
        {
            var dataTmpCargaExcelInversionesCalificaciones = await _TmpCargaExcelInversionesCalificacionesRepository.GetTmpCargaExcelInversionesCalificacionesAsync(CodigoISIN);

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strTmpCargaExcelInversionesCalificaciones = JsonConvert.SerializeObject(dataTmpCargaExcelInversionesCalificaciones, options);

            return await Task.Run(() =>
            {
                return strTmpCargaExcelInversionesCalificaciones;
            });
        }

        private bool TmpCargaExcelInversionesCalificacioneExists(string id)
        {
            return _context.TmpCargaExcelInversionesCalificaciones.Any(e => e.CodigoIsin == id);
        }
    }
}
