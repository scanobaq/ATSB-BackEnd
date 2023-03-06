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
    public class TmpCargaExcelInversionesDefRepository : ITmpCargaExcelInversionesDefRepository
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IConsecutivoHelper _ConsecutivoHelper;

        public TmpCargaExcelInversionesDefRepository
        (
            ATSBIdentityDbContext context,
            IConsecutivoHelper ConsecutivoHelper
        ) : base()

        {
            _context = context;
            _ConsecutivoHelper = ConsecutivoHelper;
        }

        public IQueryable GetTmpCargaExcelInversionesDef()
        {
            return _context.TmpCargaExcelInversionesDefs
                .AsNoTracking();
        }

        public async Task<TmpCargaExcelInversionesDef> GetTmpCargaExcelInversionesDefAsync(Guid Llave)
        {
            return await _context.TmpCargaExcelInversionesDefs.Where(x => x.Llave == Llave)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
