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
    public class ParEstadoRepository : IParEstadoRepository
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IConsecutivoHelper _ConsecutivoHelper;

        public ParEstadoRepository
        (
            ATSBIdentityDbContext context,
            IConsecutivoHelper ConsecutivoHelper
        ) : base()

        {
            _context = context;
            _ConsecutivoHelper = ConsecutivoHelper;
        }

        public IQueryable GetParEstados()
        {
            return _context.ParEstados
                .AsNoTracking();
        }

        public async Task<ParEstado> GetParEstadoAsync(int CodigoEstado)
        {
            return await _context.ParEstados.Where(x => x.CodigoEstado == CodigoEstado)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<Response<object>> AddParEstadoAsync(ParEstadoRequest parEstado)
        {
            try
            {
                var update = await _ConsecutivoHelper.updateConsecutivo(0, "PAR_ESTADO");
                int consecutivo = await _ConsecutivoHelper.GetConsecutivo(0, "PAR_ESTADO");

                var parestado = new ParEstado
                {
                    CodigoEstado = consecutivo, //parEstado.CodigoEstado
                    Descripcion = parEstado.Descripcion
                };

                _context.ParEstados.Add(parestado);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "El estado se creo con exito",
                    Result = parestado
                });
            }
            catch (System.Exception)
            {
                throw new Exception("El estado no fue creado");
            }
        }
        
        public async Task<Response<object>> EditParEstadoAsync(ParEstadoRequest parEstado)
        {
            try
            {
                var exist = await _context.ParEstados.AnyAsync(x => x.CodigoEstado == parEstado.CodigoEstado);
                if (!exist)
                {
                    return (new Response<object>
                    {
                        IsSuccess = false,
                        Message = "Registro no encontrado",
                        Result = null
                    });
                }

                var parestado = new ParEstado
                {
                    CodigoEstado = parEstado.CodigoEstado,
                    Descripcion = parEstado.Descripcion
                };

                _context.Update(parestado);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "Registro actualizado",
                    Result = parestado
                });
            }
            catch (System.Exception)
            {
                throw new Exception("El estado no fue modificado");
            }
        }

        public async Task<Response<object>> DeleteParEstadoAsync(ParEstadoRequest parEstado)
        {
            try
            {
                var existe = await _context.ParEstados.AnyAsync(x => x.CodigoEstado == parEstado.CodigoEstado);
                if (!existe)
                {
                    return (new Response<Object>
                    {
                        IsSuccess = false,
                        Message = "El registro no existe",
                        Result = null
                    });
                }

                _context.Remove(new ParEstado() { CodigoEstado = parEstado.CodigoEstado });
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "El estado fue eliminado",
                    Result = parEstado
                });
            }
            catch (System.Exception)
            {
                throw new Exception("No se pudo eliminar el estado");
            }
        }
    }
}
