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
    public class CnfTablaValorRepository : ICnfTablaValorRepository
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IConsecutivoHelper _ConsecutivoHelper;

        public CnfTablaValorRepository
        (
            ATSBIdentityDbContext context,
            IConsecutivoHelper ConsecutivoHelper
        ) : base()

        {
            _context = context;
            _ConsecutivoHelper = ConsecutivoHelper;
        }

        public IQueryable GetCnfTablaValores()
        {
            return _context.CnfTablavalors
                .AsNoTracking()
                .Include(e => e.CodigoNavigation.CodigoEmpresaNavigation) //Empresa
                .Include(t => t.CodigoNavigation) //Tabla
                .Include(s => s.CodigoEstadoNavigation); //Estado
        }

        public async Task<CnfTablavalor> GetCnfTablaValorAsync(int CodigoEmpresa, int CodigoTabla, int IdValor)
        {
            return await _context.CnfTablavalors.Where(x => x.CodigoEmpresa == CodigoEmpresa && x.CodigoTabla == CodigoTabla && x.IdValor == IdValor)
                .AsNoTracking()
                .Include(e => e.CodigoNavigation.CodigoEmpresaNavigation) //Empresa
                .Include(t => t.CodigoNavigation) //Tabla
                .Include(s => s.CodigoEstadoNavigation) //Estado
                .FirstOrDefaultAsync();
        }

        public async Task<Response<object>> AddCnfTablaValorAsync(CnfTablaValorRequest cnfTablaValor)
        {
            try
            {

                var cnftablavalor = new CnfTablavalor
                {
                    CodigoEmpresa = cnfTablaValor.CodigoEmpresa,
                    CodigoTabla = cnfTablaValor.CodigoTabla,
                    IdValor = cnfTablaValor.IdValor,
                    Codigo = cnfTablaValor.Codigo,
                    Valor = cnfTablaValor.Valor,
                    CodigoEstado = cnfTablaValor.CodigoEstado
                };

                _context.CnfTablavalors.Add(cnftablavalor);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "La tabla valor se creo con exito",
                    Result = cnftablavalor
                });
            }
            catch (System.Exception)
            {
                throw new Exception("La tabla valor no fue creada");
            }
        }

        public async Task<Response<object>> EditCnfTablaValorAsync(CnfTablaValorRequest cnfTablaValor)
        {
            try
            {
                var exist = await _context.CnfTablavalors.AnyAsync(x => x.CodigoEmpresa == cnfTablaValor.CodigoEmpresa && x.CodigoTabla == cnfTablaValor.CodigoTabla && x.IdValor == cnfTablaValor.IdValor);
                if (!exist)
                {
                    return (new Response<object>
                    {
                        IsSuccess = false,
                        Message = "Registro no encontrado",
                        Result = null
                    });
                }

                var cnftablavalor = new CnfTablavalor
                {
                    CodigoEmpresa = cnfTablaValor.CodigoEmpresa,
                    CodigoTabla = cnfTablaValor.CodigoTabla,
                    IdValor = cnfTablaValor.IdValor,
                    Codigo = cnfTablaValor.Codigo,
                    Valor = cnfTablaValor.Valor,
                    CodigoEstado = cnfTablaValor.CodigoEstado
                };

                _context.Update(cnftablavalor);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "Registro actualizado",
                    Result = cnftablavalor
                });
            }
            catch (System.Exception)
            {
                throw new Exception("La tabla valor no fue modificada");
            }
        }

        public async Task<Response<object>> DeleteCnfTablaValorAsync(CnfTablaValorRequest cnfTablaValor)
        {
            try
            {
                var existe = await _context.CnfTablavalors.AnyAsync(x => x.CodigoEmpresa == cnfTablaValor.CodigoEmpresa && x.CodigoTabla == cnfTablaValor.CodigoTabla && x.IdValor == cnfTablaValor.IdValor);
                if (!existe)
                {
                    return (new Response<Object>
                    {
                        IsSuccess = false,
                        Message = "El registro no existe",
                        Result = null
                    });
                }

                _context.Remove(new CnfTablavalor() { CodigoEmpresa = cnfTablaValor.CodigoEmpresa, CodigoTabla = cnfTablaValor.CodigoTabla, IdValor = cnfTablaValor.IdValor });
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "La tabla valor fue eliminada",
                    Result = cnfTablaValor
                });
            }
            catch (System.Exception)
            {
                throw new Exception("No se pudo eliminar la tabla valor");
            }
        }
    }
}
