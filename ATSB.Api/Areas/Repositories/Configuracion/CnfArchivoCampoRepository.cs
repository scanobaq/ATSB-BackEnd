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
    public class CnfArchivoCampoRepository : ICnfArchivoCampoRepository
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IConsecutivoHelper _ConsecutivoHelper;

        public CnfArchivoCampoRepository
        (
            ATSBIdentityDbContext context,
            IConsecutivoHelper ConsecutivoHelper
        ) : base()

        {
            _context = context;
            _ConsecutivoHelper = ConsecutivoHelper;
        }

        public IQueryable GetCnfArchivoCampos()
        {
            return _context.CnfArchivocampos
                .AsNoTracking()
                .Include(e => e.CnfArchivo.CodigoEmpresaNavigation) //Empresa
                .Include(a => a.CnfArchivo) //Archivo
                .Include(s => s.CodigoEstadoNavigation); //Estado
        }

        public async Task<CnfArchivocampo> GetCnfArchivoCampoAsync(int CodigoEmpresa, int IdArchivo, int IdCampo)
        {
            return await _context.CnfArchivocampos.Where(x => x.CodigoEmpresa == CodigoEmpresa && x.IdArchivo == IdArchivo && x.IdCampo == IdCampo)
                .AsNoTracking()
                .Include(e => e.CnfArchivo.CodigoEmpresaNavigation) //Empresa
                .Include(a => a.CnfArchivo) //Archivo
                .Include(s => s.CodigoEstadoNavigation) //Estado
                .FirstOrDefaultAsync();

        }

        public async Task<Response<object>> AddCnfArchivoCampoAsync(CnfArchivoCampoRequest cnfArchivoCampo)
        {
            try
            {

                var cnfarchivocampo = new CnfArchivocampo
                {
                    CodigoEmpresa = cnfArchivoCampo.CodigoEmpresa,
                    IdArchivo = cnfArchivoCampo.IdArchivo,
                    IdCampo = cnfArchivoCampo.IdCampo,
                    IndicadorCampo = cnfArchivoCampo.IndicadorCampo == "true" ? true : false,
                    NombreCampo = cnfArchivoCampo.NombreCampo,
                    NombrePatron = cnfArchivoCampo.NombrePatron,
                    Patron = cnfArchivoCampo.Patron,
                    CondicionPatron = cnfArchivoCampo.CondicionPatron,
                    PosicionInicial = cnfArchivoCampo.PosicionInicial,
                    Largo = cnfArchivoCampo.Largo,
                    CodigoEstado = cnfArchivoCampo.CodigoEstado
                };

                _context.CnfArchivocampos.Add(cnfarchivocampo);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "El archivo campo se creo con exito",
                    Result = cnfarchivocampo
                });
            }
            catch (System.Exception)
            {
                throw new Exception("El archivo campo no fue creado");
            }
        }

        public async Task<Response<object>> EditCnfArchivoCampoAsync(CnfArchivoCampoRequest cnfArchivoCampo)
        {
            try
            {
                var exist = await _context.CnfArchivocampos.AnyAsync(x => x.CodigoEmpresa == cnfArchivoCampo.CodigoEmpresa && x.IdArchivo == cnfArchivoCampo.IdArchivo && x.IdCampo == cnfArchivoCampo.IdCampo);
                if (!exist)
                {
                    return (new Response<object>
                    {
                        IsSuccess = false,
                        Message = "Registro no encontrado",
                        Result = null
                    });
                }

                var cnfarchivocampo = new CnfArchivocampo
                {
                    CodigoEmpresa = cnfArchivoCampo.CodigoEmpresa,
                    IdArchivo = cnfArchivoCampo.IdArchivo,
                    IdCampo = cnfArchivoCampo.IdCampo,
                    IndicadorCampo = cnfArchivoCampo.IndicadorCampo == "true" ? true : false,
                    NombreCampo = cnfArchivoCampo.NombreCampo,
                    NombrePatron = cnfArchivoCampo.NombrePatron,
                    Patron = cnfArchivoCampo.Patron,
                    CondicionPatron = cnfArchivoCampo.CondicionPatron,
                    PosicionInicial = cnfArchivoCampo.PosicionInicial,
                    Largo = cnfArchivoCampo.Largo,
                    CodigoEstado = cnfArchivoCampo.CodigoEstado
                };

                _context.Update(cnfarchivocampo);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "Registro actualizado",
                    Result = cnfarchivocampo
                });
            }
            catch (System.Exception)
            {
                throw new Exception("El archivo campo no fue modificado");
            }
        }

        public async Task<Response<object>> DeleteCnfArchivoCampoAsync(CnfArchivoCampoRequest cnfArchivoCampo)
        {
            try
            {
                var existe = await _context.CnfArchivocampos.AnyAsync(x => x.CodigoEmpresa == cnfArchivoCampo.CodigoEmpresa && x.IdArchivo == cnfArchivoCampo.IdArchivo && x.IdCampo == cnfArchivoCampo.IdCampo);
                if (!existe)
                {
                    return (new Response<Object>
                    {
                        IsSuccess = false,
                        Message = "El registro no existe",
                        Result = null
                    });
                }

                _context.Remove(new CnfArchivocampo() { CodigoEmpresa = cnfArchivoCampo.CodigoEmpresa, IdArchivo = cnfArchivoCampo.IdArchivo, IdCampo = cnfArchivoCampo.IdCampo });
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "El archivo campo fue eliminado",
                    Result = cnfArchivoCampo
                });
            }
            catch (System.Exception)
            {
                throw new Exception("No se pudo eliminar el archivo campo");
            }
        }
    }
}
