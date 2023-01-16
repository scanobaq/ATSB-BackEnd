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
    public class ConCatalogoEquivalenciaRepository : IConCatalogoEquivalenciaRepository
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IConsecutivoHelper _ConsecutivoHelper;

        public ConCatalogoEquivalenciaRepository
        (
            ATSBIdentityDbContext context,
            IConsecutivoHelper ConsecutivoHelper
        ) : base()

        {
            _context = context;
            _ConsecutivoHelper = ConsecutivoHelper;
        }

        public IQueryable GetConCatalogosEquivalencia()
        {
            return _context.ConCatalogoequivalencia
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation) //Empresa
                .Include(tc => tc.Codigo); //TipoCuenta
        }

        public async Task<ConCatalogoequivalencium> GetConCatalogoEquivalenciaAsync(int CodigoEmpresa, int IdCuenta)
        {
            return await _context.ConCatalogoequivalencia.Where(x => x.CodigoEmpresa == CodigoEmpresa && x.IdCuenta == IdCuenta)
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation) //Empresa
                .Include(tc => tc.Codigo) //TipoCuenta
                .FirstOrDefaultAsync();
        }
        
        public async Task<Response<object>> AddConCatalogoEquivalenciaAsync(ConCatalogoEquivalenciaRequest conCatalogoEquivalencia)
        {
            try
            {

                var update = await _ConsecutivoHelper.updateConsecutivo(conCatalogoEquivalencia.CodigoEmpresa, "CON_CATALOGOEQUIVALENCIA");
                int consecutivo = await _ConsecutivoHelper.GetConsecutivo(conCatalogoEquivalencia.CodigoEmpresa, "CON_CATALOGOEQUIVALENCIA");

                var concatalogoequivalencia = new ConCatalogoequivalencium
                {
                    CodigoEmpresa = conCatalogoEquivalencia.CodigoEmpresa,
                    IdCuenta = consecutivo,
                    CuentaContableLocal = conCatalogoEquivalencia.CuentaContableLocal,
                    CuentaContableAnteriorSuperIntendencia = conCatalogoEquivalencia.CuentaContableAnteriorSuperIntendencia,
                    NombreCuenta = conCatalogoEquivalencia.NombreCuenta,
                    CodigoTipo = conCatalogoEquivalencia.CodigoTipo,
                    Destino = conCatalogoEquivalencia.Destino,
                    CodigoPais = conCatalogoEquivalencia.CodigoPais,
                    CuentaContableSuperIntendencia = conCatalogoEquivalencia.CuentaContableSuperIntendencia,
                    IdUsuario = conCatalogoEquivalencia.IdUsuario
                };

                _context.ConCatalogoequivalencia.Add(concatalogoequivalencia);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "El catalogo equivalencia se creo con exito",
                    Result = concatalogoequivalencia
                });
            }
            catch (System.Exception)
            {
                throw new Exception("El catalogo equivalencia no fue creado");
            }
        }

        public async Task<Response<object>> EditConCatalogoEquivalenciaAsync(ConCatalogoEquivalenciaRequest conCatalogoEquivalencia)
        {
            try
            {
                var exist = await _context.ConCatalogoequivalencia.AnyAsync(x => x.CodigoEmpresa == conCatalogoEquivalencia.CodigoEmpresa && x.IdCuenta == conCatalogoEquivalencia.IdCuenta);
                if (!exist)
                {
                    return (new Response<object>
                    {
                        IsSuccess = false,
                        Message = "Registro no encontrado",
                        Result = null
                    });
                }

                var concatalogoequivalencia = new ConCatalogoequivalencium
                {
                    CodigoEmpresa = conCatalogoEquivalencia.CodigoEmpresa,
                    IdCuenta = conCatalogoEquivalencia.IdCuenta,
                    CuentaContableLocal = conCatalogoEquivalencia.CuentaContableLocal,
                    CuentaContableAnteriorSuperIntendencia = conCatalogoEquivalencia.CuentaContableAnteriorSuperIntendencia,
                    NombreCuenta = conCatalogoEquivalencia.NombreCuenta,
                    CodigoTipo = conCatalogoEquivalencia.CodigoTipo,
                    Destino = conCatalogoEquivalencia.Destino,
                    CodigoPais = conCatalogoEquivalencia.CodigoPais,
                    CuentaContableSuperIntendencia = conCatalogoEquivalencia.CuentaContableSuperIntendencia,
                    IdUsuario = conCatalogoEquivalencia.IdUsuario
                };

                _context.Update(concatalogoequivalencia);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "Registro actualizado",
                    Result = concatalogoequivalencia
                });
            }
            catch (System.Exception)
            {
                throw new Exception("El catalogo equivalencia no fue modificado");
            }
        }

        public async Task<Response<object>> DeleteConCatalogoEquivalenciaAsync(ConCatalogoEquivalenciaRequest conCatalogoEquivalencia)
        {
            try
            {
                var existe = await _context.ConCatalogoequivalencia.AnyAsync(x => x.CodigoEmpresa == conCatalogoEquivalencia.CodigoEmpresa && x.IdCuenta == conCatalogoEquivalencia.IdCuenta);
                if (!existe)
                {
                    return (new Response<Object>
                    {
                        IsSuccess = false,
                        Message = "El registro no existe",
                        Result = null
                    });
                }

                _context.Remove(new ConCatalogoequivalencium() { CodigoEmpresa = conCatalogoEquivalencia.CodigoEmpresa, IdCuenta = conCatalogoEquivalencia.IdCuenta });
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "El catalogo equivalencia fue eliminado",
                    Result = conCatalogoEquivalencia
                });
            }
            catch (System.Exception)
            {
                throw new Exception("No se pudo eliminar el catalogo equivalencia");
            }
        }
    }
}
