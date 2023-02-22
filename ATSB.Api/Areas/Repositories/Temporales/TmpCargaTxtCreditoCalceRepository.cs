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
    public class TmpCargaTxtCreditoCalceRepository : ITmpCargaTxtCreditoCalceRepository
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IConsecutivoHelper _ConsecutivoHelper;

        public TmpCargaTxtCreditoCalceRepository
        (
            ATSBIdentityDbContext context,
            IConsecutivoHelper ConsecutivoHelper
        ) : base()

        {
            _context = context;
            _ConsecutivoHelper = ConsecutivoHelper;
        }

        public IQueryable GetTmpCargaTxtCreditosCalce()
        {
            return _context.TmpCargaTxtCreditocalces
                .AsNoTracking()
                .Include(p => p.Codigo) //Proceso
                .Include(e => e.CodigoEmpresaNavigation); //Empresa
        }

        public async Task<TmpCargaTxtCreditocalce> GetTmpCargaTxtCreditoCalceAsync(int CodigoEmpresa, string CodigoTipo, string NumeroCredito)
        {
            return await _context.TmpCargaTxtCreditocalces.Where(x => x.CodigoEmpresa == CodigoEmpresa && x.CodigoTipo == CodigoTipo && x.NumeroCredito == NumeroCredito)
                .AsNoTracking()
                .Include(p => p.Codigo) //Proceso
                .Include(e => e.CodigoEmpresaNavigation)
                .FirstOrDefaultAsync();
        }

    }
}
