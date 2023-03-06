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
    public class TmpCargaExcelCalificionRiesgoPaisRepository : ITmpCargaExcelCalificionRiesgoPaisRepository
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IConsecutivoHelper _ConsecutivoHelper;

        public TmpCargaExcelCalificionRiesgoPaisRepository
        (
            ATSBIdentityDbContext context,
            IConsecutivoHelper ConsecutivoHelper
        ) : base()

        {
            _context = context;
            _ConsecutivoHelper = ConsecutivoHelper;
        }

        public IQueryable GetTmpCargaExcelCalificionRiesgoPais()
        {
            return _context.TmpCargaExcelCalificionriesgopais
                .AsNoTracking();
        }

        public async Task<TmpCargaExcelCalificionriesgopai> GetTmpCargaExcelCalificionRiesgoPaisAsync(Guid Llave)
        {
            return await _context.TmpCargaExcelCalificionriesgopais.Where(x => x.Llave == Llave)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
