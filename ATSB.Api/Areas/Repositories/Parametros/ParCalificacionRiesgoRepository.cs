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
    public class ParCalificacionRiesgoRepository :IParCalificacionRiesgoRepository
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IConsecutivoHelper _ConsecutivoHelper;

        public ParCalificacionRiesgoRepository
        (
            ATSBIdentityDbContext context,
            IConsecutivoHelper ConsecutivoHelper
        ) : base()

        {
            _context = context;
            _ConsecutivoHelper = ConsecutivoHelper;
        }

        public IQueryable GetParCalificacionRiesgos()
        {
            return _context.ParCalificacionriesgos
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation); //Empresa
        }

        public async Task<ParCalificacionriesgo> GetParCalificacionRiesgoAsync(int CodigoEmpresa, int Id)
        {
            return await _context.ParCalificacionriesgos.Where(x => x.CodigoEmpresa == CodigoEmpresa && x.Id == Id)
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation) //Empresa
                .FirstOrDefaultAsync();
        }
        
        public async Task<Response<object>> AddParCalificacionRiesgoAsync(ParCalificacionRiesgoRequest parCalificacionRiesgo)
        {
            try
            {
                var update = await _ConsecutivoHelper.updateConsecutivo(parCalificacionRiesgo.CodigoEmpresa, "PAR_CALIFICACIONRIESGO");
                int consecutivo = await _ConsecutivoHelper.GetConsecutivo(parCalificacionRiesgo.CodigoEmpresa, "PAR_CALIFICACIONRIESGO");

                var parcalificacionriesgo = new ParCalificacionriesgo
                {
                    CodigoEmpresa = parCalificacionRiesgo.CodigoEmpresa,
                    Id = consecutivo,
                    Descripcion = parCalificacionRiesgo.Descripcion,
                    Moody = parCalificacionRiesgo.Moody,
                    Fitch = parCalificacionRiesgo.Fitch,
                    Comp = parCalificacionRiesgo.Comp,
                    Sp = parCalificacionRiesgo.Sp,
                    IdUsuario = parCalificacionRiesgo.IdUsuario
                };

                _context.ParCalificacionriesgos.Add(parcalificacionriesgo);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "La calificacion riesgo se creo con exito",
                    Result = parcalificacionriesgo
                });
            }
            catch (System.Exception ex)
            {
                throw new Exception("La calificacion riesgo no fue creada");
            }
        }

        public async Task<Response<object>> EditParCalificacionRiesgoAsync(ParCalificacionRiesgoRequest parCalificacionRiesgo)
        {
            try
            {
                var exist = await _context.ParCalificacionriesgos.AnyAsync(x => x.CodigoEmpresa == parCalificacionRiesgo.CodigoEmpresa && x.Id == parCalificacionRiesgo.Id);
                if (!exist)
                {
                    return (new Response<object>
                    {
                        IsSuccess = false,
                        Message = "Registro no encontrado",
                        Result = null
                    });
                }

                var parcalificacionriesgo = new ParCalificacionriesgo
                {
                    CodigoEmpresa = parCalificacionRiesgo.CodigoEmpresa,
                    Id = parCalificacionRiesgo.Id,
                    Descripcion = parCalificacionRiesgo.Descripcion,
                    Moody = parCalificacionRiesgo.Moody,
                    Fitch = parCalificacionRiesgo.Fitch,
                    Comp = parCalificacionRiesgo.Comp,
                    Sp = parCalificacionRiesgo.Sp,
                    IdUsuario = parCalificacionRiesgo.IdUsuario
                };

                _context.Update(parcalificacionriesgo);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "Registro actualizado",
                    Result = parcalificacionriesgo
                });
            }
            catch (System.Exception)
            {
                throw new Exception("La calificacion riesgo no fue modificada");
            }
        }
        
        public async Task<Response<object>> DeleteParCalificacionRiesgoAsync(ParCalificacionRiesgoRequest parCalificacionRiesgo)
        {
            try
            {
                var existe = await _context.ParCalificacionriesgos.AnyAsync(x => x.CodigoEmpresa == parCalificacionRiesgo.CodigoEmpresa && x.Id == parCalificacionRiesgo.Id);
                if (!existe)
                {
                    return (new Response<Object>
                    {
                        IsSuccess = false,
                        Message = "El registro no existe",
                        Result = null
                    });
                }

                _context.Remove(new ParCalificacionriesgo() { CodigoEmpresa = parCalificacionRiesgo.CodigoEmpresa, Id = parCalificacionRiesgo.Id });
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "La calificacion riesgo fue eliminada",
                    Result = parCalificacionRiesgo
                });
            }
            catch (System.Exception)
            {
                throw new Exception("No se pudo eliminar la calificacion riesgo");
            }
        }
    }
}
