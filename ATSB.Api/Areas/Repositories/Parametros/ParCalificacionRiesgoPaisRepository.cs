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
    public class ParCalificacionRiesgoPaisRepository : IParCalificacionRiesgoPaisRepository
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IConsecutivoHelper _ConsecutivoHelper;

        public ParCalificacionRiesgoPaisRepository
        (
            ATSBIdentityDbContext context,
            IConsecutivoHelper ConsecutivoHelper
        ) : base()

        {
            _context = context;
            _ConsecutivoHelper = ConsecutivoHelper;
        }

        public IQueryable GetParCalificacionRiesgoPaises()
        {
            return _context.ParCalificacionriesgopais
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation); //Empresa
        }

        public async Task<ParCalificacionriesgopai> GetParCalificacionRiesgoPaisAsync(int CodigoEmpresa, int CodigoPais)
        {
            return await _context.ParCalificacionriesgopais.Where(x => x.CodigoEmpresa == CodigoEmpresa && x.CodigoPais == CodigoPais)
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation) //Empresa
                .FirstOrDefaultAsync();
        }
        
        public async Task<Response<object>> AddParCalificacionRiesgoPaisAsync(ParCalificacionRiesgoPaisRequest parCalificacionRiesgoPais)
        {
            try
            {
                var parcalificacionriesgopais = new ParCalificacionriesgopai
                {
                    CodigoEmpresa = parCalificacionRiesgoPais.CodigoEmpresa,
                    CodigoPais = parCalificacionRiesgoPais.CodigoPais,
                    FechaUltimaActualizacionFitch = parCalificacionRiesgoPais.FechaUltimaActualizacionFitch,
                    CodigoCalificacionFitch = parCalificacionRiesgoPais.CodigoCalificacionFitch,
                    PerspectivaFitch = parCalificacionRiesgoPais.PerspectivaFitch,
                    NumeroCalificacionFitch = parCalificacionRiesgoPais.NumeroCalificacionFitch,
                    FechaUltimaActualizacionMoody = parCalificacionRiesgoPais.FechaUltimaActualizacionMoody,
                    CodigoCalificacionMoody = parCalificacionRiesgoPais.CodigoCalificacionMoody,
                    PerspectivaMoody = parCalificacionRiesgoPais.PerspectivaMoody,
                    NumeroCalificacionMoody = parCalificacionRiesgoPais.NumeroCalificacionMoody,
                    FechaUltimaActualizacionSp = parCalificacionRiesgoPais.FechaUltimaActualizacionSp,
                    CodigoCalificacionSp = parCalificacionRiesgoPais.CodigoCalificacionSp,
                    PerspectivaSp = parCalificacionRiesgoPais.PerspectivaSp,
                    NumeroCalificacionSp = parCalificacionRiesgoPais.NumeroCalificacionSp,
                    Pd = parCalificacionRiesgoPais.Pd,
                    Pdajustada = parCalificacionRiesgoPais.Pdajustada,
                    Pdfinal = parCalificacionRiesgoPais.Pdfinal,
                    Perspectiva = parCalificacionRiesgoPais.Perspectiva,
                    NumeroCalificacionPais = parCalificacionRiesgoPais.NumeroCalificacionPais,
                    CalficacionAjustada = parCalificacionRiesgoPais.CalficacionAjustada,
                    FechaUltimaActualizacion = parCalificacionRiesgoPais.FechaUltimaActualizacion,
                    ForwardLooking = parCalificacionRiesgoPais.ForwardLooking,
                    IdUsuario = parCalificacionRiesgoPais.IdUsuario
                };

                _context.ParCalificacionriesgopais.Add(parcalificacionriesgopais);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "La calificacion riesgo pais se creo con exito",
                    Result = parcalificacionriesgopais
                });
            }
            catch (System.Exception ex)
            {
                throw new Exception("La calificacion riesgo pais no fue creada");
            }
        }

        public async Task<Response<object>> EditParCalificacionRiesgoPaisAsync(ParCalificacionRiesgoPaisRequest parCalificacionRiesgoPais)
        {
            try
            {
                var exist = await _context.ParCalificacionriesgopais.AnyAsync(x => x.CodigoEmpresa == parCalificacionRiesgoPais.CodigoEmpresa && x.CodigoPais == parCalificacionRiesgoPais.CodigoPais);
                if (!exist)
                {
                    return (new Response<object>
                    {
                        IsSuccess = false,
                        Message = "Registro no encontrado",
                        Result = null
                    });
                }

                var parcalificacionriesgopais = new ParCalificacionriesgopai
                {
                    CodigoEmpresa = parCalificacionRiesgoPais.CodigoEmpresa,
                    CodigoPais = parCalificacionRiesgoPais.CodigoPais,
                    FechaUltimaActualizacionFitch = parCalificacionRiesgoPais.FechaUltimaActualizacionFitch,
                    CodigoCalificacionFitch = parCalificacionRiesgoPais.CodigoCalificacionFitch,
                    PerspectivaFitch = parCalificacionRiesgoPais.PerspectivaFitch,
                    NumeroCalificacionFitch = parCalificacionRiesgoPais.NumeroCalificacionFitch,
                    FechaUltimaActualizacionMoody = parCalificacionRiesgoPais.FechaUltimaActualizacionMoody,
                    CodigoCalificacionMoody = parCalificacionRiesgoPais.CodigoCalificacionMoody,
                    PerspectivaMoody = parCalificacionRiesgoPais.PerspectivaMoody,
                    NumeroCalificacionMoody = parCalificacionRiesgoPais.NumeroCalificacionMoody,
                    FechaUltimaActualizacionSp = parCalificacionRiesgoPais.FechaUltimaActualizacionSp,
                    CodigoCalificacionSp = parCalificacionRiesgoPais.CodigoCalificacionSp,
                    PerspectivaSp = parCalificacionRiesgoPais.PerspectivaSp,
                    NumeroCalificacionSp = parCalificacionRiesgoPais.NumeroCalificacionSp,
                    Pd = parCalificacionRiesgoPais.Pd,
                    Pdajustada = parCalificacionRiesgoPais.Pdajustada,
                    Pdfinal = parCalificacionRiesgoPais.Pdfinal,
                    Perspectiva = parCalificacionRiesgoPais.Perspectiva,
                    NumeroCalificacionPais = parCalificacionRiesgoPais.NumeroCalificacionPais,
                    CalficacionAjustada = parCalificacionRiesgoPais.CalficacionAjustada,
                    FechaUltimaActualizacion = parCalificacionRiesgoPais.FechaUltimaActualizacion,
                    ForwardLooking = parCalificacionRiesgoPais.ForwardLooking,
                    IdUsuario = parCalificacionRiesgoPais.IdUsuario
                };

                _context.Update(parcalificacionriesgopais);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "Registro actualizado",
                    Result = parcalificacionriesgopais
                });
            }
            catch (System.Exception)
            {
                throw new Exception("La calificacion riesgo pais no fue modificada");
            }
        }
        
        public async Task<Response<object>> DeleteParCalificacionRiesgoPaisAsync(ParCalificacionRiesgoPaisRequest parCalificacionRiesgoPais)
        {
            try
            {
                var existe = await _context.ParCalificacionriesgopais.AnyAsync(x => x.CodigoEmpresa == parCalificacionRiesgoPais.CodigoEmpresa && x.CodigoPais == parCalificacionRiesgoPais.CodigoPais);
                if (!existe)
                {
                    return (new Response<Object>
                    {
                        IsSuccess = false,
                        Message = "El registro no existe",
                        Result = null
                    });
                }

                _context.Remove(new ParCalificacionriesgopai() { CodigoEmpresa = parCalificacionRiesgoPais.CodigoEmpresa, CodigoPais = parCalificacionRiesgoPais.CodigoPais });
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "La calificacion riesgo pais fue eliminada",
                    Result = parCalificacionRiesgoPais
                });
            }
            catch (System.Exception)
            {
                throw new Exception("No se pudo eliminar la calificacion riesgo pais");
            }
        }
    }
}
