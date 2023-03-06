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
    public class TmpCargaExcelMaestroTcRepository : ITmpCargaExcelMaestroTcRepository
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IConsecutivoHelper _ConsecutivoHelper;

        public TmpCargaExcelMaestroTcRepository
        (
            ATSBIdentityDbContext context,
            IConsecutivoHelper ConsecutivoHelper
        ) : base()

        {
            _context = context;
            _ConsecutivoHelper = ConsecutivoHelper;
        }

        public IQueryable GetTmpCargaExcelMaestrosTc()
        {
            return _context.TmpCargaExcelMaestroTcs
                .AsNoTracking();
        }

        public async Task<TmpCargaExcelMaestroTc> GetTmpCargaExcelMaestroTcAsync(string NumeroTarjeta)
        {
            return await _context.TmpCargaExcelMaestroTcs.Where(x => x.NumeroTarjeta == NumeroTarjeta)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
