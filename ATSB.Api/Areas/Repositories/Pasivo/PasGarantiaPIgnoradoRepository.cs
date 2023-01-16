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
    public class PasGarantiaPIgnoradoRepository : IPasGarantiaPIgnoradoRepository
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IConsecutivoHelper _ConsecutivoHelper;

        public PasGarantiaPIgnoradoRepository
        (
            ATSBIdentityDbContext context,
            IConsecutivoHelper ConsecutivoHelper
        ) : base()

        {
            _context = context;
            _ConsecutivoHelper = ConsecutivoHelper;
        }

        public IQueryable GetPasGarantiasPIgnorado()
        {
            return _context.PasGarantiapignorados
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation) //Empresa
                .Include(s => s.CodigoEstadoNavigation); //Estado
        }
        
        public async Task<PasGarantiapignorado> GetPasGarantiaPIgnoradoAsync(int CodigoEmpresa, string NumeroCuenta, string NumeroOperacionGarantia)
        {
            return await _context.PasGarantiapignorados.Where(x => x.CodigoEmpresa == CodigoEmpresa && x.NumeroCuenta == NumeroCuenta && x.NumeroOperacionGarantia == NumeroOperacionGarantia)
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation) //Empresa
                .Include(s => s.CodigoEstadoNavigation) //Estado
                .FirstOrDefaultAsync();
        }

        public async Task<Response<object>> AddPasGarantiaPIgnoradoAsync(PasGarantiaPIgnoradoRequest pasGarantiaPIgnorado)
        {
            try
            {
                var pasgarantiapignorado = new PasGarantiapignorado
                {
                    CodigoEmpresa = pasGarantiaPIgnorado.CodigoEmpresa,
                    NumeroCuenta = pasGarantiaPIgnorado.NumeroCuenta,
                    NumeroOperacionGarantia = pasGarantiaPIgnorado.NumeroOperacionGarantia,
                    SaldoOperacionGarantia = pasGarantiaPIgnorado.SaldoOperacionGarantia,
                    FechaVencimientoOperacionGarantia = pasGarantiaPIgnorado.FechaVencimientoOperacionGarantia,
                    NumeroClienteOperacionGarantia = pasGarantiaPIgnorado.NumeroClienteOperacionGarantia,
                    Agrupa = pasGarantiaPIgnorado.Agrupa,
                    CodigoEstado = pasGarantiaPIgnorado.CodigoEstado,
                    IdUsuario = pasGarantiaPIgnorado.IdUsuario
                };

                _context.PasGarantiapignorados.Add(pasgarantiapignorado);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "La garantia se creo con exito",
                    Result = pasgarantiapignorado
                });
            }
            catch (System.Exception)
            {
                throw new Exception("La garantia no fue creada");
            }
        }

        public async Task<Response<object>> EditPasGarantiaPIgnoradoAsync(PasGarantiaPIgnoradoRequest pasGarantiaPIgnorado)
        {
            try
            {
                var exist = await _context.PasGarantiapignorados.AnyAsync(x => x.CodigoEmpresa == pasGarantiaPIgnorado.CodigoEmpresa && x.NumeroCuenta == pasGarantiaPIgnorado.NumeroCuenta && x.NumeroOperacionGarantia == pasGarantiaPIgnorado.NumeroOperacionGarantia);
                if (!exist)
                {
                    return (new Response<object>
                    {
                        IsSuccess = false,
                        Message = "Registro no encontrado",
                        Result = null
                    });
                }

                var pasgarantiapignorado = new PasGarantiapignorado
                {
                    CodigoEmpresa = pasGarantiaPIgnorado.CodigoEmpresa,
                    NumeroCuenta = pasGarantiaPIgnorado.NumeroCuenta,
                    NumeroOperacionGarantia = pasGarantiaPIgnorado.NumeroOperacionGarantia,
                    SaldoOperacionGarantia = pasGarantiaPIgnorado.SaldoOperacionGarantia,
                    FechaVencimientoOperacionGarantia = pasGarantiaPIgnorado.FechaVencimientoOperacionGarantia,
                    NumeroClienteOperacionGarantia = pasGarantiaPIgnorado.NumeroClienteOperacionGarantia,
                    Agrupa = pasGarantiaPIgnorado.Agrupa,
                    CodigoEstado = pasGarantiaPIgnorado.CodigoEstado,
                    IdUsuario = pasGarantiaPIgnorado.IdUsuario
                };

                _context.Update(pasgarantiapignorado);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "Registro actualizado",
                    Result = pasgarantiapignorado
                });
            }
            catch (System.Exception)
            {
                throw new Exception("La garantia no fue modificada");
            }
        }

        public async Task<Response<object>> DeletePasGarantiaPIgnoradoAsync(PasGarantiaPIgnoradoRequest pasGarantiaPIgnorado)
        {
            try
            {
                var existe = await _context.PasGarantiapignorados.AnyAsync(x => x.CodigoEmpresa == pasGarantiaPIgnorado.CodigoEmpresa && x.NumeroCuenta == pasGarantiaPIgnorado.NumeroCuenta && x.NumeroOperacionGarantia == pasGarantiaPIgnorado.NumeroOperacionGarantia);
                if (!existe)
                {
                    return (new Response<Object>
                    {
                        IsSuccess = false,
                        Message = "El registro no existe",
                        Result = null
                    });
                }

                _context.Remove(new PasGarantiapignorado() { CodigoEmpresa = pasGarantiaPIgnorado.CodigoEmpresa, NumeroCuenta = pasGarantiaPIgnorado.NumeroCuenta, NumeroOperacionGarantia = pasGarantiaPIgnorado.NumeroOperacionGarantia });
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "La garantia fue eliminada",
                    Result = pasGarantiaPIgnorado
                });
            }
            catch (System.Exception)
            {
                throw new Exception("No se pudo eliminar la garantia");
            }
        }
    }
}
