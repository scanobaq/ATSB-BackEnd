using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATSB.Api.Models.Configuracion;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ATSB.Api.Areas.Identity.Data;
using ATSB.Models;
using ATSB.Api.Areas.Entities.Configuracion;
using ATSB.Api.Helpers;
using ATSB.Api.Areas.Entities.Contable;
using ATSB.Api.Models.Contable;

namespace ATSB.Api.Areas.Repositories.Contable
{
    public class ConBalanceComparativoRepository : IConBalanceComparativoRepository
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IConsecutivoHelper _ConsecutivoHelper;

        public ConBalanceComparativoRepository
        (
            ATSBIdentityDbContext context,
            IConsecutivoHelper ConsecutivoHelper
        ) : base()

        {
            _context = context;
            _ConsecutivoHelper = ConsecutivoHelper;
        }

        public IQueryable GetConBalancesComparativos()
        {
            return _context.ConBalancecomparativos
                .AsNoTracking()
                .Include(tc => tc.Codigo) //TipoCuenta
                .Include(e => e.CodigoEmpresaNavigation); //Empresa
        }

        public async Task<ConBalancecomparativo> GetConBalanceComparativoAsync(Guid Llave)
        {
            return await _context.ConBalancecomparativos.Where(x => x.Llave == Llave)
                .AsNoTracking()
                .Include(tc => tc.Codigo) //TipoCuenta
                .Include(e => e.CodigoEmpresaNavigation) //Empresa
                .FirstOrDefaultAsync();
        }
    }
}
