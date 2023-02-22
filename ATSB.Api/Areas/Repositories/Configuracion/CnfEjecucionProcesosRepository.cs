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
    public class CnfEjecucionProcesosRepository : ICnfEjecucionProcesosRepository
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IConsecutivoHelper _ConsecutivoHelper;
        private readonly IArchivosInventarioHelper _ArchivosInventarioHelper;

        public CnfEjecucionProcesosRepository
        (
            ATSBIdentityDbContext context,
            IConsecutivoHelper ConsecutivoHelper,
            IArchivosInventarioHelper ArchivosInventarioHelper
        ) : base()

        {
            _context = context;
            _ConsecutivoHelper = ConsecutivoHelper;
            _ArchivosInventarioHelper = ArchivosInventarioHelper;
        }

        public IQueryable GetCnfEjecucionProcesos()
        {
            return _context.CnfEjecucionprocesos
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation) //Empresa
                .Include(p => p.CodigoNavigation) //Proceso
                .Include(od => od.Codigo) //TipoOrigenDatos
                .Include(s => s.CodigoEstadoNavigation); //Estado
        }

        public async Task<CnfEjecucionproceso> GetCnfEjecucionProcesoAsync(int CodigoEmpresa, int CodigoProceso, int SecuenciaProceso)
        {
            return await _context.CnfEjecucionprocesos.Where(x => x.CodigoEmpresa == CodigoEmpresa && x.CodigoProceso == CodigoProceso && x.SecuenciaProceso == SecuenciaProceso)
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation) //Empresa
                .Include(p => p.CodigoNavigation) //Proceso
                .Include(od => od.Codigo) //TipoOrigenDatos
                .Include(s => s.CodigoEstadoNavigation) //Estado
                .FirstOrDefaultAsync();
        }

        public async Task<Response<object>> AddCnfEjecucionProcesoAsync(CnfEjecucionProcesoRequest cnfEjecucionProceso)
        {
            try
            {

                var cnfejecucionproceso = new CnfEjecucionproceso
                {
                    CodigoEmpresa = cnfEjecucionProceso.CodigoEmpresa,
                    CodigoProceso = cnfEjecucionProceso.CodigoProceso,
                    SecuenciaProceso = cnfEjecucionProceso.SecuenciaProceso,
                    Descripcion = cnfEjecucionProceso.Descripcion,
                    CodigoOrigenDatos = cnfEjecucionProceso.CodigoOrigenDatos,
                    TablaDestino = cnfEjecucionProceso.TablaDestino,
                    DescripcionOrigenDatos = cnfEjecucionProceso.DescripcionOrigenDatos,
                    BorrarAntes = cnfEjecucionProceso.BorrarAntes == "true" ? true : false,
                    EjecutaProcedimiento = cnfEjecucionProceso.EjecutaProcedimiento,
                    Condicion = cnfEjecucionProceso.Condicion,
                    TieneEnbabezado = cnfEjecucionProceso.TieneEnbabezado == "true" ? true : false,
                    CantidadLineasEncabezado = cnfEjecucionProceso.CantidadLineasEncabezado,
                    ProcesoRequerido = cnfEjecucionProceso.ProcesoRequerido == "true" ? true : false,
                    CodigoEstado = cnfEjecucionProceso.CodigoEstado,
                    IndicadorPaquete = cnfEjecucionProceso.IndicadorPaquete == "true" ? true : false
                };

                _context.CnfEjecucionprocesos.Add(cnfejecucionproceso);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "La ejecucion proceso se creo con exito",
                    Result = cnfejecucionproceso
                });
            }
            catch (System.Exception)
            {
                throw new Exception("La ejecucion proceso no fue creada");
            }
        }

        public async Task<Response<object>> EditCnfEjecucionProcesosAsync(CnfEjecucionProcesoRequest cnfEjecucionProceso)
        {
            try
            {
                var exist = await _context.CnfEjecucionprocesos.AnyAsync(x => x.CodigoEmpresa == cnfEjecucionProceso.CodigoEmpresa && x.CodigoProceso == cnfEjecucionProceso.CodigoProceso && x.SecuenciaProceso == cnfEjecucionProceso.SecuenciaProceso);
                if (!exist)
                {
                    return (new Response<object>
                    {
                        IsSuccess = false,
                        Message = "Registro no encontrado",
                        Result = null
                    });
                }

                var cnfejecucionproceso = new CnfEjecucionproceso
                {
                    CodigoEmpresa = cnfEjecucionProceso.CodigoEmpresa,
                    CodigoProceso = cnfEjecucionProceso.CodigoProceso,
                    SecuenciaProceso = cnfEjecucionProceso.SecuenciaProceso,
                    Descripcion = cnfEjecucionProceso.Descripcion,
                    CodigoOrigenDatos = cnfEjecucionProceso.CodigoOrigenDatos,
                    TablaDestino = cnfEjecucionProceso.TablaDestino,
                    DescripcionOrigenDatos = cnfEjecucionProceso.DescripcionOrigenDatos,
                    BorrarAntes = cnfEjecucionProceso.BorrarAntes == "true" ? true : false,
                    EjecutaProcedimiento = cnfEjecucionProceso.EjecutaProcedimiento,
                    Condicion = cnfEjecucionProceso.Condicion,
                    TieneEnbabezado = cnfEjecucionProceso.TieneEnbabezado == "true" ? true : false,
                    CantidadLineasEncabezado = cnfEjecucionProceso.CantidadLineasEncabezado,
                    ProcesoRequerido = cnfEjecucionProceso.ProcesoRequerido == "true" ? true : false,
                    CodigoEstado = cnfEjecucionProceso.CodigoEstado,
                    IndicadorPaquete = cnfEjecucionProceso.IndicadorPaquete == "true" ? true : false
                };

                _context.Update(cnfejecucionproceso);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "Registro actualizado",
                    Result = cnfejecucionproceso
                });
            }
            catch (System.Exception)
            {
                throw new Exception("La ejecucion proceso no fue modificada");
            }
        }

        public async Task<Response<object>> DeleteCnfEjecucionProcesosAsync(CnfEjecucionProcesoRequest cnfEjecucionProceso)
        {
            try
            {
                var existe = await _context.CnfEjecucionprocesos.AnyAsync(x => x.CodigoEmpresa == cnfEjecucionProceso.CodigoEmpresa && x.CodigoProceso == cnfEjecucionProceso.CodigoProceso && x.SecuenciaProceso == cnfEjecucionProceso.SecuenciaProceso);
                if (!existe)
                {
                    return (new Response<Object>
                    {
                        IsSuccess = false,
                        Message = "El registro no existe",
                        Result = null
                    });
                }

                _context.Remove(new CnfEjecucionproceso() { CodigoEmpresa = cnfEjecucionProceso.CodigoEmpresa, CodigoProceso = cnfEjecucionProceso.CodigoProceso, SecuenciaProceso = cnfEjecucionProceso.SecuenciaProceso });
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "La ejecucion proceso fue eliminada",
                    Result = cnfEjecucionProceso
                });
            }
            catch (System.Exception)
            {
                throw new Exception("No se pudo eliminar la ejecucion proceso");
            }
        }
    }
}
