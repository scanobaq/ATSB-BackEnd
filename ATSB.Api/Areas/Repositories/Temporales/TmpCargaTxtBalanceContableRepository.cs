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
    public class TmpCargaTxtBalanceContableRepository : ITmpCargaTxtBalanceContableRepository
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IConsecutivoHelper _ConsecutivoHelper;

        public TmpCargaTxtBalanceContableRepository
        (
            ATSBIdentityDbContext context,
            IConsecutivoHelper ConsecutivoHelper
        ) : base()

        {
            _context = context;
            _ConsecutivoHelper = ConsecutivoHelper;
        }

        public IQueryable GetTmpCargaTxtBalancesContables()
        {
            return _context.TmpCargaTxtBalancecontables
                .AsNoTracking()
                .Include(p => p.Codigo) //Proceso
                .Include(e => e.CodigoEmpresaNavigation); //Empresa
        }

        public async Task<TmpCargaTxtBalancecontable> GetTmpCargaTxtBalanceContableAsync(int CodigoEmpresa, string Fecha, string Cuenta)
        {
            return await _context.TmpCargaTxtBalancecontables.Where(x => x.CodigoEmpresa == CodigoEmpresa && x.Fecha == Fecha && x.Cuenta == Cuenta)
                .AsNoTracking()
                .Include(p => p.Codigo) //Proceso
                .Include(e => e.CodigoEmpresaNavigation)
                .FirstOrDefaultAsync();
        }

    }
}
