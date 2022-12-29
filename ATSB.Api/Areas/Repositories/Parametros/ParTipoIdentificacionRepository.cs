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

namespace ATSB.Api.Areas.Repositories.Parametros
{
    public class ParTipoIdentificacionRepository : IParTipoIdentificacionRepository
    {
        private readonly ATSBIdentityDbContext _context;

        public ParTipoIdentificacionRepository
        (
            ATSBIdentityDbContext context
        ) : base()

        {
            _context = context;
        }

        public IQueryable GetParTipoIdentificaciones()
        {
            return _context.ParTipoidentificacions
                .AsNoTracking()
                .Include(p => p.CodigoPaisNavigation); //Pais
        }

        public async Task<ParTipoidentificacion> GetParTipoIdentificacionAsync(int CodigoPais, int CodigoTipoIdentificacion)
        {
            return await _context.ParTipoidentificacions.Where(x => x.CodigoPais == CodigoPais && x.CodigoTipoIdentificacion == CodigoTipoIdentificacion)
                .AsNoTracking()
                .Include(p => p.CodigoPaisNavigation) //Pais
                .FirstOrDefaultAsync();
        }
        
        public async Task<Response<object>> AddParTipoIdentificacionAsync(ParTipoIdentificacionRequest parTipoIdentificacion)
        {
            try
            {
                //var update = await _ConsecutivoHelper.updateConsecutivo(0, "PAS_ESTADO");
                //int consecutivo = await _ConsecutivoHelper.GetConsecutivo(0, "PAS_ESTADO");

                var partipoid = new ParTipoidentificacion
                {
                    CodigoPais = parTipoIdentificacion.CodigoPais,
                    CodigoTipoIdentificacion = parTipoIdentificacion.CodigoTipoIdentificacion,
                    Descripcion = parTipoIdentificacion.Descripcion,
                    Formato = parTipoIdentificacion.Formato,
                    Longitud = parTipoIdentificacion.Longitud,
                    IndicadorFisica = parTipoIdentificacion.IndicadorFisica == "true" ? true : false,
                    FechaUltimaModificacion = parTipoIdentificacion.FechaUltimaModificacion,
                    UsuarioModifica = parTipoIdentificacion.UsuarioModifica,
                    CantidadModificaciones = parTipoIdentificacion.CantidadModificaciones,
                    CodigoFacturaElectronica = parTipoIdentificacion.CodigoFacturaElectronica
                };

                _context.ParTipoidentificacions.Add(partipoid);
                await _context.SaveChangesAsync();


                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "El tipo identificacion se creo con exito",
                    Result = partipoid
                });
            }
            catch (System.Exception ex)
            {
                throw new Exception("El tipo identificacion no fue creado");
            }
        }

        public async Task<Response<object>> EditParTipoIdentificacionAsync(ParTipoIdentificacionRequest parTipoIdentificacion)
        {
            try
            {
                var exist = await _context.ParTipoidentificacions.AnyAsync(x => x.CodigoPais == parTipoIdentificacion.CodigoPais && x.CodigoTipoIdentificacion == parTipoIdentificacion.CodigoTipoIdentificacion);
                if (!exist)
                {
                    return (new Response<object>
                    {
                        IsSuccess = false,
                        Message = "Registro no encontrado",
                        Result = null
                    });
                }

                var partipoid = new ParTipoidentificacion
                {
                    CodigoPais = parTipoIdentificacion.CodigoPais,
                    CodigoTipoIdentificacion = parTipoIdentificacion.CodigoTipoIdentificacion,
                    Descripcion = parTipoIdentificacion.Descripcion,
                    Formato = parTipoIdentificacion.Formato,
                    Longitud = parTipoIdentificacion.Longitud,
                    IndicadorFisica = parTipoIdentificacion.IndicadorFisica == "true" ? true : false,
                    FechaUltimaModificacion = parTipoIdentificacion.FechaUltimaModificacion,
                    UsuarioModifica = parTipoIdentificacion.UsuarioModifica,
                    CantidadModificaciones = parTipoIdentificacion.CantidadModificaciones,
                    CodigoFacturaElectronica = parTipoIdentificacion.CodigoFacturaElectronica
                };

                _context.Update(partipoid);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "Registro actualizado",
                    Result = partipoid
                });
            }
            catch (System.Exception)
            {
                throw new Exception("El tipo identificacion no fue modificado");
            }
        }

        public async Task<Response<object>> DeleteParTipoIdentificacionAsync(ParTipoIdentificacionRequest parTipoIdentificacion)
        {
            try
            {
                var existe = await _context.ParTipoidentificacions.AnyAsync(x => x.CodigoPais == parTipoIdentificacion.CodigoPais && x.CodigoTipoIdentificacion == parTipoIdentificacion.CodigoTipoIdentificacion);
                if (!existe)
                {
                    return (new Response<Object>
                    {
                        IsSuccess = false,
                        Message = "El registro no existe",
                        Result = null
                    });
                }

                _context.Remove(new ParTipoidentificacion() { CodigoPais = parTipoIdentificacion.CodigoPais, CodigoTipoIdentificacion = parTipoIdentificacion.CodigoTipoIdentificacion });
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "El tipo identificacion fue eliminado",
                    Result = parTipoIdentificacion
                });
            }
            catch (System.Exception)
            {
                throw new Exception("No se pudo eliminar el tipo identificacion");
            }
        }
    }
}
