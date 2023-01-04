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
    public class CnfTablaGenericaRepository : ICnfTablaGenericaRepository
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IConsecutivoHelper _ConsecutivoHelper;

        public CnfTablaGenericaRepository
        (
            ATSBIdentityDbContext context,
            IConsecutivoHelper ConsecutivoHelper
        ) : base()

        {
            _context = context;
            _ConsecutivoHelper = ConsecutivoHelper;
        }

        public IQueryable GetCnfTablasGenericas()
        {
            return _context.CnfTablagenericas
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation); //Empresa
        }

        public async Task<CnfTablagenerica> GetCnfTablaGenericaAsync(int CodigoEmpresa, int IdTabla)
        {
            return await _context.CnfTablagenericas.Where(x => x.CodigoEmpresa == CodigoEmpresa && x.IdTabla == IdTabla)
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation) //Empresa
                .FirstOrDefaultAsync();

        }

        public async Task<Response<object>> AddCnfTablaGenericaAsync(CnfTablaGenericaRequest cnfTablaGenerica)
        {
            try
            {

                var update = await _ConsecutivoHelper.updateConsecutivo(cnfTablaGenerica.CodigoEmpresa, "CNF_TABLAGENERICA");
                int consecutivo = await _ConsecutivoHelper.GetConsecutivo(cnfTablaGenerica.CodigoEmpresa, "CNF_TABLAGENERICA");

                var cnftablagenerica = new CnfTablagenerica
                {
                    CodigoEmpresa = cnfTablaGenerica.CodigoEmpresa,
                    IdTabla = consecutivo,
                    TablaParametros = cnfTablaGenerica.TablaParametros,
                    Descripcion = cnfTablaGenerica.Descripcion,
                    CantidadColumnas = cnfTablaGenerica.CantidadColumnas,
                    IdUsuario = cnfTablaGenerica.IdUsuario
                };

                _context.CnfTablagenericas.Add(cnftablagenerica);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "La tabla generica se creo con exito",
                    Result = cnftablagenerica
                });
            }
            catch (System.Exception)
            {
                throw new Exception("La tabla generica no fue creada");
            }
        }

        public async Task<Response<object>> EditCnfTablaGenericaAsync(CnfTablaGenericaRequest cnfTablaGenerica)
        {
            try
            {
                var exist = await _context.CnfTablagenericas.AnyAsync(x => x.CodigoEmpresa == cnfTablaGenerica.CodigoEmpresa && x.IdTabla == cnfTablaGenerica.IdTabla);
                if (!exist)
                {
                    return (new Response<object>
                    {
                        IsSuccess = false,
                        Message = "Registro no encontrado",
                        Result = null
                    });
                }

                var cnftablagenerica = new CnfTablagenerica
                {
                    CodigoEmpresa = cnfTablaGenerica.CodigoEmpresa,
                    IdTabla = cnfTablaGenerica.IdTabla,
                    TablaParametros = cnfTablaGenerica.TablaParametros,
                    Descripcion = cnfTablaGenerica.Descripcion,
                    CantidadColumnas = cnfTablaGenerica.CantidadColumnas,
                    IdUsuario = cnfTablaGenerica.IdUsuario
                };

                _context.Update(cnftablagenerica);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "Registro actualizado",
                    Result = cnftablagenerica
                });
            }
            catch (System.Exception)
            {
                throw new Exception("La tabla generica no fue modificada");
            }
        }
        
        public async Task<Response<object>> DeleteCnfTablaGenericaAsync(CnfTablaGenericaRequest cnfTablaGenerica)
        {
            try
            {
                var existe = await _context.CnfTablagenericas.AnyAsync(x => x.CodigoEmpresa == cnfTablaGenerica.CodigoEmpresa && x.IdTabla == cnfTablaGenerica.IdTabla);
                if (!existe)
                {
                    return (new Response<Object>
                    {
                        IsSuccess = false,
                        Message = "El registro no existe",
                        Result = null
                    });
                }

                _context.Remove(new CnfTablagenerica() { CodigoEmpresa = cnfTablaGenerica.CodigoEmpresa, IdTabla = cnfTablaGenerica.IdTabla });
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "La tabla generica fue eliminada",
                    Result = cnfTablaGenerica
                });
            }
            catch (System.Exception)
            {
                throw new Exception("No se pudo eliminar la tabla generica");
            }
        }
    }
}
