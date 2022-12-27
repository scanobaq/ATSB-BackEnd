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
    public class ParMonedaRepository : IParMonedaRepository
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IConsecutivoHelper _ConsecutivoHelper;

        public ParMonedaRepository
        (
            ATSBIdentityDbContext context,
            IConsecutivoHelper ConsecutivoHelper
        ) : base()

        {
            _context = context;
            _ConsecutivoHelper = ConsecutivoHelper;
        }

        public IQueryable GetParMonedas()
        {
            return _context.ParMoneda
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation); //Empresa
        }

        public async Task<ParMonedum> GetParMonedaAsync(int CodigoEmpresa, int CodigoMoneda)
        {
            return await _context.ParMoneda.Where(x => x.CodigoEmpresa == CodigoEmpresa && x.CodigoMoneda == CodigoMoneda)
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation) //Empresa
                .FirstOrDefaultAsync();
        }
        
        public async Task<Response<object>> AddParMonedaAsync(ParMonedaRequest parMoneda)
        {
            try
            {
                var update = await _ConsecutivoHelper.updateConsecutivo(parMoneda.CodigoEmpresa, "PAR_MONEDA");
                int consecutivo = await _ConsecutivoHelper.GetConsecutivo(parMoneda.CodigoEmpresa, "PAR_MONEDA");

                var parmoneda = new ParMonedum
                {
                    CodigoEmpresa = parMoneda.CodigoEmpresa,
                    CodigoMoneda = consecutivo,
                    Descripcion = parMoneda.Descripcion,
                    DescripcionCorta = parMoneda.DescripcionCorta,
                    IdUsuario = parMoneda.IdUsuario
                };

                _context.ParMoneda.Add(parmoneda);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "La moneda se creo con exito",
                    Result = parmoneda
                });
            }
            catch (System.Exception)
            {
                throw new Exception("La moneda no fue creada");
            }
        }

        public async Task<Response<object>> EditParMonedaAsync(ParMonedaRequest parMoneda)
        {
            try
            {
                var exist = await _context.ParMoneda.AnyAsync(x => x.CodigoEmpresa == parMoneda.CodigoEmpresa && x.CodigoMoneda == parMoneda.CodigoMoneda);
                if (!exist)
                {
                    return (new Response<object>
                    {
                        IsSuccess = false,
                        Message = "Registro no encontrado",
                        Result = null
                    });
                }

                var parmoneda = new ParMonedum
                {
                    CodigoEmpresa = parMoneda.CodigoEmpresa,
                    CodigoMoneda = parMoneda.CodigoMoneda,
                    Descripcion = parMoneda.Descripcion,
                    DescripcionCorta = parMoneda.DescripcionCorta,
                    IdUsuario = parMoneda.IdUsuario
                };

                _context.Update(parmoneda);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "Registro actualizado",
                    Result = parmoneda
                });
            }
            catch (System.Exception)
            {
                throw new Exception("La moneda no fue modificada");
            }
        }

        public async Task<Response<object>> DeleteParMonedaAsync(ParMonedaRequest parMoneda)
        {
            try
            {
                var existe = await _context.ParMoneda.AnyAsync(x => x.CodigoEmpresa == parMoneda.CodigoEmpresa && x.CodigoMoneda == parMoneda.CodigoMoneda);
                if (!existe)
                {
                    return (new Response<Object>
                    {
                        IsSuccess = false,
                        Message = "El registro no existe",
                        Result = null
                    });
                }

                _context.Remove(new ParMonedum() { CodigoEmpresa = parMoneda.CodigoEmpresa, CodigoMoneda = parMoneda.CodigoMoneda });
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "La moneda fue eliminada",
                    Result = parMoneda
                });
            }
            catch (System.Exception)
            {
                throw new Exception("No se pudo eliminar la moneda");
            }
        }
    }
}
