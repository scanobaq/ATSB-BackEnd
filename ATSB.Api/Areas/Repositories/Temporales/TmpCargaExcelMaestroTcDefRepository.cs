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
    public class TmpCargaExcelMaestroTcDefRepository : ITmpCargaExcelMaestroTcDefRepository
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IConsecutivoHelper _ConsecutivoHelper;

        public TmpCargaExcelMaestroTcDefRepository
        (
            ATSBIdentityDbContext context,
            IConsecutivoHelper ConsecutivoHelper
        ) : base()

        {
            _context = context;
            _ConsecutivoHelper = ConsecutivoHelper;
        }

        public IQueryable GetTmpCargaExcelMaestrosTcDef()
        {
            return _context.TmpCargaExcelMaestroTcDefs
                .AsNoTracking();
        }

        public async Task<TmpCargaExcelMaestroTcDef> GetTmpCargaExcelMaestroTcDefAsync(string NumeroTarjeta)
        {
            return await _context.TmpCargaExcelMaestroTcDefs.Where(x => x.NumeroTarjeta == NumeroTarjeta)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
