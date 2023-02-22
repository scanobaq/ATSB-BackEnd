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
using ATSB.Api.Areas.Entities.Parametros;
using ATSB.Api.Models.Credito;
using ATSB.Api.Areas.Entities.Credito;
using ATSB.Api.Models.Liquidez;
using ATSB.Api.Areas.Entities.Liquidez;

namespace ATSB.Api.Areas.Repositories.Liquidez
{
    public class LiqIndiceRepository : ILiqIndiceRepository
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IConsecutivoHelper _ConsecutivoHelper;

        public LiqIndiceRepository
        (
            ATSBIdentityDbContext context,
            IConsecutivoHelper ConsecutivoHelper
        ) : base()

        {
            _context = context;
            _ConsecutivoHelper = ConsecutivoHelper;
        }

        public IQueryable GetLiqIndices()
        {
            return _context.LiqIndice
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation); //Empresa
        }

        public async Task<LiqIndie> GetLiqIndiceAsync(int CodigoEmpresa, string Tipo, int Rubro)
        {
            return await _context.LiqIndice.Where(x => x.CodigoEmpresa == CodigoEmpresa && x.Tipo == Tipo && x.Rubro == Rubro)
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation) //Empresa
                .FirstOrDefaultAsync();
        }

        public async Task<Response<object>> AddLiqIndiceAsync(LiqIndiceRequest liqIndice)
        {
            try
            {
                var liqindice = new LiqIndie
                {
                    CodigoEmpresa = liqIndice.CodigoEmpresa,
                    Tipo = liqIndice.Tipo,
                    Rubro = liqIndice.Rubro,
                    Porcentaje = liqIndice.Porcentaje,
                    Multiplicador = liqIndice.Multiplicador,
                    IdUsuario = liqIndice.IdUsuario,
                    TipoDescipcion = liqIndice.TipoDescipcion
                };

                _context.LiqIndice.Add(liqindice);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "El indice se creo con exito",
                    Result = liqindice
                });
            }
            catch (System.Exception)
            {
                throw new Exception("El indice no fue creado");
            }
        }

        public async Task<Response<object>> EditLiqIndiceAsync(LiqIndiceRequest liqIndice)
        {
            try
            {
                var exist = await _context.LiqIndice.AnyAsync(x => x.CodigoEmpresa == liqIndice.CodigoEmpresa && x.Tipo == liqIndice.Tipo && x.Rubro == liqIndice.Rubro);
                if (!exist)
                {
                    return (new Response<object>
                    {
                        IsSuccess = false,
                        Message = "Registro no encontrado",
                        Result = null
                    });
                }

                var liqindice = new LiqIndie
                {
                    CodigoEmpresa = liqIndice.CodigoEmpresa,
                    Tipo = liqIndice.Tipo,
                    Rubro = liqIndice.Rubro,
                    Porcentaje = liqIndice.Porcentaje,
                    Multiplicador = liqIndice.Multiplicador,
                    IdUsuario = liqIndice.IdUsuario,
                    TipoDescipcion = liqIndice.TipoDescipcion
                };

                _context.Update(liqindice);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "Registro actualizado",
                    Result = liqindice
                });
            }
            catch (System.Exception)
            {
                throw new Exception("El indice no fue modificado");
            }
        }

        public async Task<Response<object>> DeleteLiqIndiceAsync(LiqIndiceRequest liqIndice)
        {
            try
            {
                var existe = await _context.LiqIndice.AnyAsync(x => x.CodigoEmpresa == liqIndice.CodigoEmpresa && x.Tipo == liqIndice.Tipo && x.Rubro == liqIndice.Rubro);
                if (!existe)
                {
                    return (new Response<Object>
                    {
                        IsSuccess = false,
                        Message = "El registro no existe",
                        Result = null
                    });
                }

                _context.Remove(new LiqIndie() { CodigoEmpresa = liqIndice.CodigoEmpresa, Tipo = liqIndice.Tipo, Rubro = liqIndice.Rubro });
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "El indice fue eliminado",
                    Result = liqIndice
                });
            }
            catch (System.Exception)
            {
                throw new Exception("No se pudo eliminar el indice");
            }
        }
    }
}
