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
    public class CnfRangoMontoDetalleRepository : ICnfRangoMontoDetalleRepository
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IConsecutivoHelper _ConsecutivoHelper;

        public CnfRangoMontoDetalleRepository
        (
            ATSBIdentityDbContext context,
            IConsecutivoHelper ConsecutivoHelper
        ) : base()

        {
            _context = context;
            _ConsecutivoHelper = ConsecutivoHelper;
        }

        public IQueryable GetCnfRangoMontosDetalles()
        {
            return _context.CnfRangomontodetalles
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation) //Empresa
                .Include(me => me.Codigo) //RangoMontoEncabezado
                .Include(s => s.CodigoEstadoNavigation); //Estado
        }

        public async Task<CnfRangomontodetalle> GetCnfRangoMontoDetalleAsync(int CodigoEmpresa, int CodigoTabla, string CodigoRango)
        {
            return await _context.CnfRangomontodetalles.Where(x => x.CodigoEmpresa == CodigoEmpresa && x.CodigoTabla == CodigoTabla && x.CodigoRango == CodigoRango)
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation) //Empresa
                .Include(me => me.Codigo) //RangoMontoEncabezado
                .Include(s => s.CodigoEstadoNavigation) //Estado
                .FirstOrDefaultAsync();
        }
        
        public async Task<Response<object>> AddCnfRangoMontoDetalleAsync(CnfRangoMontoDetalleRequest cnfRangoMontoDetalle)
        {
            try
            {

                var cnfrango = new CnfRangomontodetalle
                {
                    CodigoEmpresa = cnfRangoMontoDetalle.CodigoEmpresa,
                    CodigoTabla = cnfRangoMontoDetalle.CodigoTabla,
                    CodigoRango = cnfRangoMontoDetalle.CodigoRango,
                    Descripcion = cnfRangoMontoDetalle.Descripcion,
                    RangoMinimo = cnfRangoMontoDetalle.RangoMinimo,
                    RangoMaximo = cnfRangoMontoDetalle.RangoMaximo,
                    RangoValor = cnfRangoMontoDetalle.RangoValor,
                    CodigoEstado = cnfRangoMontoDetalle.CodigoEstado,
                    IdUsuario = cnfRangoMontoDetalle.IdUsuario
                };

                _context.CnfRangomontodetalles.Add(cnfrango);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "El rango monto detalle se creo con exito",
                    Result = cnfrango
                });
            }
            catch (System.Exception)
            {
                throw new Exception("El rango monto detalle no fue creado");
            }
        }

        public async Task<Response<object>> EditCnfRangoMontoDetalleAsync(CnfRangoMontoDetalleRequest cnfRangoMontoDetalle)
        {
            try
            {
                var exist = await _context.CnfRangomontodetalles.AnyAsync(x => x.CodigoEmpresa == cnfRangoMontoDetalle.CodigoEmpresa && x.CodigoTabla == cnfRangoMontoDetalle.CodigoTabla && x.CodigoRango == cnfRangoMontoDetalle.CodigoRango);
                if (!exist)
                {
                    return (new Response<object>
                    {
                        IsSuccess = false,
                        Message = "Registro no encontrado",
                        Result = null
                    });
                }

                var cnfrango = new CnfRangomontodetalle
                {
                    CodigoEmpresa = cnfRangoMontoDetalle.CodigoEmpresa,
                    CodigoTabla = cnfRangoMontoDetalle.CodigoTabla,
                    CodigoRango = cnfRangoMontoDetalle.CodigoRango,
                    Descripcion = cnfRangoMontoDetalle.Descripcion,
                    RangoMinimo = cnfRangoMontoDetalle.RangoMinimo,
                    RangoMaximo = cnfRangoMontoDetalle.RangoMaximo,
                    RangoValor = cnfRangoMontoDetalle.RangoValor,
                    CodigoEstado = cnfRangoMontoDetalle.CodigoEstado,
                    IdUsuario = cnfRangoMontoDetalle.IdUsuario
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
                throw new Exception("El rango monto detalle no fue modificado");
            }
        }

        public async Task<Response<object>> DeleteCnfRangoMontoDetalleAsync(CnfRangoMontoDetalleRequest cnfRangoMontoDetalle)
        {
            try
            {
                var existe = await _context.CnfRangomontodetalles.AnyAsync(x => x.CodigoEmpresa == cnfRangoMontoDetalle.CodigoEmpresa && x.CodigoTabla == cnfRangoMontoDetalle.CodigoTabla && x.CodigoRango == cnfRangoMontoDetalle.CodigoRango);
                if (!existe)
                {
                    return (new Response<Object>
                    {
                        IsSuccess = false,
                        Message = "El registro no existe",
                        Result = null
                    });
                }

                _context.Remove(new CnfRangomontodetalle() { CodigoEmpresa = cnfRangoMontoDetalle.CodigoEmpresa, CodigoTabla = cnfRangoMontoDetalle.CodigoTabla, CodigoRango = cnfRangoMontoDetalle.CodigoRango });
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "El rango monto detalle fue eliminado",
                    Result = cnfRangoMontoDetalle
                });
            }
            catch (System.Exception)
            {
                throw new Exception("No se pudo eliminar el rango monto detalle");
            }
        }
    }
}
