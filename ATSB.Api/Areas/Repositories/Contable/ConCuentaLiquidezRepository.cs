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
    public class ConCuentaLiquidezRepository : IConCuentaLiquidezRepository
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IConsecutivoHelper _ConsecutivoHelper;

        public ConCuentaLiquidezRepository
        (
            ATSBIdentityDbContext context,
            IConsecutivoHelper ConsecutivoHelper
        ) : base()

        {
            _context = context;
            _ConsecutivoHelper = ConsecutivoHelper;
        }

        public IQueryable GetConCuentasLiquidez()
        {
            return _context.ConCuentaliquidezs
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation) //Empresa
                .Include(cr => cr.Codigo); //CalificacionRiesgo

        }

        public async Task<ConCuentaliquidez> GetConCuentaLiquidezAsync(int CodigoEmpresa, int CuentaLiquidez, int CuentaContableLocal)
        {
            return await _context.ConCuentaliquidezs.Where(x => x.CodigoEmpresa == CodigoEmpresa && x.CuentaLiquidez == CuentaLiquidez && x.CuentaContableLocal == CuentaContableLocal)
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation) //Empresa
                .Include(cr => cr.Codigo) //CalificacionRiesgo
                .FirstOrDefaultAsync();
        }

        public async Task<Response<object>> AddConCuentaLiquidezAsync(ConCuentaLiquidezRequest conCuentaLiquidez)
        {
            try
            {

                var concuentaliquidez = new ConCuentaliquidez
                {
                    CodigoEmpresa = conCuentaLiquidez.CodigoEmpresa,
                    CuentaLiquidez = conCuentaLiquidez.CuentaLiquidez,
                    CuentaContableLocal = conCuentaLiquidez.CuentaContableLocal,
                    Agrupar = conCuentaLiquidez.Agrupar == "true" ? true : false,
                    Porcentaje = conCuentaLiquidez.Porcentaje,
                    FechaAdquisicion = conCuentaLiquidez.FechaAdquisicion,
                    NombreEnte = conCuentaLiquidez.NombreEnte,
                    DestinoLocalExtranjero = conCuentaLiquidez.DestinoLocalExtranjero,
                    CodigoPais = conCuentaLiquidez.CodigoPais,
                    CodigoRelacionBanco = conCuentaLiquidez.CodigoRelacionBanco,
                    CodigoCalificacionRiesgo = conCuentaLiquidez.CodigoCalificacionRiesgo,
                    Tasa = conCuentaLiquidez.Tasa,
                    CodigoEstado = conCuentaLiquidez.CodigoEstado == "true" ? true : false,
                    IdUsuario = conCuentaLiquidez.IdUsuario
                };

                _context.ConCuentaliquidezs.Add(concuentaliquidez);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "La cuenta liquidez se creo con exito",
                    Result = concuentaliquidez
                });
            }
            catch (System.Exception)
            {
                throw new Exception("La cuenta liquidez no fue creada");
            }
        }

        public async Task<Response<object>> EditConCuentaLiquidezAsync(ConCuentaLiquidezRequest conCuentaLiquidez)
        {
            try
            {
                var exist = await _context.ConCuentaliquidezs.AnyAsync(x => x.CodigoEmpresa == conCuentaLiquidez.CodigoEmpresa && x.CuentaLiquidez == conCuentaLiquidez.CuentaLiquidez && x.CuentaContableLocal == conCuentaLiquidez.CuentaContableLocal);
                if (!exist)
                {
                    return (new Response<object>
                    {
                        IsSuccess = false,
                        Message = "Registro no encontrado",
                        Result = null
                    });
                }

                var concuentaliquidez = new ConCuentaliquidez
                {
                    CodigoEmpresa = conCuentaLiquidez.CodigoEmpresa,
                    CuentaLiquidez = conCuentaLiquidez.CuentaLiquidez,
                    CuentaContableLocal = conCuentaLiquidez.CuentaContableLocal,
                    Agrupar = conCuentaLiquidez.Agrupar == "true" ? true : false,
                    Porcentaje = conCuentaLiquidez.Porcentaje,
                    FechaAdquisicion = conCuentaLiquidez.FechaAdquisicion,
                    NombreEnte = conCuentaLiquidez.NombreEnte,
                    DestinoLocalExtranjero = conCuentaLiquidez.DestinoLocalExtranjero,
                    CodigoPais = conCuentaLiquidez.CodigoPais,
                    CodigoRelacionBanco = conCuentaLiquidez.CodigoRelacionBanco,
                    CodigoCalificacionRiesgo = conCuentaLiquidez.CodigoCalificacionRiesgo,
                    Tasa = conCuentaLiquidez.Tasa,
                    CodigoEstado = conCuentaLiquidez.CodigoEstado == "true" ? true : false,
                    IdUsuario = conCuentaLiquidez.IdUsuario
                };

                _context.Update(concuentaliquidez);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "Registro actualizado",
                    Result = concuentaliquidez
                });
            }
            catch (System.Exception)
            {
                throw new Exception("La cuenta liquidez no fue modificada");
            }
        }

        public async Task<Response<object>> DeleteConCuentaLiquidezAsync(ConCuentaLiquidezRequest conCuentaLiquidez)
        {
            try
            {
                var existe = await _context.ConCuentaliquidezs.AnyAsync(x => x.CodigoEmpresa == conCuentaLiquidez.CodigoEmpresa && x.CuentaLiquidez == conCuentaLiquidez.CuentaLiquidez && x.CuentaContableLocal == conCuentaLiquidez.CuentaContableLocal);
                if (!existe)
                {
                    return (new Response<Object>
                    {
                        IsSuccess = false,
                        Message = "El registro no existe",
                        Result = null
                    });
                }

                _context.Remove(new ConCuentaliquidez() { CodigoEmpresa = conCuentaLiquidez.CodigoEmpresa, CuentaLiquidez = conCuentaLiquidez.CuentaLiquidez, CuentaContableLocal = conCuentaLiquidez.CuentaContableLocal });
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "La cuenta liquidez fue eliminada",
                    Result = conCuentaLiquidez
                });
            }
            catch (System.Exception)
            {
                throw new Exception("No se pudo eliminar la cuenta liquidez");
            }
        }
    }
}
