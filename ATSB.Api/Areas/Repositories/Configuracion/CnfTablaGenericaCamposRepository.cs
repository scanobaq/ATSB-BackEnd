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
    public class CnfTablaGenericaCamposRepository : ICnfTablaGenericaCamposRepository
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IConsecutivoHelper _ConsecutivoHelper;

        public CnfTablaGenericaCamposRepository
        (
            ATSBIdentityDbContext context,
            IConsecutivoHelper ConsecutivoHelper
        ) : base()

        {
            _context = context;
            _ConsecutivoHelper = ConsecutivoHelper;
        }

        public IQueryable GetCnfTablasGenericasCampos()
        {
            return _context.CnfTablagenericacampos
                .AsNoTracking()
                .Include(tg => tg.CnfTablagenerica) //TablaGenerica
                .Include(e => e.CnfTablagenerica.CodigoEmpresaNavigation); //Empresa
        }

        public async Task<CnfTablagenericacampo> GetCnfTablaGenericaCamposAsync(int CodigoEmpresa, int IdTabla, string IdCampo)
        {
            return await _context.CnfTablagenericacampos.Where(x => x.CodigoEmpresa == CodigoEmpresa && x.IdTabla == IdTabla && x.IdCampo == IdCampo)
                .AsNoTracking()
                .Include(tg => tg.CnfTablagenerica) //TablaGenerica
                .Include(e => e.CnfTablagenerica.CodigoEmpresaNavigation) //Empresa
                .FirstOrDefaultAsync();
        }

        public async Task<Response<object>> AddCnfTablaGenericaCamposAsync(CnfTablaGenericaCamposRequest cnfTablaGenericaCampos)
        {
            try
            {

                var cnftablagenericacampos = new CnfTablagenericacampo
                {
                    CodigoEmpresa = cnfTablaGenericaCampos.CodigoEmpresa,
                    IdTabla = cnfTablaGenericaCampos.IdTabla,
                    IdCampo = cnfTablaGenericaCampos.IdCampo,
                    NombreCampo = cnfTablaGenericaCampos.NombreCampo,
                    Etiqueta = cnfTablaGenericaCampos.Etiqueta,
                    IdUsuario = cnfTablaGenericaCampos.IdUsuario
                };

                _context.CnfTablagenericacampos.Add(cnftablagenericacampos);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "El campo de tabla generica se creo con exito",
                    Result = cnftablagenericacampos
                });
            }
            catch (System.Exception)
            {
                throw new Exception("El campo de tabla generica no fue creado");
            }
        }

        public async Task<Response<object>> EditCnfTablaGenericaCamposAsync(CnfTablaGenericaCamposRequest cnfTablaGenericaCampos)
        {
            try
            {
                var exist = await _context.CnfTablagenericacampos.AnyAsync(x => x.CodigoEmpresa == cnfTablaGenericaCampos.CodigoEmpresa && x.IdTabla == cnfTablaGenericaCampos.IdTabla && x.IdCampo == cnfTablaGenericaCampos.IdCampo);
                if (!exist)
                {
                    return (new Response<object>
                    {
                        IsSuccess = false,
                        Message = "Registro no encontrado",
                        Result = null
                    });
                }

                var cnftablagenericacampos = new CnfTablagenericacampo
                {
                    CodigoEmpresa = cnfTablaGenericaCampos.CodigoEmpresa,
                    IdTabla = cnfTablaGenericaCampos.IdTabla,
                    IdCampo = cnfTablaGenericaCampos.IdCampo,
                    NombreCampo = cnfTablaGenericaCampos.NombreCampo,
                    Etiqueta = cnfTablaGenericaCampos.Etiqueta,
                    IdUsuario = cnfTablaGenericaCampos.IdUsuario
                };

                _context.Update(cnftablagenericacampos);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "Registro actualizado",
                    Result = cnftablagenericacampos
                });
            }
            catch (System.Exception)
            {
                throw new Exception("El campo de tabla generica no fue modificado");
            }
        }

        public async Task<Response<object>> DeleteCnfTablaGenericaCamposAsync(CnfTablaGenericaCamposRequest cnfTablaGenericaCampos)
        {
            try
            {
                var existe = await _context.CnfTablagenericacampos.AnyAsync(x => x.CodigoEmpresa == cnfTablaGenericaCampos.CodigoEmpresa && x.IdTabla == cnfTablaGenericaCampos.IdTabla && x.IdCampo == cnfTablaGenericaCampos.IdCampo);
                if (!existe)
                {
                    return (new Response<Object>
                    {
                        IsSuccess = false,
                        Message = "El registro no existe",
                        Result = null
                    });
                }

                _context.Remove(new CnfTablagenericacampo() { CodigoEmpresa = cnfTablaGenericaCampos.CodigoEmpresa, IdTabla = cnfTablaGenericaCampos.IdTabla, IdCampo = cnfTablaGenericaCampos.IdCampo });
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "El campo de tabla generica fue eliminado",
                    Result = cnfTablaGenericaCampos
                });
            }
            catch (System.Exception)
            {
                throw new Exception("No se pudo eliminar el campo de tabla generica");
            }
        }
    }
}
