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
    public class TmpCargaTxtDepositoPlazoPIgnoradoRepository : ITmpCargaTxtDepositoPlazoPIgnoradoRepository
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IConsecutivoHelper _ConsecutivoHelper;

        public TmpCargaTxtDepositoPlazoPIgnoradoRepository
        (
            ATSBIdentityDbContext context,
            IConsecutivoHelper ConsecutivoHelper
        ) : base()

        {
            _context = context;
            _ConsecutivoHelper = ConsecutivoHelper;
        }

        public IQueryable GetTmpCargaTxtDepositoPlazosPIgnorados()
        {
            return _context.TmpCargaTxtDepositoplazopignorados
                .AsNoTracking()
                .Include(p => p.Codigo) //Proceso
                .Include(e => e.CodigoEmpresaNavigation); //Empresa
        }
        
        public async Task<TmpCargaTxtDepositoplazopignorado> GetTmpCargaTxtDepositoPlazoPIgnoradoAsync(int CodigoEmpresa, string NumeroCuenta)
        {
            return await _context.TmpCargaTxtDepositoplazopignorados.Where(x => x.CodigoEmpresa == CodigoEmpresa && x.NumeroCuenta == NumeroCuenta)
                .AsNoTracking()
                .Include(p => p.Codigo) //Proceso
                .Include(e => e.CodigoEmpresaNavigation)
                .FirstOrDefaultAsync();
        }

    }
}
