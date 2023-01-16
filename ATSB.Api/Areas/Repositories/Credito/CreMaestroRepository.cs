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
using ATSB.Api.Models.Credito;
using ATSB.Api.Areas.Entities.Credito;

namespace ATSB.Api.Areas.Repositories.Credito
{
    public class CreMaestroRepository : ICreMaestroRepository
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IConsecutivoHelper _ConsecutivoHelper;

        public CreMaestroRepository
        (
            ATSBIdentityDbContext context,
            IConsecutivoHelper ConsecutivoHelper
        ) : base()

        {
            _context = context;
            _ConsecutivoHelper = ConsecutivoHelper;
        }

        public IQueryable GetCreMaestros()
        {
            return _context.CreMaestros
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation); //Empresa
        }
        
        public async Task<CreMaestro> GetCreMaestroAsync(int CodigoEmpresa, string NumeroOperacion)
        {
            return await _context.CreMaestros.Where(x => x.CodigoEmpresa == CodigoEmpresa && x.NumeroOperacion == NumeroOperacion)
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation) //Empresa
                .FirstOrDefaultAsync();
        }

        public async Task<Response<object>> AddCreMaestroAsync(CreMaestroRequest creMaestro)
        {
            try
            {
                var cremaestro = new CreMaestro
                {
                    CodigoEmpresa = creMaestro.CodigoEmpresa,
                    NumeroOperacion = creMaestro.NumeroOperacion,
                    CodigoCliente = creMaestro.CodigoCliente,
                    TipoCredito = creMaestro.TipoCredito,
                    NombreCliente = creMaestro.NombreCliente,
                    Tasa = creMaestro.Tasa,
                    FechaInicio = creMaestro.FechaInicio,
                    FechaVencimiento = creMaestro.FechaVencimiento,
                    Saldo = creMaestro.Saldo,
                    CodigoTipoGarantia = creMaestro.CodigoTipoGarantia,
                    CodigoClaseCredito = creMaestro.CodigoClaseCredito,
                    CodigoFormaPago = creMaestro.CodigoFormaPago,
                    Cuota = creMaestro.Cuota,
                    FechaRevisionTasa = creMaestro.FechaRevisionTasa,
                    CodigoTipoTasa = creMaestro.CodigoTipoTasa,
                    MontoApertura = creMaestro.MontoApertura,
                    FechaArchivo = creMaestro.FechaArchivo,
                    CodigoFacilidadCrediticia = creMaestro.CodigoFacilidadCrediticia,
                    CodigoTipoRelacion = creMaestro.CodigoTipoRelacion,
                    CodigoTipoActividad = creMaestro.CodigoTipoActividad,
                    IdUsuario = creMaestro.IdUsuario
                };

                _context.CreMaestros.Add(cremaestro);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "El maestro se creo con exito",
                    Result = cremaestro
                });
            }
            catch (System.Exception)
            {
                throw new Exception("El maestro no fue creado");
            }
        }

        public async Task<Response<object>> EditCreMaestroAsync(CreMaestroRequest creMaestro)
        {
            try
            {
                var exist = await _context.CreMaestros.AnyAsync(x => x.CodigoEmpresa == creMaestro.CodigoEmpresa && x.NumeroOperacion == creMaestro.NumeroOperacion);
                if (!exist)
                {
                    return (new Response<object>
                    {
                        IsSuccess = false,
                        Message = "Registro no encontrado",
                        Result = null
                    });
                }

                var cremaestro = new CreMaestro
                {
                    CodigoEmpresa = creMaestro.CodigoEmpresa,
                    NumeroOperacion = creMaestro.NumeroOperacion,
                    CodigoCliente = creMaestro.CodigoCliente,
                    TipoCredito = creMaestro.TipoCredito,
                    NombreCliente = creMaestro.NombreCliente,
                    Tasa = creMaestro.Tasa,
                    FechaInicio = creMaestro.FechaInicio,
                    FechaVencimiento = creMaestro.FechaVencimiento,
                    Saldo = creMaestro.Saldo,
                    CodigoTipoGarantia = creMaestro.CodigoTipoGarantia,
                    CodigoClaseCredito = creMaestro.CodigoClaseCredito,
                    CodigoFormaPago = creMaestro.CodigoFormaPago,
                    Cuota = creMaestro.Cuota,
                    FechaRevisionTasa = creMaestro.FechaRevisionTasa,
                    CodigoTipoTasa = creMaestro.CodigoTipoTasa,
                    MontoApertura = creMaestro.MontoApertura,
                    FechaArchivo = creMaestro.FechaArchivo,
                    CodigoFacilidadCrediticia = creMaestro.CodigoFacilidadCrediticia,
                    CodigoTipoRelacion = creMaestro.CodigoTipoRelacion,
                    CodigoTipoActividad = creMaestro.CodigoTipoActividad,
                    IdUsuario = creMaestro.IdUsuario
                };

                _context.Update(cremaestro);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "Registro actualizado",
                    Result = cremaestro
                });
            }
            catch (System.Exception)
            {
                throw new Exception("El maestro no fue modificado");
            }
        }

        public async Task<Response<object>> DeleteCreMaestroAsync(CreMaestroRequest creMaestro)
        {
            try
            {
                var existe = await _context.CreMaestros.AnyAsync(x => x.CodigoEmpresa == creMaestro.CodigoEmpresa && x.NumeroOperacion == creMaestro.NumeroOperacion);
                if (!existe)
                {
                    return (new Response<Object>
                    {
                        IsSuccess = false,
                        Message = "El registro no existe",
                        Result = null
                    });
                }

                _context.Remove(new CreMaestro() { CodigoEmpresa = creMaestro.CodigoEmpresa, NumeroOperacion = creMaestro.NumeroOperacion });
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "El maestro fue eliminado",
                    Result = creMaestro
                });
            }
            catch (System.Exception)
            {
                throw new Exception("No se pudo eliminar el maestro");
            }
        }
    }
}
