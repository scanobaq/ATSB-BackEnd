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
    public class CnfTablaRepository : ICnfTablaRepository
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IConsecutivoHelper _ConsecutivoHelper;

        public CnfTablaRepository
        (
            ATSBIdentityDbContext context,
            IConsecutivoHelper ConsecutivoHelper
        ) : base()

        {
            _context = context;
            _ConsecutivoHelper = ConsecutivoHelper;
        }

        public IQueryable GetCnfTablas()
        {
            return _context.CnfTablas
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation); //Empresa
        }

        public async Task<CnfTabla> GetCnfTablaAsync(int CodigoEmpresa, int CodigoTabla)
        {
            return await _context.CnfTablas.Where(x => x.CodigoEmpresa == CodigoEmpresa && x.CodigoTabla == CodigoTabla)
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation) //Empresa
                .FirstOrDefaultAsync();
        }

        public async Task<Response<object>> AddCnfTablaAsync(CnfTablaRequest cnfTabla)
        {
            try
            {

                var update = await _ConsecutivoHelper.updateConsecutivo(cnfTabla.CodigoEmpresa, "CNF_TABLA");
                int consecutivo = await _ConsecutivoHelper.GetConsecutivo(cnfTabla.CodigoEmpresa, "CNF_TABLA");

                var cnftabla = new CnfTabla
                {
                    CodigoEmpresa = cnfTabla.CodigoEmpresa,
                    CodigoTabla = consecutivo,
                    Tabla = cnfTabla.Tabla,
                    Descripcion = cnfTabla.Descripcion
                };

                _context.CnfTablas.Add(cnftabla);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "La tabla se creo con exito",
                    Result = cnftabla
                });
            }
            catch (System.Exception)
            {
                throw new Exception("La tabla no fue creada");
            }
        }

        public async Task<Response<object>> EditCnfTablaAsync(CnfTablaRequest cnfTabla)
        {
            try
            {
                var exist = await _context.CnfTablas.AnyAsync(x => x.CodigoEmpresa == cnfTabla.CodigoEmpresa && x.CodigoTabla == cnfTabla.CodigoTabla);
                if (!exist)
                {
                    return (new Response<object>
                    {
                        IsSuccess = false,
                        Message = "Registro no encontrado",
                        Result = null
                    });
                }

                var cnftabla = new CnfTabla
                {
                    CodigoEmpresa = cnfTabla.CodigoEmpresa,
                    CodigoTabla = cnfTabla.CodigoTabla,
                    Tabla = cnfTabla.Tabla,
                    Descripcion = cnfTabla.Descripcion
                };

                _context.Update(cnftabla);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "Registro actualizado",
                    Result = cnftabla
                });
            }
            catch (System.Exception)
            {
                throw new Exception("La tabla no fue modificada");
            }
        }

        public async Task<Response<object>> DeleteCnfTablaAsync(CnfTablaRequest cnfTabla)
        {
            try
            {
                var existe = await _context.CnfTablas.AnyAsync(x => x.CodigoEmpresa == cnfTabla.CodigoEmpresa && x.CodigoTabla == cnfTabla.CodigoTabla);
                if (!existe)
                {
                    return (new Response<Object>
                    {
                        IsSuccess = false,
                        Message = "El registro no existe",
                        Result = null
                    });
                }

                _context.Remove(new CnfTabla() { CodigoEmpresa = cnfTabla.CodigoEmpresa, CodigoTabla = cnfTabla.CodigoTabla });
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "La tabla fue eliminada",
                    Result = cnfTabla
                });
            }
            catch (System.Exception)
            {
                throw new Exception("No se pudo eliminar la tabla");
            }
        }
    }
}
