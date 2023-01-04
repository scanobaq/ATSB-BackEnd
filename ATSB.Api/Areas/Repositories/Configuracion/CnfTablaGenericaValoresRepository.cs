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
namespace ATSB.Api.Areas.Repositories.Configuracion
{
    public class CnfTablaGenericaValoresRepository : ICnfTablaGenericaValoresRepository
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IConsecutivoHelper _ConsecutivoHelper;

        public CnfTablaGenericaValoresRepository
        (
            ATSBIdentityDbContext context,
            IConsecutivoHelper ConsecutivoHelper
        ) : base()

        {
            _context = context;
            _ConsecutivoHelper = ConsecutivoHelper;
        }

        public IQueryable GetCnfTablasGenericasValores()
        {
            return _context.CnfTablagenericavalores
                .AsNoTracking()
                .Include(e => e.CnfTablagenerica.CodigoEmpresaNavigation) //Empresa
                .Include(t => t.CnfTablagenerica) //Tabla
                .Include(s => s.CodigoEstadoNavigation); //Estado
        }

        public async Task<CnfTablagenericavalore> GetCnfTablaGenericaValoresAsync(int CodigoEmpresa, int IdTabla, int IdValor)
        {
            return await _context.CnfTablagenericavalores.Where(x => x.CodigoEmpresa == CodigoEmpresa && x.IdTabla == IdTabla && x.IdValor == IdValor)
                .AsNoTracking()
                .Include(e => e.CnfTablagenerica.CodigoEmpresaNavigation) //Empresa
                .Include(t => t.CnfTablagenerica) //Tabla
                .Include(s => s.CodigoEstadoNavigation) //Estado
                .FirstOrDefaultAsync();
        }
        
        public async Task<Response<object>> AddCnfTablaGenericaValoresAsync(CnfTablaGenericaValoresRequest cnfTablaGenericaValores)
        {
            try
            {

                var update = await _ConsecutivoHelper.updateConsecutivo(cnfTablaGenericaValores.CodigoEmpresa, "CNF_TABLAGENERICAVALORES");
                int consecutivo = await _ConsecutivoHelper.GetConsecutivo(cnfTablaGenericaValores.CodigoEmpresa, "CNF_TABLAGENERICAVALORES");

                var cnftablagenericavalores = new CnfTablagenericavalore
                {
                    CodigoEmpresa = cnfTablaGenericaValores.CodigoEmpresa,
                    IdTabla = cnfTablaGenericaValores.IdTabla,
                    IdValor = consecutivo,
                    CodigoValor = cnfTablaGenericaValores.CodigoValor,
                    Descripcion1 = cnfTablaGenericaValores.Descripcion1,
                    Descripcion2 = cnfTablaGenericaValores.Descripcion2,
                    Descripcion3 = cnfTablaGenericaValores.Descripcion3,
                    Descripcion4 = cnfTablaGenericaValores.Descripcion4,
                    Descripcion5 = cnfTablaGenericaValores.Descripcion5,
                    CodigoEstado = cnfTablaGenericaValores.CodigoEstado,
                    IdUsuario = cnfTablaGenericaValores.IdUsuario
                };

                _context.CnfTablagenericavalores.Add(cnftablagenericavalores);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "La tabla generica valores se creo con exito",
                    Result = cnftablagenericavalores
                });
            }
            catch (System.Exception)
            {
                throw new Exception("La tabla generica valores no fue creada");
            }
        }

        public async Task<Response<object>> EditCnfTablaGenericaValoresAsync(CnfTablaGenericaValoresRequest cnfTablaGenericaValores)
        {
            try
            {
                var exist = await _context.CnfTablagenericavalores.AnyAsync(x => x.CodigoEmpresa == cnfTablaGenericaValores.CodigoEmpresa && x.IdTabla == cnfTablaGenericaValores.IdTabla && x.IdValor == cnfTablaGenericaValores.IdValor);
                if (!exist)
                {
                    return (new Response<object>
                    {
                        IsSuccess = false,
                        Message = "Registro no encontrado",
                        Result = null
                    });
                }

                var cnftablagenericavalores = new CnfTablagenericavalore
                {
                    CodigoEmpresa = cnfTablaGenericaValores.CodigoEmpresa,
                    IdTabla = cnfTablaGenericaValores.IdTabla,
                    IdValor = cnfTablaGenericaValores.IdValor,
                    CodigoValor = cnfTablaGenericaValores.CodigoValor,
                    Descripcion1 = cnfTablaGenericaValores.Descripcion1,
                    Descripcion2 = cnfTablaGenericaValores.Descripcion2,
                    Descripcion3 = cnfTablaGenericaValores.Descripcion3,
                    Descripcion4 = cnfTablaGenericaValores.Descripcion4,
                    Descripcion5 = cnfTablaGenericaValores.Descripcion5,
                    CodigoEstado = cnfTablaGenericaValores.CodigoEstado,
                    IdUsuario = cnfTablaGenericaValores.IdUsuario
                };

                _context.Update(cnftablagenericavalores);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "Registro actualizado",
                    Result = cnftablagenericavalores
                });
            }
            catch (System.Exception)
            {
                throw new Exception("La tabla generica valores no fue modificada");
            }
        }
        
        public async Task<Response<object>> DeleteCnfTablaGenericaValoresAsync(CnfTablaGenericaValoresRequest cnfTablaGenericaValores)
        {
            try
            {
                var existe = await _context.CnfTablagenericavalores.AnyAsync(x => x.CodigoEmpresa == cnfTablaGenericaValores.CodigoEmpresa && x.IdTabla == cnfTablaGenericaValores.IdTabla && x.IdValor == cnfTablaGenericaValores.IdValor);
                if (!existe)
                {
                    return (new Response<Object>
                    {
                        IsSuccess = false,
                        Message = "El registro no existe",
                        Result = null
                    });
                }

                _context.Remove(new CnfTablagenericavalore() { CodigoEmpresa = cnfTablaGenericaValores.CodigoEmpresa, IdTabla = cnfTablaGenericaValores.IdTabla, IdValor = cnfTablaGenericaValores.IdValor });
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "La tabla generica valores fue eliminada",
                    Result = cnfTablaGenericaValores
                });
            }
            catch (System.Exception)
            {
                throw new Exception("No se pudo eliminar la tabla generica valores");
            }
        }
    }
}
