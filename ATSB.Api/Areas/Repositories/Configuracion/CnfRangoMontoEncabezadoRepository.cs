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
    public class CnfRangoMontoEncabezadoRepository : ICnfRangoMontoEncabezadoRepository
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IConsecutivoHelper _ConsecutivoHelper;

        public CnfRangoMontoEncabezadoRepository
        (
            ATSBIdentityDbContext context,
            IConsecutivoHelper ConsecutivoHelper
        ) : base()

        {
            _context = context;
            _ConsecutivoHelper = ConsecutivoHelper;
        }

        public IQueryable GetCnfRangoMontosEncabezados()
        {
            return _context.CnfRangomontoencabezados
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation)
                .Include(det => det.CnfRangomontodetalles); //Empresa
        }

        public async Task<CnfRangomontoencabezado> GetCnfRangoMontoEncabezadoAsync(int CodigoEmpresa, int CodigoTabla)
        {
            return await _context.CnfRangomontoencabezados.Where(x => x.CodigoEmpresa == CodigoEmpresa && x.CodigoTabla == CodigoTabla)
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation) //Empresa
                .FirstOrDefaultAsync();
        }

        public async Task<Response<object>> AddCnfRangoMontoEncabezadoAsync(CnfRangoMontoEncabezadoRequest cnfRangoMontoEncabezado)
        {
            try
            {

                var update = await _ConsecutivoHelper.updateConsecutivo(cnfRangoMontoEncabezado.CodigoEmpresa, "CNF_RANGOMONTOENCABEZADO");
                int consecutivo = await _ConsecutivoHelper.GetConsecutivo(cnfRangoMontoEncabezado.CodigoEmpresa, "CNF_RANGOMONTOENCABEZADO");

                var cnfrango = new CnfRangomontoencabezado
                {
                    CodigoEmpresa = cnfRangoMontoEncabezado.CodigoEmpresa,
                    CodigoTabla = consecutivo,
                    NombreTabla = cnfRangoMontoEncabezado.NombreTabla,
                    DescripcionProceso = cnfRangoMontoEncabezado.DescripcionProceso,
                    IdUsuario = cnfRangoMontoEncabezado.IdUsuario
                };

                _context.CnfRangomontoencabezados.Add(cnfrango);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "El rango monto encabezado se creo con exito",
                    Result = cnfrango
                });
            }
            catch (System.Exception)
            {
                throw new Exception("El rango monto encabezado no fue creado");
            }
        }

        public async Task<Response<object>> EditCnfRangoMontoEncabezadoAsync(CnfRangoMontoEncabezadoRequest cnfRangoMontoEncabezado)
        {
            try
            {
                var exist = await _context.CnfRangomontoencabezados.AnyAsync(x => x.CodigoEmpresa == cnfRangoMontoEncabezado.CodigoEmpresa && x.CodigoTabla == cnfRangoMontoEncabezado.CodigoTabla);
                if (!exist)
                {
                    return (new Response<object>
                    {
                        IsSuccess = false,
                        Message = "Registro no encontrado",
                        Result = null
                    });
                }

                var cnfrango = new CnfRangomontoencabezado
                {
                    CodigoEmpresa = cnfRangoMontoEncabezado.CodigoEmpresa,
                    CodigoTabla = cnfRangoMontoEncabezado.CodigoTabla,
                    NombreTabla = cnfRangoMontoEncabezado.NombreTabla,
                    DescripcionProceso = cnfRangoMontoEncabezado.DescripcionProceso,
                    IdUsuario = cnfRangoMontoEncabezado.IdUsuario
                };

                _context.Update(cnfrango);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "Registro actualizado",
                    Result = cnfrango
                });
            }
            catch (System.Exception)
            {
                throw new Exception("El rango monto encabezado no fue modificado");
            }
        }

        public async Task<Response<object>> DeleteCnfRangoMontoEncabezadoAsync(CnfRangoMontoEncabezadoRequest cnfRangoMontoEncabezado)
        {
            try
            {
                var existe = await _context.CnfRangomontoencabezados.AnyAsync(x => x.CodigoEmpresa == cnfRangoMontoEncabezado.CodigoEmpresa && x.CodigoTabla == cnfRangoMontoEncabezado.CodigoTabla);
                if (!existe)
                {
                    return (new Response<Object>
                    {
                        IsSuccess = false,
                        Message = "El registro no existe",
                        Result = null
                    });
                }

                _context.Remove(new CnfRangomontoencabezado() { CodigoEmpresa = cnfRangoMontoEncabezado.CodigoEmpresa, CodigoTabla = cnfRangoMontoEncabezado.CodigoTabla });
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "El rango monto encabezado fue eliminado",
                    Result = cnfRangoMontoEncabezado
                });
            }
            catch (System.Exception)
            {
                throw new Exception("No se pudo eliminar el rango monto encabezado");
            }
        }
    }
}
