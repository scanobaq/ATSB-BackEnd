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
    public class ParTipoCambioRepository : IParTipoCambioRepository
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IConsecutivoHelper _ConsecutivoHelper;

        public ParTipoCambioRepository
        (
            ATSBIdentityDbContext context,
            IConsecutivoHelper ConsecutivoHelper
        ) : base()

        {
            _context = context;
            _ConsecutivoHelper = ConsecutivoHelper;
        }

        public IQueryable GetParTiposCambio()
        {
            return _context.ParTipocambios
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation) //Empresa
                .Include(m => m.Codigo); //Moneda
        }

        public async Task<ParTipocambio> GetParTipoCambioAsync(int CodigoEmpresa, DateTime Fecha, int CodigoMoneda)
        {
            return await _context.ParTipocambios.Where(x => x.CodigoEmpresa == CodigoEmpresa && x.Fecha == Fecha && x.CodigoMoneda == CodigoMoneda)
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation) //Empresa
                .Include(m => m.Codigo) //Moneda
                .FirstOrDefaultAsync();
        }

        public async Task<Response<object>> AddParTipoCambioAsync(ParTipoCambioRequest parTipoCambio)
        {
            try
            {
                var partipocambio = new ParTipocambio
                {
                    CodigoEmpresa = parTipoCambio.CodigoEmpresa,
                    Fecha = parTipoCambio.Fecha,
                    CodigoMoneda = parTipoCambio.CodigoMoneda,
                    TipoCambio = parTipoCambio.TipoCambio,
                    Id = parTipoCambio.Id
                };

                _context.ParTipocambios.Add(partipocambio);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "El tipo cambio se creo con exito",
                    Result = partipocambio
                });
            }
            catch (System.Exception)
            {
                throw new Exception("El tipo cambio no fue creado");
            }
        }

        public async Task<Response<object>> EditParTipoCambioAsync(ParTipoCambioRequest parTipoCambio)
        {
            try
            {
                var exist = await _context.ParTipocambios.AnyAsync(x => x.CodigoEmpresa == parTipoCambio.CodigoEmpresa && x.Fecha == parTipoCambio.Fecha && x.CodigoMoneda == parTipoCambio.CodigoMoneda);
                if (!exist)
                {
                    return (new Response<object>
                    {
                        IsSuccess = false,
                        Message = "Registro no encontrado",
                        Result = null
                    });
                }

                var partipocambio = new ParTipocambio
                {
                    CodigoEmpresa = parTipoCambio.CodigoEmpresa,
                    Fecha = parTipoCambio.Fecha,
                    CodigoMoneda = parTipoCambio.CodigoMoneda,
                    TipoCambio = parTipoCambio.TipoCambio,
                    Id = parTipoCambio.Id
                };

                _context.Update(partipocambio);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "Registro actualizado",
                    Result = partipocambio
                });
            }
            catch (System.Exception)
            {
                throw new Exception("El tipo cambio no fue modificado");
            }
        }
        
        public async Task<Response<object>> DeleteParTipoCambioAsync(ParTipoCambioRequest parTipoCambio)
        {
            try
            {
                var existe = await _context.ParTipocambios.AnyAsync(x => x.CodigoEmpresa == parTipoCambio.CodigoEmpresa && x.Fecha == parTipoCambio.Fecha && x.CodigoMoneda == parTipoCambio.CodigoMoneda);
                if (!existe)
                {
                    return (new Response<Object>
                    {
                        IsSuccess = false,
                        Message = "El registro no existe",
                        Result = null
                    });
                }

                _context.Remove(new ParTipocambio() { CodigoEmpresa = parTipoCambio.CodigoEmpresa, Fecha = parTipoCambio.Fecha, CodigoMoneda = parTipoCambio.CodigoMoneda });
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "El tipo cambio fue eliminado",
                    Result = parTipoCambio
                });
            }
            catch (System.Exception)
            {
                throw new Exception("No se pudo eliminar el tipo cambio");
            }
        }
    }
}
