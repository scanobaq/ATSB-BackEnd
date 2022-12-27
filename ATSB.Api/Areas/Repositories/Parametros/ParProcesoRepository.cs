using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATSB.Api.Models.Parametros;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ATSB.Api.Areas.Identity.Data;
using ATSB.Models;
using ATSB.Api.Areas.Entities.Parametros;
using ATSB.Api.Helpers;

namespace ATSB.Api.Areas.Repositories.Parametros
{
    public class ParProcesoRepository : IParProcesoRepository
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IConsecutivoHelper _ConsecutivoHelper;

        public ParProcesoRepository
        (
            ATSBIdentityDbContext context,
            IConsecutivoHelper ConsecutivoHelper
        ) : base()

        {
            _context = context;
            _ConsecutivoHelper = ConsecutivoHelper;
        }

        public IQueryable GetParProcesos()
        {
            return _context.ParProcesos
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation); //Empresa
        }

        public async Task<ParProceso> GetParProcesoAsync(int CodigoEmpresa, int CodigoProceso)
        {
            return await _context.ParProcesos.Where(x => x.CodigoEmpresa == CodigoEmpresa && x.CodigoProceso == CodigoProceso)
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation)
                .FirstOrDefaultAsync();
        }

        public async Task<Response<object>> AddParProcesoAsync(ParProcesoRequest parProceso)
        {
            try
            {
                var update = await _ConsecutivoHelper.updateConsecutivo(parProceso.CodigoEmpresa, "PAR_PROCESO");
                int consecutivo = await _ConsecutivoHelper.GetConsecutivo(parProceso.CodigoEmpresa, "PAR_PROCESO");

                var parproceso = new ParProceso
                {
                    CodigoEmpresa = parProceso.CodigoEmpresa,
                    CodigoProceso = consecutivo,
                    Descripcion = parProceso.Descripcion,
                    NombreProceso = parProceso.NombreProceso,
                    TablaDestino = parProceso.TablaDestino
                };

                _context.ParProcesos.Add(parproceso);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "El proceso se creo con exito",
                    Result = parproceso
                });
            }
            catch (System.Exception)
            {
                throw new Exception("El proceso no fue creado");
            }
        }

        public async Task<Response<object>> EditParProcesoAsync(ParProcesoRequest parProceso)
        {
            try
            {
                var exist = await _context.ParProcesos.AnyAsync(x => x.CodigoEmpresa == parProceso.CodigoEmpresa && x.CodigoProceso == parProceso.CodigoProceso);
                if (!exist)
                {
                    return (new Response<object>
                    {
                        IsSuccess = false,
                        Message = "Registro no encontrado",
                        Result = null
                    });
                }

                var parproceso = new ParProceso
                {
                    CodigoEmpresa = parProceso.CodigoEmpresa,
                    CodigoProceso = parProceso.CodigoProceso,
                    Descripcion = parProceso.Descripcion,
                    NombreProceso = parProceso.NombreProceso,
                    TablaDestino = parProceso.TablaDestino
                };

                _context.Update(parproceso);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "Registro actualizado",
                    Result = parproceso
                });
            }
            catch (System.Exception)
            {
                throw new Exception("El proceso no fue modificado");
            }
        }

        public async Task<Response<object>> DeleteParProcesoAsync(ParProcesoRequest parProceso)
        {
            try
            {
                var existe = await _context.ParProcesos.AnyAsync(x => x.CodigoEmpresa == parProceso.CodigoEmpresa && x.CodigoProceso == parProceso.CodigoProceso);
                if (!existe)
                {
                    return (new Response<Object>
                    {
                        IsSuccess = false,
                        Message = "El registro no existe",
                        Result = null
                    });
                }

                _context.Remove(new ParProceso() { CodigoEmpresa = parProceso.CodigoEmpresa, CodigoProceso = parProceso.CodigoProceso });
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "El proceso fue eliminado",
                    Result = parProceso
                });
            }
            catch (System.Exception)
            {
                throw new Exception("No se pudo eliminar el proceso");
            }
        }
    }
}
