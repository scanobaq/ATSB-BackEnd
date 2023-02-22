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
    public class LiqRubroProcesoRepository : ILiqRubroProcesoRepository
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IConsecutivoHelper _ConsecutivoHelper;

        public LiqRubroProcesoRepository
        (
            ATSBIdentityDbContext context,
            IConsecutivoHelper ConsecutivoHelper
        ) : base()

        {
            _context = context;
            _ConsecutivoHelper = ConsecutivoHelper;
        }

        public IQueryable GetLiqRubroProcesos()
        {
            return _context.LiqRubroprocesos
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation); //Empresa
        }

        public async Task<LiqRubroproceso> GetLiqRubroProcesoAsync(int CodigoEmpresa, int Rubro)
        {
            return await _context.LiqRubroprocesos.Where(x => x.CodigoEmpresa == CodigoEmpresa && x.Rubro == Rubro)
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation) //Empresa
                .FirstOrDefaultAsync();
        }

        public async Task<Response<object>> AddLiqRubroProcesoAsync(LiqRubroProcesoRequest liqRubroProceso)
        {
            try
            {
                var liqrubroproceso = new LiqRubroproceso
                {
                    CodigoEmpresa = liqRubroProceso.CodigoEmpresa,
                    Rubro = liqRubroProceso.Rubro,
                    Proceso = liqRubroProceso.Proceso,
                    IdUsuario = liqRubroProceso.IdUsuario
                };

                _context.LiqRubroprocesos.Add(liqrubroproceso);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "El rubro proceso se creo con exito",
                    Result = liqrubroproceso
                });
            }
            catch (System.Exception)
            {
                throw new Exception("El rubro proceso no fue creado");
            }
        }

        public async Task<Response<object>> EditLiqRubroProcesoAsync(LiqRubroProcesoRequest liqRubroProceso)
        {
            try
            {
                var exist = await _context.LiqRubroprocesos.AnyAsync(x => x.CodigoEmpresa == liqRubroProceso.CodigoEmpresa && x.Rubro == liqRubroProceso.Rubro);
                if (!exist)
                {
                    return (new Response<object>
                    {
                        IsSuccess = false,
                        Message = "Registro no encontrado",
                        Result = null
                    });
                }

                var liqrubroproceso = new LiqRubroproceso
                {
                    CodigoEmpresa = liqRubroProceso.CodigoEmpresa,
                    Rubro = liqRubroProceso.Rubro,
                    Proceso = liqRubroProceso.Proceso,
                    IdUsuario = liqRubroProceso.IdUsuario
                };

                _context.Update(liqrubroproceso);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "Registro actualizado",
                    Result = liqrubroproceso
                });
            }
            catch (System.Exception)
            {
                throw new Exception("El rubro proceso no fue modificado");
            }
        }

        public async Task<Response<object>> DeleteLiqRubroProcesoAsync(LiqRubroProcesoRequest liqRubroProceso)
        {
            try
            {
                var existe = await _context.LiqRubroprocesos.AnyAsync(x => x.CodigoEmpresa == liqRubroProceso.CodigoEmpresa && x.Rubro == liqRubroProceso.Rubro);
                if (!existe)
                {
                    return (new Response<Object>
                    {
                        IsSuccess = false,
                        Message = "El registro no existe",
                        Result = null
                    });
                }

                _context.Remove(new LiqRubroproceso() { CodigoEmpresa = liqRubroProceso.CodigoEmpresa, Rubro = liqRubroProceso.Rubro });
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "El rubro proceso fue eliminado",
                    Result = liqRubroProceso
                });
            }
            catch (System.Exception)
            {
                throw new Exception("No se pudo eliminar el rubro proceso");
            }
        }
    }
}
