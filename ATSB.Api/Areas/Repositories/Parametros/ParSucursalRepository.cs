using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATSB.Api.Models.Parametros;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ATSB.Api.Areas.Identity.Data;
using ATSB.Models;
using ATSB.Api.Areas.Entities.Parametros;
using ATSB.Api.Helpers;

namespace ATSB.Api.Areas.Repositories.Parametros
{
    public class ParSucursalRepository : IParSucursalRepository
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IConsecutivoHelper _ConsecutivoHelper;

        public ParSucursalRepository
        (
            ATSBIdentityDbContext context,
            IConsecutivoHelper ConsecutivoHelper
        ) : base()

        {
            _context = context;
            _ConsecutivoHelper = ConsecutivoHelper;
        }

        public IQueryable GetParSucursales()
        {
            return _context.ParSucursals
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation) //Empresa
                .Include(s => s.CodigoEstadoNavigation); //Estado
        }

        public async Task<ParSucursal> GetParSucursalAsync(int CodigoEmpresa, int CodigoBanco, int CodigoSucursal)
        {
            return await _context.ParSucursals.Where(x => x.CodigoEmpresa == CodigoEmpresa && x.CodigoBanco == CodigoBanco && x.CodigoSucursal == CodigoSucursal)
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation) //Empresa
                .Include(s => s.CodigoEstadoNavigation) //Estado
                .FirstOrDefaultAsync();
        }

        public async Task<Response<object>> AddParSucursalAsync(ParSucursalRequest parSucursal)
        {
            try
            {
                var update = await _ConsecutivoHelper.updateConsecutivo(parSucursal.CodigoEmpresa, "PAR_SUCURSAL");
                int consecutivo = await _ConsecutivoHelper.GetConsecutivo(parSucursal.CodigoEmpresa, "PAR_SUCURSAL");

                var parsucursal = new ParSucursal
                {
                    CodigoEmpresa = parSucursal.CodigoEmpresa,
                    CodigoBanco = parSucursal.CodigoBanco,
                    CodigoSucursal = consecutivo,
                    NombreSucursal = parSucursal.NombreSucursal,
                    CodigoSubsidiaria = parSucursal.CodigoSubsidiaria,
                    CodigoOrigen = parSucursal.CodigoOrigen,
                    CodigoPais = parSucursal.CodigoPais,
                    TipoEstablecimiento = parSucursal.TipoEstablecimiento,
                    Direccion = parSucursal.Direccion,
                    Telefono1 = parSucursal.Telefono1,
                    Encargado = parSucursal.Encargado,
                    Telefono2 = parSucursal.Telefono2,
                    Fax = parSucursal.Fax,
                    NombreResponsable = parSucursal.NombreResponsable,
                    CargoResposable = parSucursal.CargoResposable,
                    CodigoEstado = parSucursal.CodigoEstado,
                    IdUsuario = parSucursal.IdUsuario
                };

                _context.ParSucursals.Add(parsucursal);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "La sucursal se creo con exito",
                    Result = parsucursal
                });
            }
            catch (System.Exception)
            {
                throw new Exception("La sucursal no fue creada");
            }
        }

        public async Task<Response<object>> EditParSucursalAsync(ParSucursalRequest parSucursal)
        {
            try
            {
                var exist = await _context.ParSucursals.AnyAsync(x => x.CodigoEmpresa == parSucursal.CodigoEmpresa && x.CodigoBanco == parSucursal.CodigoBanco && x.CodigoSucursal == parSucursal.CodigoSucursal);
                if (!exist)
                {
                    return (new Response<object>
                    {
                        IsSuccess = false,
                        Message = "Registro no encontrado",
                        Result = null
                    });
                }

                var parsucursal = new ParSucursal
                {
                    CodigoEmpresa = parSucursal.CodigoEmpresa,
                    CodigoBanco = parSucursal.CodigoBanco,
                    CodigoSucursal = parSucursal.CodigoSucursal,
                    NombreSucursal = parSucursal.NombreSucursal,
                    CodigoSubsidiaria = parSucursal.CodigoSubsidiaria,
                    CodigoOrigen = parSucursal.CodigoOrigen,
                    CodigoPais = parSucursal.CodigoPais,
                    TipoEstablecimiento = parSucursal.TipoEstablecimiento,
                    Direccion = parSucursal.Direccion,
                    Telefono1 = parSucursal.Telefono1,
                    Encargado = parSucursal.Encargado,
                    Telefono2 = parSucursal.Telefono2,
                    Fax = parSucursal.Fax,
                    NombreResponsable = parSucursal.NombreResponsable,
                    CargoResposable = parSucursal.CargoResposable,
                    CodigoEstado = parSucursal.CodigoEstado,
                    IdUsuario = parSucursal.IdUsuario
                };

                _context.Update(parsucursal);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "Registro actualizado",
                    Result = parsucursal
                });
            }
            catch (System.Exception)
            {
                throw new Exception("La sucursal no fue modificada");
            }
        }
        
        public async Task<Response<object>> DeleteParSucursalAsync(ParSucursalRequest parSucursal)
        {
            try
            {
                var existe = await _context.ParSucursals.AnyAsync(x => x.CodigoEmpresa == parSucursal.CodigoEmpresa && x.CodigoBanco == parSucursal.CodigoBanco && x.CodigoSucursal == parSucursal.CodigoSucursal);
                if (!existe)
                {
                    return (new Response<Object>
                    {
                        IsSuccess = false,
                        Message = "El registro no existe",
                        Result = null
                    });
                }

                _context.Remove(new ParSucursal() { CodigoEmpresa = parSucursal.CodigoEmpresa, CodigoBanco = parSucursal.CodigoBanco, CodigoSucursal = parSucursal.CodigoSucursal });
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "La sucursal fue eliminada",
                    Result = parSucursal
                });
            }
            catch (System.Exception)
            {
                throw new Exception("No se pudo eliminar la sucursal");
            }
        }
    }
}
