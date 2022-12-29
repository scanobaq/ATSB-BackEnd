using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using ATSB.Api.Areas.Identity.Data;

namespace ATSB.Api.Helpers
{
    public class ConsecutivoHelper : IConsecutivoHelper
    {
        private readonly ATSBIdentityDbContext _context;
        public ConsecutivoHelper(ATSBIdentityDbContext dbcontext)
        {
            _context = dbcontext;
        }

        public async Task<int> GetConsecutivo(int CodigoEmpresa, string IdConsecutivo)
        {
            var parConsecutivo = await _context.ParConsecutivos.Where(x => x.CodigoEmpresa == CodigoEmpresa && x.IdConsecutivo == IdConsecutivo).FirstOrDefaultAsync();
            return parConsecutivo.NumeroConsecutivo;
        }

        public async Task<bool> updateConsecutivo(int CodigoEmpresa, string IdConsecutivo)
        {
            var oldconsecutivo = await _context.ParConsecutivos.Where(x => x.CodigoEmpresa == CodigoEmpresa && x.IdConsecutivo == IdConsecutivo).FirstOrDefaultAsync();
            // var newconsecutivo = new ParConsecutivo();
            oldconsecutivo.NumeroConsecutivo = oldconsecutivo.NumeroConsecutivo + 1;
            // newconsecutivo = oldconsecutivo;

            _context.ParConsecutivos.Update(oldconsecutivo);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
