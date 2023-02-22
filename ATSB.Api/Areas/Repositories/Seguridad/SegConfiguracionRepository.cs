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
    public class SegConfiguracionRepository : ISegConfiguracionRepository
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IConsecutivoHelper _ConsecutivoHelper;

        public SegConfiguracionRepository
        (
            ATSBIdentityDbContext context,
            IConsecutivoHelper ConsecutivoHelper
        ) : base()

        {
            _context = context;
            _ConsecutivoHelper = ConsecutivoHelper;
        }

        public IQueryable GetSegConfiguraciones()
        {
            return _context.SegConfiguracions
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation) //Empresa
                .Include(s => s.CodigoEstadoNavigation); //Estado
        }

        public async Task<SegConfiguracion> GetSegConfiguracionAsync(int CodigoEmpresa, int IdParametro)
        {
            return await _context.SegConfiguracions.Where(x => x.CodigoEmpresa == CodigoEmpresa && x.IdParametro == IdParametro)
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation) //Empresa
                .Include(s => s.CodigoEstadoNavigation) //Estado
                .FirstOrDefaultAsync();
        }
        
        public async Task<Response<object>> AddSegConfiguracionAsync(SegConfiguracionRequest segConfiguracion)
        {
            try
            {
                var lastIdParametro = _context.SegConfiguracions.Max(x => x.IdParametro);
                var segConfig = _context.SegConfiguracions.Where(x => x.CodigoEmpresa == segConfiguracion.CodigoEmpresa && x.IdParametro == lastIdParametro).FirstOrDefault();

                if (segConfig != null)
                {
                    if (segConfig.CodigoEstado == 1)
                    {
                        segConfig.CodigoEstado = 2;
                        _context.SaveChanges();
                    }
                }


                var update = await _ConsecutivoHelper.updateConsecutivo(segConfiguracion.CodigoEmpresa, "SEG_CONFIGURACION");
                int consecutivo = await _ConsecutivoHelper.GetConsecutivo(segConfiguracion.CodigoEmpresa, "SEG_CONFIGURACION");

                var segconfiguracion = new SegConfiguracion
                {
                    CodigoEmpresa = segConfiguracion.CodigoEmpresa,
                    IdParametro = consecutivo,
                    FechaHoraIngreso = segConfiguracion.FechaHoraIngreso,
                    CantidadDiasVigenciaPassword = segConfiguracion.CantidadDiasVigenciaPassword,
                    CantidadMinimaCaracteresClave = segConfiguracion.CantidadMinimaCaracteresClave,
                    CantidadIntentosFallidos = segConfiguracion.CantidadIntentosFallidos,
                    IndicadorPermiteRepetirPassword = segConfiguracion.IndicadorPermiteRepetirPassword == "true" ? true : false,
                    CantidadClavesParaRepetir = segConfiguracion.CantidadClavesParaRepetir,
                    CantidadMayusculasClave = segConfiguracion.CantidadMayusculasClave,
                    CantidadNumeroClave = segConfiguracion.CantidadNumeroClave,
                    CantidadCaracterEspecial = segConfiguracion.CantidadCaracterEspecial,
                    IdUsuario = segConfiguracion.IdUsuario,
                    CodigoEstado = segConfiguracion.CodigoEstado
                };

                _context.SegConfiguracions.Add(segconfiguracion);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "La configuracion se creo con exito",
                    Result = segconfiguracion
                });
            }
            catch (System.Exception)
            {
                throw new Exception("El estado no fue creado");
            }
        }
    }
}
