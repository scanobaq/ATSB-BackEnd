using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATSB.Api.Models.Logs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ATSB.Api.Areas.Identity.Data;
using ATSB.Models;
using ATSB.Api.Areas.Entities.Logs;
using ATSB.Api.Helpers;
using ATSB.Api.Areas.Entities.Parametros;
using ATSB.Api.Areas.Entities.Temporales;

namespace ATSB.Api.Areas.Repositories.Temporales
{
    public class TmpCargaExcelInversionesCalificacionesRepository : ITmpCargaExcelInversionesCalificacionesRepository
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IConsecutivoHelper _ConsecutivoHelper;

        public TmpCargaExcelInversionesCalificacionesRepository
        (
            ATSBIdentityDbContext context,
            IConsecutivoHelper ConsecutivoHelper
        ) : base()

        {
            _context = context;
            _ConsecutivoHelper = ConsecutivoHelper;
        }

        public IQueryable GetListaTmpCargaExcelInversionesCalificaciones()
        {
            return _context.TmpCargaExcelInversionesCalificaciones
                .AsNoTracking();
        }

        public async Task<TmpCargaExcelInversionesCalificacione> GetTmpCargaExcelInversionesCalificacionesAsync(string CodigoISIN)
        {
            return await _context.TmpCargaExcelInversionesCalificaciones.Where(x => x.CodigoIsin == CodigoISIN)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
