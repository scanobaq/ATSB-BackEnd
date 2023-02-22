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
    public class TmpCargaTxtCreditoRepository : ITmpCargaTxtCreditoRepository
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IConsecutivoHelper _ConsecutivoHelper;

        public TmpCargaTxtCreditoRepository
        (
            ATSBIdentityDbContext context,
            IConsecutivoHelper ConsecutivoHelper
        ) : base()

        {
            _context = context;
            _ConsecutivoHelper = ConsecutivoHelper;
        }

        public IQueryable GetTmpCargaTxtCreditos()
        {
            return _context.TmpCargaTxtCreditos
                .AsNoTracking()
                .Include(p => p.Codigo) //Proceso
                .Include(e => e.CodigoEmpresaNavigation); //Empresa
        }

        public async Task<TmpCargaTxtCredito> GetTmpCargaTxtCreditoAsync(int CodigoEmpresa, string NumeroOperacion)
        {
            return await _context.TmpCargaTxtCreditos.Where(x => x.CodigoEmpresa == CodigoEmpresa && x.NumeroOperacion == NumeroOperacion)
                .AsNoTracking()
                .Include(p => p.Codigo) //Proceso
                .Include(e => e.CodigoEmpresaNavigation)
                .FirstOrDefaultAsync();
        }

    }
}
