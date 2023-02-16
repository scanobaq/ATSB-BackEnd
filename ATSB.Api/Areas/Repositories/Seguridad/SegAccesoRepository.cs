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
using ATSB.Api.Models.Seguridad;
using ATSB.Api.Areas.Entities.Seguridad;
using ATSB.Api.Areas.Entities.Credito;

namespace ATSB.Api.Areas.Repositories.Seguridad
{
    public class SegAccesoRepository : ISegAccesoRepository
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IConsecutivoHelper _ConsecutivoHelper;

        public SegAccesoRepository
        (
            ATSBIdentityDbContext context,
            IConsecutivoHelper ConsecutivoHelper
        ) : base()

        {
            _context = context;
            _ConsecutivoHelper = ConsecutivoHelper;
        }

        public IQueryable GetSegAccesos()
        {
            return _context.SegAccesos
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation); //Empresa
        }

        public async Task<SegAcceso> GetSegAccesoAsync(int CodigoEmpresa, int CodigoTipoAcceso)
        {
            return await _context.SegAccesos.Where(x => x.CodigoEmpresa == CodigoEmpresa && x.CodigoTipoAcceso == CodigoTipoAcceso)
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation) //Empresa
                .FirstOrDefaultAsync();
        }

        public async Task<Response<object>> AddSegAccesoAsync(SegAccesoRequest segAcceso)
        {
            try
            {
                var update = await _ConsecutivoHelper.updateConsecutivo(segAcceso.CodigoEmpresa, "SEG_ACCESO");
                int consecutivo = await _ConsecutivoHelper.GetConsecutivo(segAcceso.CodigoEmpresa, "SEG_ACCESO");

                var segacceso = new SegAcceso
                {
                    CodigoEmpresa = segAcceso.CodigoEmpresa,
                    CodigoTipoAcceso = consecutivo,
                    Descripcion = segAcceso.Descripcion,
                    IndicadorLunes = segAcceso.IndicadorLunes == "true" ? true : false,
                    HoraInicioLunes = segAcceso.HoraInicioLunes,
                    HoraFinLunes = segAcceso.HoraFinLunes,
                    IndicadorMartes = segAcceso.IndicadorMartes == "true" ? true : false,
                    HoraInicioMartes = segAcceso.HoraInicioMartes,
                    HoraFinMartes = segAcceso.HoraFinMartes,
                    IndicadorMiercoles = segAcceso.IndicadorMiercoles == "true" ? true : false,
                    HoraInicioMiercoles = segAcceso.HoraInicioMiercoles,
                    HoraFinMiercoles = segAcceso.HoraFinMiercoles,
                    IndicadorJueves = segAcceso.IndicadorJueves == "true" ? true : false,
                    HoraInicioJueves = segAcceso.HoraInicioJueves,
                    HoraFinJueves = segAcceso.HoraFinJueves,
                    IndicadorViernes = segAcceso.IndicadorViernes == "true" ? true : false,
                    HoraInicioViernes = segAcceso.HoraInicioViernes,
                    HoraFinViernes = segAcceso.HoraFinViernes,
                    IndicadorSabado = segAcceso.IndicadorSabado == "true" ? true : false,
                    HoraInicioSabado = segAcceso.HoraInicioSabado,
                    HoraFinSabado = segAcceso.HoraFinSabado,
                    IndicadorDomingo = segAcceso.IndicadorDomingo == "true" ? true : false,
                    HoraInicioDomingo = segAcceso.HoraInicioDomingo,
                    HoraFinDomingo = segAcceso.HoraFinDomingo,
                    IndicadorFestivo = segAcceso.IndicadorFestivo == "true" ? true : false,
                    HoraInicioFestivo = segAcceso.HoraInicioFestivo,
                    HoraFinFestivo = segAcceso.HoraFinFestivo,
                    IdUsuario = segAcceso.IdUsuario,
                    Id = segAcceso.Id
                };

                _context.SegAccesos.Add(segacceso);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "El acceso se creo con exito",
                    Result = segacceso
                });
            }
            catch (System.Exception)
            {
                throw new Exception("El acceso no fue creado");
            }
        }

        public async Task<Response<object>> EditSegAccesoAsync(SegAccesoRequest segAcceso)
        {
            try
            {
                var exist = await _context.SegAccesos.AnyAsync(x => x.CodigoEmpresa == segAcceso.CodigoEmpresa && x.CodigoTipoAcceso == segAcceso.CodigoTipoAcceso);
                if (!exist)
                {
                    return (new Response<object>
                    {
                        IsSuccess = false,
                        Message = "Registro no encontrado",
                        Result = null
                    });
                }

                var segacceso = new SegAcceso
                {
                    CodigoEmpresa = segAcceso.CodigoEmpresa,
                    CodigoTipoAcceso = segAcceso.CodigoTipoAcceso,
                    Descripcion = segAcceso.Descripcion,
                    IndicadorLunes = segAcceso.IndicadorLunes == "true" ? true : false,
                    HoraInicioLunes = segAcceso.HoraInicioLunes,
                    HoraFinLunes = segAcceso.HoraFinLunes,
                    IndicadorMartes = segAcceso.IndicadorMartes == "true" ? true : false,
                    HoraInicioMartes = segAcceso.HoraInicioMartes,
                    HoraFinMartes = segAcceso.HoraFinMartes,
                    IndicadorMiercoles = segAcceso.IndicadorMiercoles == "true" ? true : false,
                    HoraInicioMiercoles = segAcceso.HoraInicioMiercoles,
                    HoraFinMiercoles = segAcceso.HoraFinMiercoles,
                    IndicadorJueves = segAcceso.IndicadorJueves == "true" ? true : false,
                    HoraInicioJueves = segAcceso.HoraInicioJueves,
                    HoraFinJueves = segAcceso.HoraFinJueves,
                    IndicadorViernes = segAcceso.IndicadorViernes == "true" ? true : false,
                    HoraInicioViernes = segAcceso.HoraInicioViernes,
                    HoraFinViernes = segAcceso.HoraFinViernes,
                    IndicadorSabado = segAcceso.IndicadorSabado == "true" ? true : false,
                    HoraInicioSabado = segAcceso.HoraInicioSabado,
                    HoraFinSabado = segAcceso.HoraFinSabado,
                    IndicadorDomingo = segAcceso.IndicadorDomingo == "true" ? true : false,
                    HoraInicioDomingo = segAcceso.HoraInicioDomingo,
                    HoraFinDomingo = segAcceso.HoraFinDomingo,
                    IndicadorFestivo = segAcceso.IndicadorFestivo == "true" ? true : false,
                    HoraInicioFestivo = segAcceso.HoraInicioFestivo,
                    HoraFinFestivo = segAcceso.HoraFinFestivo,
                    IdUsuario = segAcceso.IdUsuario,
                    Id = segAcceso.Id
                };

                _context.Update(segacceso);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "Registro actualizado",
                    Result = segacceso
                });
            }
            catch (System.Exception)
            {
                throw new Exception("El acceso no fue modificado");
            }
        }

        public async Task<Response<object>> DeleteSegAccesoAsync(SegAccesoRequest segAcceso)
        {
            try
            {
                var existe = await _context.SegAccesos.AnyAsync(x => x.CodigoEmpresa == segAcceso.CodigoEmpresa && x.CodigoTipoAcceso == segAcceso.CodigoTipoAcceso);
                if (!existe)
                {
                    return (new Response<Object>
                    {
                        IsSuccess = false,
                        Message = "El registro no existe",
                        Result = null
                    });
                }

                _context.Remove(new SegAcceso() { CodigoEmpresa = segAcceso.CodigoEmpresa, CodigoTipoAcceso = segAcceso.CodigoTipoAcceso });
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "El acceso fue eliminado",
                    Result = segAcceso
                });
            }
            catch (System.Exception)
            {
                throw new Exception("No se pudo eliminar el acceso");
            }
        }
    }
}
