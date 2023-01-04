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

namespace ATSB.Api.Areas.Repositories.Configuracion
{
    public class CnfCalificacionRiesgoEquivalenciaRepository : ICnfCalificacionRiesgoEquivalenciaRepository
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IConsecutivoHelper _ConsecutivoHelper;

        public CnfCalificacionRiesgoEquivalenciaRepository
        (
            ATSBIdentityDbContext context,
            IConsecutivoHelper ConsecutivoHelper
        ) : base()

        {
            _context = context;
            _ConsecutivoHelper = ConsecutivoHelper;
        }

        public IQueryable GetCnfCalificacionRiesgoEquivalencias()
        {
            return _context.CnfCalificacionriesgoequivalencia
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation); //Empresa
        }

        public async Task<CnfCalificacionriesgoequivalencium> GetCnfCalificacionRiesgoEquivalenciaAsync(int CodigoEmpresa, string CalificacionOrigen)
        {
            return await _context.CnfCalificacionriesgoequivalencia.Where(x => x.CodigoEmpresa == CodigoEmpresa && x.CalificacionOrigen == CalificacionOrigen)
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation) //Empresa
                .FirstOrDefaultAsync();
        }

        public async Task<Response<object>> AddCnfCalificacionRiesgoEquivalenciaAsync(CnfCalificacionRiesgoEquivalenciaRequest cnfCalificacionRiesgoEquivalencia)
        {
            try
            {

                var cnfcalificacion = new CnfCalificacionriesgoequivalencium
                {
                    CodigoEmpresa = cnfCalificacionRiesgoEquivalencia.CodigoEmpresa,
                    CalificacionOrigen = cnfCalificacionRiesgoEquivalencia.CalificacionOrigen,
                    CalificacionDestino = cnfCalificacionRiesgoEquivalencia.CalificacionDestino,
                    NumeroCalificacion = cnfCalificacionRiesgoEquivalencia.NumeroCalificacion,
                    IdUsuario = cnfCalificacionRiesgoEquivalencia.IdUsuario
                };

                _context.CnfCalificacionriesgoequivalencia.Add(cnfcalificacion);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "La calificacion riesgo equivalencia se creo con exito",
                    Result = cnfcalificacion
                });
            }
            catch (System.Exception)
            {
                throw new Exception("La calificacion riesgo equivalencia no fue creada");
            }
        }

        public async Task<Response<object>> EditCnfCalificacionRiesgoEquivalenciaAsync(CnfCalificacionRiesgoEquivalenciaRequest cnfCalificacionRiesgoEquivalencia)
        {
            try
            {
                var exist = await _context.CnfCalificacionriesgoequivalencia.AnyAsync(x => x.CodigoEmpresa == cnfCalificacionRiesgoEquivalencia.CodigoEmpresa && x.CalificacionOrigen == cnfCalificacionRiesgoEquivalencia.CalificacionOrigen);
                if (!exist)
                {
                    return (new Response<object>
                    {
                        IsSuccess = false,
                        Message = "Registro no encontrado",
                        Result = null
                    });
                }

                var cnfcalificacion = new CnfCalificacionriesgoequivalencium
                {
                    CodigoEmpresa = cnfCalificacionRiesgoEquivalencia.CodigoEmpresa,
                    CalificacionOrigen = cnfCalificacionRiesgoEquivalencia.CalificacionOrigen,
                    CalificacionDestino = cnfCalificacionRiesgoEquivalencia.CalificacionDestino,
                    NumeroCalificacion = cnfCalificacionRiesgoEquivalencia.NumeroCalificacion,
                    IdUsuario = cnfCalificacionRiesgoEquivalencia.IdUsuario
                };

                _context.Update(cnfcalificacion);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "Registro actualizado",
                    Result = cnfcalificacion
                });
            }
            catch (System.Exception)
            {
                throw new Exception("La calificacion riesgo equivalencia no fue modificada");
            }
        }
        
        public async Task<Response<object>> DeleteCnfCalificacionRiesgoEquivalenciaAsync(CnfCalificacionRiesgoEquivalenciaRequest cnfCalificacionRiesgoEquivalencia)
        {
            try
            {
                var existe = await _context.CnfCalificacionriesgoequivalencia.AnyAsync(x => x.CodigoEmpresa == cnfCalificacionRiesgoEquivalencia.CodigoEmpresa && x.CalificacionOrigen == cnfCalificacionRiesgoEquivalencia.CalificacionOrigen);
                if (!existe)
                {
                    return (new Response<Object>
                    {
                        IsSuccess = false,
                        Message = "El registro no existe",
                        Result = null
                    });
                }

                _context.Remove(new CnfCalificacionriesgoequivalencium() { CodigoEmpresa = cnfCalificacionRiesgoEquivalencia.CodigoEmpresa, CalificacionOrigen = cnfCalificacionRiesgoEquivalencia.CalificacionOrigen });
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "La calificacion riesgo equivalencia fue eliminada",
                    Result = cnfCalificacionRiesgoEquivalencia
                });
            }
            catch (System.Exception)
            {
                throw new Exception("No se pudo eliminar la calificacion riesgo equivalencia");
            }
        }
    }
}
