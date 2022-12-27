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
    public class ParConsecutivoRepository : IParConsecutivoRepository
    {
        private readonly ATSBIdentityDbContext _context;

        public ParConsecutivoRepository
        (
            ATSBIdentityDbContext context
        ) : base()

        {
            _context = context;
        }

        public IQueryable GetParConsecutivos()
        {
            return _context.ParConsecutivos
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation); //Empresa
        }

        public async Task<ParConsecutivo> GetParConsecutivoAsync(int CodigoEmpresa, string IdConsecutivo)
        {
            return await _context.ParConsecutivos.Where(x => x.CodigoEmpresa == CodigoEmpresa && x.IdConsecutivo == IdConsecutivo)
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation) //Empresa
                .FirstOrDefaultAsync();
        }
        
        public async Task<Response<object>> AddParConsecutivoAsync(ParConsecutivoRequest parConsecutivo)
        {
            try
            {
                var parconsecutivo = new ParConsecutivo
                {
                    CodigoEmpresa = parConsecutivo.CodigoEmpresa,
                    IdConsecutivo = parConsecutivo.IdConsecutivo,
                    NumeroConsecutivo = parConsecutivo.NumeroConsecutivo
                };

                _context.ParConsecutivos.Add(parconsecutivo);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "El consecutivo se creo con exito",
                    Result = parconsecutivo
                });
            }
            catch (System.Exception)
            {
                throw new Exception("El consecutivo no fue creado");
            }
        }

        public async Task<Response<object>> EditParConsecutivoAsync(ParConsecutivoRequest parConsecutivo)
        {
            try
            {
                var exist = await _context.ParConsecutivos.AnyAsync(x => x.CodigoEmpresa == parConsecutivo.CodigoEmpresa && x.IdConsecutivo == parConsecutivo.IdConsecutivo);
                if (!exist)
                {
                    return (new Response<object>
                    {
                        IsSuccess = false,
                        Message = "Registro no encontrado",
                        Result = null
                    });
                }

                var parconsecutivo = new ParConsecutivo
                {
                    CodigoEmpresa = parConsecutivo.CodigoEmpresa,
                    IdConsecutivo = parConsecutivo.IdConsecutivo,
                    NumeroConsecutivo = parConsecutivo.NumeroConsecutivo
                };

                _context.Update(parconsecutivo);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "Registro actualizado",
                    Result = parconsecutivo
                });
            }
            catch (System.Exception)
            {
                throw new Exception("El consecutivo no fue modificado");
            }
        }

        public async Task<Response<object>> DeleteParConsecutivoAsync(ParConsecutivoRequest parConsecutivo)
        {
            try
            {
                var existe = await _context.ParConsecutivos.AnyAsync(x => x.CodigoEmpresa == parConsecutivo.CodigoEmpresa && x.IdConsecutivo == parConsecutivo.IdConsecutivo);
                if (!existe)
                {
                    return (new Response<Object>
                    {
                        IsSuccess = false,
                        Message = "El registro no existe",
                        Result = null
                    });
                }

                _context.Remove(new ParConsecutivo() { CodigoEmpresa = parConsecutivo.CodigoEmpresa, IdConsecutivo = parConsecutivo .IdConsecutivo });
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "El consecutivo fue eliminado",
                    Result = parConsecutivo
                });
            }
            catch (System.Exception)
            {
                throw new Exception("No se pudo eliminar el consecutivo");
            }
        }
    }
}
