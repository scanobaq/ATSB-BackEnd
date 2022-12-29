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
    public class ParPaisRepository : IParPaisRepository
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IConsecutivoHelper _ConsecutivoHelper;

        public ParPaisRepository
        (
            ATSBIdentityDbContext context,
            IConsecutivoHelper ConsecutivoHelper
        ) : base()

        {
            _context = context;
            _ConsecutivoHelper = ConsecutivoHelper;
        }

        public IQueryable GetParPaises()
        {
            return _context.ParPais
                .AsNoTracking();
        }

        public async Task<ParPai> GetParPaisAsync(int CodigoPais)
        {
            return await _context.ParPais.Where(x => x.CodigoPais == CodigoPais)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<Response<object>> AddParPaisAsync(ParPaisRequest parPais)
        {
            try
            {
                var update = await _ConsecutivoHelper.updateConsecutivo(1, "PAR_PAIS");
                int consecutivo = await _ConsecutivoHelper.GetConsecutivo(1, "PAR_PAIS");

                var parpais = new ParPai
                {
                    CodigoPais = consecutivo, //parPais.CodigoPais
                    Nombre = parPais.Nombre,
                    CodigoIsonumerico = parPais.CodigoIsonumerico,
                    CodigoIsoalfa2 = parPais.CodigoIsoalfa2,
                    CodigoIsoalfa3 = parPais.CodigoIsoalfa3,
                    FormatoTelefonoFijo = parPais.FormatoTelefonoFijo,
                    FormatoTelefonoCelular = parPais.FormatoTelefonoCelular

                };

                _context.ParPais.Add(parpais);
                await _context.SaveChangesAsync();


                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "El pais se creo con exito",
                    Result = parpais
                });
            }
            catch (System.Exception ex)
            {
                throw new Exception("El pais no fue creado");
            }
            
        }

        public async Task<Response<object>> EditParPaisAsync(ParPaisRequest parPais)
        {
            try
            {
                var exist = await _context.ParPais.AnyAsync(x => x.CodigoPais == parPais.CodigoPais);
                if (!exist)
                {
                    return (new Response<object>
                    {
                        IsSuccess = false,
                        Message = "Registro no encontrado",
                        Result = null
                    });
                }

                var parpais = new ParPai
                {
                    CodigoPais = parPais.CodigoPais,
                    Nombre = parPais.Nombre,
                    CodigoIsonumerico = parPais.CodigoIsonumerico,
                    CodigoIsoalfa2 = parPais.CodigoIsoalfa2,
                    CodigoIsoalfa3 = parPais.CodigoIsoalfa3,
                    FormatoTelefonoFijo = parPais.FormatoTelefonoFijo,
                    FormatoTelefonoCelular = parPais.FormatoTelefonoCelular

                };

                _context.Update(parpais);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "Registro actualizado",
                    Result = parpais
                });
            }
            catch (System.Exception)
            {
                throw new Exception("El pais no fue modificado");
            }
        }

        public async Task<Response<object>> DeleteParPaisAsync(ParPaisRequest parPais)
        {
            try
            {
                var existe = await _context.ParPais.AnyAsync(x => x.CodigoPais == parPais.CodigoPais);
                if (!existe)
                {
                    return (new Response<Object>
                    {
                        IsSuccess = false,
                        Message = "El registro no existe",
                        Result = null
                    });
                }

                _context.Remove(new ParPai() { CodigoPais = parPais.CodigoPais });
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "El pais fue eliminado",
                    Result = parPais
                });
            }
            catch (System.Exception)
            {
                throw new Exception("No se pudo eliminar el pais");
            }
        }
    }
}
