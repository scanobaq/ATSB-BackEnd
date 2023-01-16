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
using ATSB.Api.Areas.Entities.Parametros;
using ATSB.Api.Models.Seguridad;
using ATSB.Api.Areas.Entities.Seguridad;
using ATSB.Api.Areas.Entities.Credito;

namespace ATSB.Api.Areas.Repositories.Seguridad
{
    public class SegHistoricoPasswordRepository : ISegHistoricoPasswordRepository
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IConsecutivoHelper _ConsecutivoHelper;

        public SegHistoricoPasswordRepository
        (
            ATSBIdentityDbContext context,
            IConsecutivoHelper ConsecutivoHelper
        ) : base()

        {
            _context = context;
            _ConsecutivoHelper = ConsecutivoHelper;
        }

        public IQueryable GetSegHistoricosPassword()
        {
            return _context.SegHistoricopasswords
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation); //Empresa
        }

        public async Task<SegHistoricopassword> GetSegHistoricoPasswordAsync(int CodigoEmpresa, string idUsuario, DateTime FechaHoraCambio)
        {
            return await _context.SegHistoricopasswords.Where(x => x.CodigoEmpresa == CodigoEmpresa && x.IdUsuario == idUsuario && x.FechaHoraCambio == FechaHoraCambio)
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation) //Empresa
                .FirstOrDefaultAsync();
        }

        public async Task<Response<object>> AddSegHistoricoPasswordAsync(SegHistoricoPasswordRequest segHistoricoPassword)
        {
            try
            {
                var seghistoricopassword = new SegHistoricopassword
                {
                    CodigoEmpresa = segHistoricoPassword.CodigoEmpresa,
                    IdUsuario = segHistoricoPassword.IdUsuario,
                    FechaHoraCambio = segHistoricoPassword.FechaHoraCambio,
                    DescripcionPassword = segHistoricoPassword.DescripcionPassword
                };

                _context.SegHistoricopasswords.Add(seghistoricopassword);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "El historico password se creo con exito",
                    Result = seghistoricopassword
                });
            }
            catch (System.Exception)
            {
                throw new Exception("El historico password no fue creado");
            }
        }
    }
}
