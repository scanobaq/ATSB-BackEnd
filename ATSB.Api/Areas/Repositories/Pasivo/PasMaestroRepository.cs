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
    public class PasMaestroRepository : IPasMaestroRepository
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IConsecutivoHelper _ConsecutivoHelper;

        public PasMaestroRepository
        (
            ATSBIdentityDbContext context,
            IConsecutivoHelper ConsecutivoHelper
        ) : base()

        {
            _context = context;
            _ConsecutivoHelper = ConsecutivoHelper;
        }

        public IQueryable GetPasMaestros()
        {
            return _context.PasMaestros
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation); //Empresa
        }

        public async Task<PasMaestro> GetPasMaestroAsync(int CodigoEmpresa, string NumeroCuenta)
        {
            return await _context.PasMaestros.Where(x => x.CodigoEmpresa == CodigoEmpresa && x.NumeroCuenta == NumeroCuenta)
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation) //Empresa
                .FirstOrDefaultAsync();
        }
        
        public async Task<Response<object>> AddPasMaestroAsync(PasMaestroRequest pasMaestro)
        {
            try
            {
                var pasmaestro = new PasMaestro
                {
                    CodigoEmpresa = pasMaestro.CodigoEmpresa,
                    NumeroCuenta = pasMaestro.NumeroCuenta,
                    CodigoTipoDeposito = pasMaestro.CodigoTipoDeposito,
                    CodigoTipoCliente = pasMaestro.CodigoTipoCliente,
                    DestinoLocalExtranjero = pasMaestro.DestinoLocalExtranjero,
                    CodigoPais = pasMaestro.CodigoPais,
                    FechaInicioReal = pasMaestro.FechaInicioReal,
                    FechaInicio = pasMaestro.FechaInicio,
                    IndicadorRelacionBanco = pasMaestro.IndicadorRelacionBanco,
                    IdUsuario = pasMaestro.IdUsuario,
                    FechaArchivo = pasMaestro.FechaArchivo
                };

                _context.PasMaestros.Add(pasmaestro);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "El maestro se creo con exito",
                    Result = pasmaestro
                });
            }
            catch (System.Exception)
            {
                throw new Exception("El maestro no fue creado");
            }
        }
        
        public async Task<Response<object>> EditPasMaestroAsync(PasMaestroRequest pasMaestro)
        {
            try
            {
                var exist = await _context.PasMaestros.AnyAsync(x => x.CodigoEmpresa == pasMaestro.CodigoEmpresa && x.NumeroCuenta == pasMaestro.NumeroCuenta);
                if (!exist)
                {
                    return (new Response<object>
                    {
                        IsSuccess = false,
                        Message = "Registro no encontrado",
                        Result = null
                    });
                }

                var pasmaestro = new PasMaestro
                {
                    CodigoEmpresa = pasMaestro.CodigoEmpresa,
                    NumeroCuenta = pasMaestro.NumeroCuenta,
                    CodigoTipoDeposito = pasMaestro.CodigoTipoDeposito,
                    CodigoTipoCliente = pasMaestro.CodigoTipoCliente,
                    DestinoLocalExtranjero = pasMaestro.DestinoLocalExtranjero,
                    CodigoPais = pasMaestro.CodigoPais,
                    FechaInicioReal = pasMaestro.FechaInicioReal,
                    FechaInicio = pasMaestro.FechaInicio,
                    IndicadorRelacionBanco = pasMaestro.IndicadorRelacionBanco,
                    IdUsuario = pasMaestro.IdUsuario,
                    FechaArchivo = pasMaestro.FechaArchivo
                };

                _context.Update(pasmaestro);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "Registro actualizado",
                    Result = pasmaestro
                });
            }
            catch (System.Exception)
            {
                throw new Exception("El maestro no fue modificado");
            }
        }

        public async Task<Response<object>> DeletePasMaestroAsync(PasMaestroRequest pasMaestro)
        {
            try
            {
                var existe = await _context.PasMaestros.AnyAsync(x => x.CodigoEmpresa == pasMaestro.CodigoEmpresa && x.NumeroCuenta == pasMaestro.NumeroCuenta);
                if (!existe)
                {
                    return (new Response<Object>
                    {
                        IsSuccess = false,
                        Message = "El registro no existe",
                        Result = null
                    });
                }

                _context.Remove(new PasMaestro() { CodigoEmpresa = pasMaestro.CodigoEmpresa, NumeroCuenta = pasMaestro.NumeroCuenta });
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "El maestro fue eliminado",
                    Result = pasMaestro
                });
            }
            catch (System.Exception)
            {
                throw new Exception("No se pudo eliminar el maestro");
            }
        }
    }
}
