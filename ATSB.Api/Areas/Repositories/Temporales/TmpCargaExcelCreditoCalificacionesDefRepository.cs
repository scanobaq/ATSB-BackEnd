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
    public class TmpCargaExcelCreditoCalificacionesDefRepository : ITmpCargaExcelCreditoCalificacionesDefRepository
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IConsecutivoHelper _ConsecutivoHelper;

        public TmpCargaExcelCreditoCalificacionesDefRepository
        (
            ATSBIdentityDbContext context,
            IConsecutivoHelper ConsecutivoHelper
        ) : base()

        {
            _context = context;
            _ConsecutivoHelper = ConsecutivoHelper;
        }

        public IQueryable GetTmpCargaExcelCreditosCalificacionesDef()
        {
            return _context.TmpCargaExcelCreditoCalificacionesDefs
                .AsNoTracking();
        }

        public async Task<TmpCargaExcelCreditoCalificacionesDef> GetTmpCargaExcelCreditoCalificacionesDefAsync(string NumOper)
        {
            return await _context.TmpCargaExcelCreditoCalificacionesDefs.Where(x => x.NumOper == NumOper)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

    }
}
