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
    public class CnfEjecucionReportesRepository : ICnfEjecucionReportesRepository
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IConsecutivoHelper _ConsecutivoHelper;

        public CnfEjecucionReportesRepository
        (
            ATSBIdentityDbContext context,
            IConsecutivoHelper ConsecutivoHelper
        ) : base()

        {
            _context = context;
            _ConsecutivoHelper = ConsecutivoHelper;
        }

        public IQueryable GetCnfEjecucionReportes()
        {
            return _context.CnfEjecucionreportes
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation) //Empresa
                .Include(s => s.CodigoEstadoNavigation) //Estado
                .Include(od => od.Codigo); //TipoOrigenDatos
        }

        public async Task<CnfEjecucionreporte> GetCnfEjecucionReporteAsync(int CodigoEmpresa, int Id)
        {
            return await _context.CnfEjecucionreportes.Where(x => x.CodigoEmpresa == CodigoEmpresa && x.Id == Id)
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation) //Empresa
                .Include(s => s.CodigoEstadoNavigation) //Estado
                .Include(od => od.Codigo) //TipoOrigenDatos
                .FirstOrDefaultAsync();
        }

        public async Task<Response<object>> AddCnfEjecucionReportesAsync(CnfEjecucionReportesRequest cnfEjecucionReportes)
        {
            try
            {

                var update = await _ConsecutivoHelper.updateConsecutivo(cnfEjecucionReportes.CodigoEmpresa, "CNF_EJECUCIONREPORTES");
                int consecutivo = await _ConsecutivoHelper.GetConsecutivo(cnfEjecucionReportes.CodigoEmpresa, "CNF_EJECUCIONREPORTES");

                var cnfejecucionreporte = new CnfEjecucionreporte
                {
                    CodigoEmpresa = cnfEjecucionReportes.CodigoEmpresa,
                    Id = consecutivo,
                    IdGrupo = cnfEjecucionReportes.IdGrupo,
                    Proceso = cnfEjecucionReportes.Proceso,
                    Nombre = cnfEjecucionReportes.Nombre,
                    Titulo = cnfEjecucionReportes.Titulo,
                    NombreHoja = cnfEjecucionReportes.NombreHoja,
                    Campos = cnfEjecucionReportes.Campos,
                    Tabla = cnfEjecucionReportes.Tabla,
                    Condicion = cnfEjecucionReportes.Condicion,
                    IndicadorFechaProceso = cnfEjecucionReportes.IndicadorFechaProceso == "true" ? true : false,
                    IndicadorIncluirTitulo = cnfEjecucionReportes.IndicadorIncluirTitulo == "true" ? true : false,
                    IndicadorIncluirEncabezados = cnfEjecucionReportes.IndicadorIncluirEncabezados == "true" ? true : false,
                    IndicadorFormato = cnfEjecucionReportes.IndicadorFormato == "true" ? true : false,
                    IndicadorAjustar = cnfEjecucionReportes.IndicadorAjustar == "true" ? true : false,
                    IndicadorIncluirFecha = cnfEjecucionReportes.IndicadorIncluirFecha == "true" ? true : false,
                    CodigoEstado = cnfEjecucionReportes.CodigoEstado,
                    IdUsuario = cnfEjecucionReportes.IdUsuario,
                    CodigoOrigenDatosSalida = cnfEjecucionReportes.CodigoOrigenDatosSalida

                };

                _context.CnfEjecucionreportes.Add(cnfejecucionreporte);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "La ejecucion reportes se creo con exito",
                    Result = cnfejecucionreporte
                });
            }
            catch (System.Exception)
            {
                throw new Exception("La ejecucion reportes no fue creada");
            }
        }

        public async Task<Response<object>> EditCnfEjecucionReportesAsync(CnfEjecucionReportesRequest cnfEjecucionReportes)
        {
            try
            {
                var exist = await _context.CnfEjecucionreportes.AnyAsync(x => x.CodigoEmpresa == cnfEjecucionReportes.CodigoEmpresa && x.Id == cnfEjecucionReportes.Id);
                if (!exist)
                {
                    return (new Response<object>
                    {
                        IsSuccess = false,
                        Message = "Registro no encontrado",
                        Result = null
                    });
                }

                var cnfejecucionreporte = new CnfEjecucionreporte
                {
                    CodigoEmpresa = cnfEjecucionReportes.CodigoEmpresa,
                    Id = cnfEjecucionReportes.Id,
                    IdGrupo = cnfEjecucionReportes.IdGrupo,
                    Proceso = cnfEjecucionReportes.Proceso,
                    Nombre = cnfEjecucionReportes.Nombre,
                    Titulo = cnfEjecucionReportes.Titulo,
                    NombreHoja = cnfEjecucionReportes.NombreHoja,
                    Campos = cnfEjecucionReportes.Campos,
                    Tabla = cnfEjecucionReportes.Tabla,
                    Condicion = cnfEjecucionReportes.Condicion,
                    IndicadorFechaProceso = cnfEjecucionReportes.IndicadorFechaProceso == "true" ? true : false,
                    IndicadorIncluirTitulo = cnfEjecucionReportes.IndicadorIncluirTitulo == "true" ? true : false,
                    IndicadorIncluirEncabezados = cnfEjecucionReportes.IndicadorIncluirEncabezados == "true" ? true : false,
                    IndicadorFormato = cnfEjecucionReportes.IndicadorFormato == "true" ? true : false,
                    IndicadorAjustar = cnfEjecucionReportes.IndicadorAjustar == "true" ? true : false,
                    IndicadorIncluirFecha = cnfEjecucionReportes.IndicadorIncluirFecha == "true" ? true : false,
                    CodigoEstado = cnfEjecucionReportes.CodigoEstado,
                    IdUsuario = cnfEjecucionReportes.IdUsuario,
                    CodigoOrigenDatosSalida = cnfEjecucionReportes.CodigoOrigenDatosSalida

                };

                _context.Update(cnfejecucionreporte);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "Registro actualizado",
                    Result = cnfejecucionreporte
                });
            }
            catch (System.Exception)
            {
                throw new Exception("La ejecucion reportes no fue modificada");
            }
        }

        public async Task<Response<object>> DeleteCnfEjecucionReportesAsync(CnfEjecucionReportesRequest cnfEjecucionReportes)
        {
            try
            {
                var existe = await _context.CnfEjecucionreportes.AnyAsync(x => x.CodigoEmpresa == cnfEjecucionReportes.CodigoEmpresa && x.Id == cnfEjecucionReportes.Id);
                if (!existe)
                {
                    return (new Response<Object>
                    {
                        IsSuccess = false,
                        Message = "El registro no existe",
                        Result = null
                    });
                }

                _context.Remove(new CnfEjecucionreporte() { CodigoEmpresa = cnfEjecucionReportes.CodigoEmpresa, Id = cnfEjecucionReportes.Id });
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "La ejecucion reportes fue eliminada",
                    Result = cnfEjecucionReportes
                });
            }
            catch (System.Exception)
            {
                throw new Exception("No se pudo eliminar la ejecucion reportes");
            }
        }
    }
}
