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
    public class TmpCargaExcelInversionesRepository : ITmpCargaExcelInversionesRepository
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IConsecutivoHelper _ConsecutivoHelper;

        public TmpCargaExcelInversionesRepository
        (
            ATSBIdentityDbContext context,
            IConsecutivoHelper ConsecutivoHelper
        ) : base()

        {
            _context = context;
            _ConsecutivoHelper = ConsecutivoHelper;
        }

        public IQueryable GetListaTmpCargaExcelInversiones()
        {
            return _context.TmpCargaExcelInversiones
                .AsNoTracking();
        }

        public async Task<TmpCargaExcelInversione> GetTmpCargaExcelInversionesAsync(Guid Llave)
        {
            return await _context.TmpCargaExcelInversiones.Where(x => x.Llave == Llave)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
