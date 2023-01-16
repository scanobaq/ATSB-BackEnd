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
using ATSB.Api.Models.Pasivo;
using ATSB.Api.Areas.Entities.Pasivo;
using ATSB.Api.Areas.Entities.Credito;

namespace ATSB.Api.Areas.Repositories.Pasivo
{
    public class PasCuentaLiquidezRepository : IPasCuentaLiquidezRepository
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IConsecutivoHelper _ConsecutivoHelper;

        public PasCuentaLiquidezRepository
        (
            ATSBIdentityDbContext context,
            IConsecutivoHelper ConsecutivoHelper
        ) : base()

        {
            _context = context;
            _ConsecutivoHelper = ConsecutivoHelper;
        }

        public IQueryable GetPasCuentasLiquidez()
        {
            return _context.PasCuentaliquidezs
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation); //Empresa
        }

        public async Task<PasCuentaliquidez> GetPasCuentaLiquidezAsync(int CodigoEmpresa, int TipoDeposito, int TipoCliente, int CodigoCuentaLiquidez, string DestinoLocalExtranjero)
        {
            return await _context.PasCuentaliquidezs.Where(x => x.CodigoEmpresa == CodigoEmpresa && x.TipoDeposito == TipoDeposito && x.TipoCliente == TipoCliente && x.CodigoCuentaLiquidez == CodigoCuentaLiquidez && x.DestinoLocalExtranjero == DestinoLocalExtranjero)
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation) //Empresa
                .FirstOrDefaultAsync();
        }

        public async Task<Response<object>> AddPasCuentaLiquidezAsync(PasCuentaLiquidezRequest pasCuentaLiquidez)
        {
            try
            {
                var pascuentaliquidez = new PasCuentaliquidez
                {
                    CodigoEmpresa = pasCuentaLiquidez.CodigoEmpresa,
                    TipoDeposito = pasCuentaLiquidez.TipoDeposito,
                    TipoCliente = pasCuentaLiquidez.TipoCliente,
                    CodigoCuentaLiquidez = pasCuentaLiquidez.CodigoCuentaLiquidez,
                    DestinoLocalExtranjero = pasCuentaLiquidez.DestinoLocalExtranjero,
                    DiasRango1 = pasCuentaLiquidez.DiasRango1,
                    DiasRango2 = pasCuentaLiquidez.DiasRango2,
                    IdUsuario = pasCuentaLiquidez.IdUsuario
                };

                _context.PasCuentaliquidezs.Add(pascuentaliquidez);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "La cuenta liquidez se creo con exito",
                    Result = pascuentaliquidez
                });
            }
            catch (System.Exception)
            {
                throw new Exception("La cuenta liquidez no fue creada");
            }
        }

        public async Task<Response<object>> EditPasCuentaLiquidezAsync(PasCuentaLiquidezRequest pasCuentaLiquidez)
        {
            try
            {
                var exist = await _context.PasCuentaliquidezs.AnyAsync(x => x.CodigoEmpresa == pasCuentaLiquidez.CodigoEmpresa && x.TipoDeposito == pasCuentaLiquidez.TipoDeposito && x.TipoCliente == pasCuentaLiquidez.TipoCliente && x.CodigoCuentaLiquidez == pasCuentaLiquidez.CodigoCuentaLiquidez && x.DestinoLocalExtranjero == pasCuentaLiquidez.DestinoLocalExtranjero);
                if (!exist)
                {
                    return (new Response<object>
                    {
                        IsSuccess = false,
                        Message = "Registro no encontrado",
                        Result = null
                    });
                }

                var pascuentaliquidez = new PasCuentaliquidez
                {
                    CodigoEmpresa = pasCuentaLiquidez.CodigoEmpresa,
                    TipoDeposito = pasCuentaLiquidez.TipoDeposito,
                    TipoCliente = pasCuentaLiquidez.TipoCliente,
                    CodigoCuentaLiquidez = pasCuentaLiquidez.CodigoCuentaLiquidez,
                    DestinoLocalExtranjero = pasCuentaLiquidez.DestinoLocalExtranjero,
                    DiasRango1 = pasCuentaLiquidez.DiasRango1,
                    DiasRango2 = pasCuentaLiquidez.DiasRango2,
                    IdUsuario = pasCuentaLiquidez.IdUsuario
                };

                _context.Update(pascuentaliquidez);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "Registro actualizado",
                    Result = pascuentaliquidez
                });
            }
            catch (System.Exception)
            {
                throw new Exception("La cuenta liquidez no fue modificada");
            }
        }

        public async Task<Response<object>> DeletePasCuentaLiquidezAsync(PasCuentaLiquidezRequest pasCuentaLiquidez)
        {
            try
            {
                var existe = await _context.PasCuentaliquidezs.AnyAsync(x => x.CodigoEmpresa == pasCuentaLiquidez.CodigoEmpresa && x.TipoDeposito == pasCuentaLiquidez.TipoDeposito && x.TipoCliente == pasCuentaLiquidez.TipoCliente && x.CodigoCuentaLiquidez == pasCuentaLiquidez.CodigoCuentaLiquidez && x.DestinoLocalExtranjero == pasCuentaLiquidez.DestinoLocalExtranjero);
                if (!existe)
                {
                    return (new Response<Object>
                    {
                        IsSuccess = false,
                        Message = "El registro no existe",
                        Result = null
                    });
                }

                _context.Remove(new PasCuentaliquidez() { CodigoEmpresa = pasCuentaLiquidez.CodigoEmpresa, TipoDeposito = pasCuentaLiquidez.TipoDeposito, TipoCliente = pasCuentaLiquidez.TipoCliente, CodigoCuentaLiquidez = pasCuentaLiquidez.CodigoCuentaLiquidez, DestinoLocalExtranjero = pasCuentaLiquidez.DestinoLocalExtranjero });
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "La cuenta liquidez fue eliminada",
                    Result = pasCuentaLiquidez
                });
            }
            catch (System.Exception)
            {
                throw new Exception("No se pudo eliminar la cuenta liquidez");
            }
        }
    }
}
