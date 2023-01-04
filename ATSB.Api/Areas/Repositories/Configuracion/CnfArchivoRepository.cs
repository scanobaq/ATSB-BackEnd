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
    public class CnfArchivoRepository : ICnfArchivoRepository
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IConsecutivoHelper _ConsecutivoHelper;

        public CnfArchivoRepository
        (
            ATSBIdentityDbContext context,
            IConsecutivoHelper ConsecutivoHelper
        ) : base()

        {
            _context = context;
            _ConsecutivoHelper = ConsecutivoHelper;
        }

        public IQueryable GetCnfArchivos()
        {
            return _context.CnfArchivos
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation); //Empresa
        }

        public async Task<CnfArchivo> GetCnfArchivoAsync(int CodigoEmpresa, int IdArchivo)
        {
            return await _context.CnfArchivos.Where(x => x.CodigoEmpresa == CodigoEmpresa && x.IdArchivo == IdArchivo)
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation) //Empresa
                .FirstOrDefaultAsync();
        }
        
        public async Task<Response<object>> AddCnfArchivoAsync(CnfArchivoRequest cnfArchivo)
        {
            try
            {

                var update = await _ConsecutivoHelper.updateConsecutivo(cnfArchivo.CodigoEmpresa, "CNF_ARCHIVO");
                int consecutivo = await _ConsecutivoHelper.GetConsecutivo(cnfArchivo.CodigoEmpresa, "CNF_ARCHIVO");

                var cnfarchivo = new CnfArchivo
                {
                    CodigoEmpresa = cnfArchivo.CodigoEmpresa,
                    IdArchivo = consecutivo,
                    NombreArchivo = cnfArchivo.NombreArchivo,
                    DescripcionArchivo = cnfArchivo.DescripcionArchivo,
                    TablaDestino = cnfArchivo.TablaDestino,
                    IdUsuario = cnfArchivo.IdUsuario
                };

                _context.CnfArchivos.Add(cnfarchivo);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "El archivo se creo con exito",
                    Result = cnfarchivo
                });
            }
            catch (System.Exception)
            {
                throw new Exception("El archivo no fue creado");
            }
        }

        public async Task<Response<object>> EditCnfArchivoAsync(CnfArchivoRequest cnfArchivo)
        {
            try
            {
                var exist = await _context.CnfArchivos.AnyAsync(x => x.CodigoEmpresa == cnfArchivo.CodigoEmpresa && x.IdArchivo == cnfArchivo.IdArchivo);
                if (!exist)
                {
                    return (new Response<object>
                    {
                        IsSuccess = false,
                        Message = "Registro no encontrado",
                        Result = null
                    });
                }

                var cnfarchivo = new CnfArchivo
                {
                    CodigoEmpresa = cnfArchivo.CodigoEmpresa,
                    IdArchivo = cnfArchivo.IdArchivo,
                    NombreArchivo = cnfArchivo.NombreArchivo,
                    DescripcionArchivo = cnfArchivo.DescripcionArchivo,
                    TablaDestino = cnfArchivo.TablaDestino,
                    IdUsuario = cnfArchivo.IdUsuario
                };

                _context.Update(cnfarchivo);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "Registro actualizado",
                    Result = cnfarchivo
                });
            }
            catch (System.Exception)
            {
                throw new Exception("El archivo no fue modificado");
            }
        }

        public async Task<Response<object>> DeleteCnfArchivoAsync(CnfArchivoRequest cnfArchivo)
        {
            try
            {
                var existe = await _context.CnfArchivos.AnyAsync(x => x.CodigoEmpresa == cnfArchivo.CodigoEmpresa && x.IdArchivo == cnfArchivo.IdArchivo);
                if (!existe)
                {
                    return (new Response<Object>
                    {
                        IsSuccess = false,
                        Message = "El registro no existe",
                        Result = null
                    });
                }

                _context.Remove(new CnfArchivo() { CodigoEmpresa = cnfArchivo.CodigoEmpresa, IdArchivo = cnfArchivo.IdArchivo });
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "El archivo fue eliminado",
                    Result = cnfArchivo
                });
            }
            catch (System.Exception)
            {
                throw new Exception("No se pudo eliminar el archivo");
            }
        }
    }
}
