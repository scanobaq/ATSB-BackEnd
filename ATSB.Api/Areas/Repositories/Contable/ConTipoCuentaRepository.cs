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
    public class ConTipoCuentaRepository : IConTipoCuentaRepository
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IConsecutivoHelper _ConsecutivoHelper;

        public ConTipoCuentaRepository
        (
            ATSBIdentityDbContext context,
            IConsecutivoHelper ConsecutivoHelper
        ) : base()

        {
            _context = context;
            _ConsecutivoHelper = ConsecutivoHelper;
        }

        public IQueryable GetConTiposCuenta()
        {
            return _context.ConTipocuenta
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation); //Empresa
        }

        public async Task<ConTipocuentum> GetConTipoCuentaAsync(int CodigoEmpresa, int CodigoTipo)
        {
            return await _context.ConTipocuenta.Where(x => x.CodigoEmpresa == CodigoEmpresa && x.CodigoTipo == CodigoTipo)
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation) //Empresa
                .FirstOrDefaultAsync();
        }
        
        public async Task<Response<object>> AddConTipoCuentaAsync(ConTipoCuentaRequest conTipoCuenta)
        {
            try
            {

                var update = await _ConsecutivoHelper.updateConsecutivo(conTipoCuenta.CodigoEmpresa, "CON_TIPOCUENTA");
                int consecutivo = await _ConsecutivoHelper.GetConsecutivo(conTipoCuenta.CodigoEmpresa, "CON_TIPOCUENTA");

                var contipocuenta = new ConTipocuentum
                {
                    CodigoEmpresa = conTipoCuenta.CodigoEmpresa,
                    CodigoTipo = consecutivo,
                    Descripcion = conTipoCuenta.Descripcion,
                    IdUsuario = conTipoCuenta.IdUsuario
                };

                _context.ConTipocuenta.Add(contipocuenta);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "El tipo cuenta se creo con exito",
                    Result = contipocuenta
                });
            }
            catch (System.Exception)
            {
                throw new Exception("El tipo cuenta no fue creado");
            }
        }

        public async Task<Response<object>> EditConTipoCuentaAsync(ConTipoCuentaRequest conTipoCuenta)
        {
            try
            {
                var exist = await _context.ConTipocuenta.AnyAsync(x => x.CodigoEmpresa == conTipoCuenta.CodigoEmpresa && x.CodigoTipo == conTipoCuenta.CodigoTipo);
                if (!exist)
                {
                    return (new Response<object>
                    {
                        IsSuccess = false,
                        Message = "Registro no encontrado",
                        Result = null
                    });
                }

                var contipocuenta = new ConTipocuentum
                {
                    CodigoEmpresa = conTipoCuenta.CodigoEmpresa,
                    CodigoTipo = conTipoCuenta.CodigoTipo,
                    Descripcion = conTipoCuenta.Descripcion,
                    IdUsuario = conTipoCuenta.IdUsuario
                };

                _context.Update(contipocuenta);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "Registro actualizado",
                    Result = contipocuenta
                });
            }
            catch (System.Exception)
            {
                throw new Exception("El tipo cuenta no fue modificado");
            }
        }

        public async Task<Response<object>> DeleteConTipoCuentaAsync(ConTipoCuentaRequest conTipoCuenta)
        {
            try
            {
                var existe = await _context.ConTipocuenta.AnyAsync(x => x.CodigoEmpresa == conTipoCuenta.CodigoEmpresa && x.CodigoTipo == conTipoCuenta.CodigoTipo);
                if (!existe)
                {
                    return (new Response<Object>
                    {
                        IsSuccess = false,
                        Message = "El registro no existe",
                        Result = null
                    });
                }

                _context.Remove(new ConTipocuentum() { CodigoEmpresa = conTipoCuenta.CodigoEmpresa, CodigoTipo = conTipoCuenta.CodigoTipo });
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "El tipo cuenta fue eliminado",
                    Result = conTipoCuenta
                });
            }
            catch (System.Exception)
            {
                throw new Exception("No se pudo eliminar el tipo cuenta");
            }
        }
    }
}
