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
    public class TmpCargaExcelCalificionRiesgoPaisDefRepository : ITmpCargaExcelCalificionRiesgoPaisDefRepository
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IConsecutivoHelper _ConsecutivoHelper;

        public TmpCargaExcelCalificionRiesgoPaisDefRepository
        (
            ATSBIdentityDbContext context,
            IConsecutivoHelper ConsecutivoHelper
        ) : base()

        {
            _context = context;
            _ConsecutivoHelper = ConsecutivoHelper;
        }

        public IQueryable GetTmpCargaExcelCalificionesRiesgoPaisDef()
        {
            return _context.TmpCargaExcelCalificionriesgopaisDefs
                .AsNoTracking();
        }

        public async Task<TmpCargaExcelCalificionriesgopaisDef> GetTmpCargaExcelCalificionRiesgoPaisDefAsync(Guid Llave)
        {
            return await _context.TmpCargaExcelCalificionriesgopaisDefs.Where(x => x.Llave == Llave)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
