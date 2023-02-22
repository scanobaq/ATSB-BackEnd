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
    public class PasDetalleHistoricoRepository : IPasDetalleHistoricoRepository
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IConsecutivoHelper _ConsecutivoHelper;

        public PasDetalleHistoricoRepository
        (
            ATSBIdentityDbContext context,
            IConsecutivoHelper ConsecutivoHelper
        ) : base()

        {
            _context = context;
            _ConsecutivoHelper = ConsecutivoHelper;
        }

        public IQueryable GetPasDetallesHistoricos()
        {
            return _context.PasDetallehistoricos
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation); //Empresa
        }

        public async Task<PasDetallehistorico> GetPasDetalleHistoricoAsync(int CodigoEmpresa, string NumeroOperacion, string Fecha)
        {
            return await _context.PasDetallehistoricos.Where(x => x.CodigoEmpresa == CodigoEmpresa && x.NumeroOperacion == NumeroOperacion && x.Fecha == Fecha)
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation) //Empresa
                .FirstOrDefaultAsync();
        }

        public async Task<Response<object>> AddPasDetalleHistoricoAsync(PasDetalleHistoricoRequest pasDetalleHistorico)
        {
            try
            {
                var pasdetallehistorico = new PasDetallehistorico
                {
                    CodigoEmpresa = pasDetalleHistorico.CodigoEmpresa,
                    NumeroOperacion = pasDetalleHistorico.NumeroOperacion,
                    Fecha = pasDetalleHistorico.Fecha,
                    CodigoSubsidiaria = pasDetalleHistorico.CodigoSubsidiaria,
                    TipoDeposito = pasDetalleHistorico.TipoDeposito,
                    TipoCliente = pasDetalleHistorico.TipoCliente,
                    Tasa = pasDetalleHistorico.Tasa,
                    Destino = pasDetalleHistorico.Destino,
                    CodigoPais = pasDetalleHistorico.CodigoPais,
                    FechaInicio = pasDetalleHistorico.FechaInicio,
                    FechaVencimiento = pasDetalleHistorico.FechaVencimiento,
                    MontoPrincipal = pasDetalleHistorico.MontoPrincipal,
                    MontoPignorado = pasDetalleHistorico.MontoPignorado,
                    NumeroRenovaciones = pasDetalleHistorico.NumeroRenovaciones,
                    FechaRenovacion = pasDetalleHistorico.FechaRenovacion,
                    InteresPorPagar = pasDetalleHistorico.InteresPorPagar,
                    PeriodicidadPago = pasDetalleHistorico.PeriodicidadPago,
                    NombreCliente = pasDetalleHistorico.NombreCliente,
                    Plazo = pasDetalleHistorico.Plazo,
                    CodigoCliente = pasDetalleHistorico.CodigoCliente,
                    ClaseCliente = pasDetalleHistorico.ClaseCliente,
                    IdUsuario = pasDetalleHistorico.IdUsuario
                };

                _context.PasDetallehistoricos.Add(pasdetallehistorico);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "El detalle historico se creo con exito",
                    Result = pasdetallehistorico
                });
            }
            catch (System.Exception)
            {
                throw new Exception("El detalle historico no fue creado");
            }
        }

        public async Task<Response<object>> EditPasDetalleHistoricoAsync(PasDetalleHistoricoRequest pasDetalleHistorico)
        {
            try
            {
                var exist = await _context.PasDetallehistoricos.AnyAsync(x => x.CodigoEmpresa == pasDetalleHistorico.CodigoEmpresa && x.NumeroOperacion == pasDetalleHistorico.NumeroOperacion && x.Fecha == pasDetalleHistorico.Fecha);
                if (!exist)
                {
                    return (new Response<object>
                    {
                        IsSuccess = false,
                        Message = "Registro no encontrado",
                        Result = null
                    });
                }

                var pasdetallehistorico = new PasDetallehistorico
                {
                    CodigoEmpresa = pasDetalleHistorico.CodigoEmpresa,
                    NumeroOperacion = pasDetalleHistorico.NumeroOperacion,
                    Fecha = pasDetalleHistorico.Fecha,
                    CodigoSubsidiaria = pasDetalleHistorico.CodigoSubsidiaria,
                    TipoDeposito = pasDetalleHistorico.TipoDeposito,
                    TipoCliente = pasDetalleHistorico.TipoCliente,
                    Tasa = pasDetalleHistorico.Tasa,
                    Destino = pasDetalleHistorico.Destino,
                    CodigoPais = pasDetalleHistorico.CodigoPais,
                    FechaInicio = pasDetalleHistorico.FechaInicio,
                    FechaVencimiento = pasDetalleHistorico.FechaVencimiento,
                    MontoPrincipal = pasDetalleHistorico.MontoPrincipal,
                    MontoPignorado = pasDetalleHistorico.MontoPignorado,
                    NumeroRenovaciones = pasDetalleHistorico.NumeroRenovaciones,
                    FechaRenovacion = pasDetalleHistorico.FechaRenovacion,
                    InteresPorPagar = pasDetalleHistorico.InteresPorPagar,
                    PeriodicidadPago = pasDetalleHistorico.PeriodicidadPago,
                    NombreCliente = pasDetalleHistorico.NombreCliente,
                    Plazo = pasDetalleHistorico.Plazo,
                    CodigoCliente = pasDetalleHistorico.CodigoCliente,
                    ClaseCliente = pasDetalleHistorico.ClaseCliente,
                    IdUsuario = pasDetalleHistorico.IdUsuario
                };

                _context.Update(pasdetallehistorico);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "Registro actualizado",
                    Result = pasdetallehistorico
                });
            }
            catch (System.Exception)
            {
                throw new Exception("El detalle historico no fue modificado");
            }
        }

        public async Task<Response<object>> DeletePasDetalleHistoricoAsync(PasDetalleHistoricoRequest pasDetalleHistorico)
        {
            try
            {
                var existe = await _context.PasDetallehistoricos.AnyAsync(x => x.CodigoEmpresa == pasDetalleHistorico.CodigoEmpresa && x.NumeroOperacion == pasDetalleHistorico.NumeroOperacion && x.Fecha == pasDetalleHistorico.Fecha);
                if (!existe)
                {
                    return (new Response<Object>
                    {
                        IsSuccess = false,
                        Message = "El registro no existe",
                        Result = null
                    });
                }

                _context.Remove(new PasDetallehistorico() { CodigoEmpresa = pasDetalleHistorico.CodigoEmpresa, NumeroOperacion = pasDetalleHistorico.NumeroOperacion, Fecha = pasDetalleHistorico.Fecha });
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "El detalle historico fue eliminado",
                    Result = pasDetalleHistorico
                });
            }
            catch (System.Exception)
            {
                throw new Exception("No se pudo eliminar el detalle historico");
            }
        }
    }
}
