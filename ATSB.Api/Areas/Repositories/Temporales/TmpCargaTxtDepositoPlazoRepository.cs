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
    public class TmpCargaTxtDepositoPlazoRepository : ITmpCargaTxtDepositoPlazoRepository
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IConsecutivoHelper _ConsecutivoHelper;

        public TmpCargaTxtDepositoPlazoRepository
        (
            ATSBIdentityDbContext context,
            IConsecutivoHelper ConsecutivoHelper
        ) : base()

        {
            _context = context;
            _ConsecutivoHelper = ConsecutivoHelper;
        }

        public IQueryable GetTmpCargaTxtDepositoPlazos()
        {
            return _context.TmpCargaTxtDepositoplazos
                .AsNoTracking()
                .Include(p => p.Codigo) //Proceso
                .Include(e => e.CodigoEmpresaNavigation); //Empresa
        }

        public async Task<TmpCargaTxtDepositoplazo> GetTmpCargaTxtDepositoPlazoAsync(int CodigoEmpresa, string Cuenta)
        {
            return await _context.TmpCargaTxtDepositoplazos.Where(x => x.CodigoEmpresa == CodigoEmpresa && x.Cuenta == Cuenta)
                .AsNoTracking()
                .Include(p => p.Codigo) //Proceso
                .Include(e => e.CodigoEmpresaNavigation)
                .FirstOrDefaultAsync();
        }

    }
}
