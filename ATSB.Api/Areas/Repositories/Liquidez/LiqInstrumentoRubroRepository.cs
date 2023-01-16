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
    public class LiqInstrumentoRubroRepository : ILiqInstrumentoRubroRepository
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IConsecutivoHelper _ConsecutivoHelper;

        public LiqInstrumentoRubroRepository
        (
            ATSBIdentityDbContext context,
            IConsecutivoHelper ConsecutivoHelper
        ) : base()

        {
            _context = context;
            _ConsecutivoHelper = ConsecutivoHelper;
        }

        public IQueryable GetLiqInstrumentosRubros()
        {
            return _context.LiqInstrumentorubros
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation); //Empresa
        }

        public async Task<LiqInstrumentorubro> GetLiqInstrumentoRubroAsync(int CodigoEmpresa, string Instrumento, string CodigoRegion, int CodigoRubro)
        {
            return await _context.LiqInstrumentorubros.Where(x => x.CodigoEmpresa == CodigoEmpresa && x.Instrumento == Instrumento && x.CodigoRegion == CodigoRegion && x.CodigoRubro == CodigoRubro)
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation) //Empresa
                .FirstOrDefaultAsync();
        }

        public async Task<Response<object>> AddLiqInstrumentoRubroAsync(LiqInstrumentoRubroRequest liqInstrumentoRubro)
        {
            try
            {
                var liqinstrumentorubro = new LiqInstrumentorubro
                {
                    CodigoEmpresa = liqInstrumentoRubro.CodigoEmpresa,
                    Instrumento = liqInstrumentoRubro.Instrumento,
                    CodigoRegion = liqInstrumentoRubro.CodigoRegion,
                    CodigoRubro = liqInstrumentoRubro.CodigoRubro,
                    CodigoEstado = liqInstrumentoRubro.CodigoEstado == "true" ? true : false,
                    IdUsuario = liqInstrumentoRubro.IdUsuario
                };

                _context.LiqInstrumentorubros.Add(liqinstrumentorubro);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "El instrumento rubro se creo con exito",
                    Result = liqinstrumentorubro
                });
            }
            catch (System.Exception)
            {
                throw new Exception("El instrumento rubro no fue creado");
            }
        }

        public async Task<Response<object>> EditLiqInstrumentoRubroAsync(LiqInstrumentoRubroRequest liqInstrumentoRubro)
        {
            try
            {
                var exist = await _context.LiqInstrumentorubros.AnyAsync(x => x.CodigoEmpresa == liqInstrumentoRubro.CodigoEmpresa && x.Instrumento == liqInstrumentoRubro.Instrumento && x.CodigoRegion == liqInstrumentoRubro.CodigoRegion && x.CodigoRubro == liqInstrumentoRubro.CodigoRubro);
                if (!exist)
                {
                    return (new Response<object>
                    {
                        IsSuccess = false,
                        Message = "Registro no encontrado",
                        Result = null
                    });
                }

                var liqinstrumentorubro = new LiqInstrumentorubro
                {
                    CodigoEmpresa = liqInstrumentoRubro.CodigoEmpresa,
                    Instrumento = liqInstrumentoRubro.Instrumento,
                    CodigoRegion = liqInstrumentoRubro.CodigoRegion,
                    CodigoRubro = liqInstrumentoRubro.CodigoRubro,
                    CodigoEstado = liqInstrumentoRubro.CodigoEstado == "true" ? true : false,
                    IdUsuario = liqInstrumentoRubro.IdUsuario
                };

                _context.Update(liqinstrumentorubro);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "Registro actualizado",
                    Result = liqinstrumentorubro
                });
            }
            catch (System.Exception)
            {
                throw new Exception("El instrumento rubro no fue modificado");
            }
        }

        public async Task<Response<object>> DeleteLiqInstrumentoRubroAsync(LiqInstrumentoRubroRequest liqInstrumentoRubro)
        {
            try
            {
                var existe = await _context.LiqInstrumentorubros.AnyAsync(x => x.CodigoEmpresa == liqInstrumentoRubro.CodigoEmpresa && x.Instrumento == liqInstrumentoRubro.Instrumento && x.CodigoRegion == liqInstrumentoRubro.CodigoRegion && x.CodigoRubro == liqInstrumentoRubro.CodigoRubro);
                if (!existe)
                {
                    return (new Response<Object>
                    {
                        IsSuccess = false,
                        Message = "El registro no existe",
                        Result = null
                    });
                }

                _context.Remove(new LiqInstrumentorubro() { CodigoEmpresa = liqInstrumentoRubro.CodigoEmpresa, Instrumento = liqInstrumentoRubro.Instrumento, CodigoRegion = liqInstrumentoRubro.CodigoRegion, CodigoRubro = liqInstrumentoRubro.CodigoRubro });
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "El instrumento rubro fue eliminado",
                    Result = liqInstrumentoRubro
                });
            }
            catch (System.Exception)
            {
                throw new Exception("No se pudo eliminar el instrumento rubro");
            }
        }
    }
}
