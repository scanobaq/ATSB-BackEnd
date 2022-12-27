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
    public class ParEmpresaRepository : IParEmpresaRepository
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IConsecutivoHelper _ConsecutivoHelper;

        public ParEmpresaRepository
        (
            ATSBIdentityDbContext context,
            IConsecutivoHelper ConsecutivoHelper
        ) : base()

        {
            _context = context;
            _ConsecutivoHelper = ConsecutivoHelper;
        }

        public IQueryable GetParEmpresas()
        {
            return _context.ParEmpresas
                .AsNoTracking()
                .Include(ti => ti.Codigo) //TipoIdentificacion
                .Include(s => s.CodigoEstadoNavigation) //Estado
                .Include(p => p.CodigoPaisNavigation); //Pais
        }

        public async Task<ParEmpresa> GetParEmpresaAsync(int CodigoEmpresa)
        {
            return await _context.ParEmpresas.Where(x => x.CodigoEmpresa == CodigoEmpresa)
                .AsNoTracking()
                .Include(ti => ti.Codigo) //TipoIdentificacion
                .Include(s => s.CodigoEstadoNavigation) //Estado
                .Include(p => p.CodigoPaisNavigation) //Pais
                .FirstOrDefaultAsync();
        }

        public async Task<Response<object>> AddParEmpresaAsync(ParEmpresaRequest parEmpresa)
        {
            try
            {
                var update = await _ConsecutivoHelper.updateConsecutivo(0, "PAR_EMPRESA");
                int consecutivo = await _ConsecutivoHelper.GetConsecutivo(0, "PAR_EMPRESA");

                var parempresa = new ParEmpresa
                {
                    CodigoEmpresa = consecutivo, //parEmpresa.CodigoEmpresa
                    Nombre = parEmpresa.Nombre,
                    NumeroId = parEmpresa.NumeroId,
                    Telefono1 = parEmpresa.Telefono1,
                    Telefono2 = parEmpresa.Telefono2,
                    FechaIngreso = parEmpresa.FechaIngreso,
                    IdUsuario = parEmpresa.IdUsuario,
                    FechaUltimaModificacion = parEmpresa.FechaUltimaModificacion,
                    UsuarioModifica = parEmpresa.UsuarioModifica,
                    CantidadModificaciones = parEmpresa.CantidadModificaciones,
                    CodigoTipoIdentificacion = parEmpresa.CodigoTipoIdentificacion,
                    CodigoPais = parEmpresa.CodigoPais,
                    CodigoEstado = parEmpresa.CodigoEstado,
                    CodigoBancoRegulador = parEmpresa.CodigoBancoRegulador
                };

                _context.ParEmpresas.Add(parempresa);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "La empresa se creo con exito",
                    Result = parempresa
                });
            }
            catch (System.Exception)
            {
                throw new Exception("La empresa no fue creada");
            }
        }

        public async Task<Response<object>> EditParEmpresaAsync(ParEmpresaRequest parEmpresa)
        {
            try
            {
                var exist = await _context.ParEmpresas.AnyAsync(x => x.CodigoEmpresa == parEmpresa.CodigoEmpresa);
                if (!exist)
                {
                    return (new Response<object>
                    {
                        IsSuccess = false,
                        Message = "Registro no encontrado",
                        Result = null
                    });
                }

                var parempresa = new ParEmpresa
                {
                    CodigoEmpresa = parEmpresa.CodigoEmpresa,
                    Nombre = parEmpresa.Nombre,
                    NumeroId = parEmpresa.NumeroId,
                    Telefono1 = parEmpresa.Telefono1,
                    Telefono2 = parEmpresa.Telefono2,
                    FechaIngreso = parEmpresa.FechaIngreso,
                    IdUsuario = parEmpresa.IdUsuario,
                    FechaUltimaModificacion = parEmpresa.FechaUltimaModificacion,
                    UsuarioModifica = parEmpresa.UsuarioModifica,
                    CantidadModificaciones = parEmpresa.CantidadModificaciones,
                    CodigoTipoIdentificacion = parEmpresa.CodigoTipoIdentificacion,
                    CodigoPais = parEmpresa.CodigoPais,
                    CodigoEstado = parEmpresa.CodigoEstado,
                    CodigoBancoRegulador = parEmpresa.CodigoBancoRegulador
                };

                _context.Update(parempresa);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "Registro actualizado",
                    Result = parempresa
                });
            }
            catch (System.Exception)
            {
                throw new Exception("La empresa no fue modificada");
            }
        }

        public async Task<Response<object>> DeleteParEmpresaAsync(ParEmpresaRequest parEmpresa)
        {
            try
            {
                var existe = await _context.ParEmpresas.AnyAsync(x => x.CodigoEmpresa == parEmpresa.CodigoEmpresa);
                if (!existe)
                {
                    return (new Response<Object>
                    {
                        IsSuccess = false,
                        Message = "El registro no existe",
                        Result = null
                    });
                }

                _context.Remove(new ParEmpresa() { CodigoEmpresa = parEmpresa.CodigoEmpresa });
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "La empresa fue eliminada",
                    Result = parEmpresa
                });
            }
            catch (System.Exception)
            {
                throw new Exception("No se pudo eliminar la empresa");
            }
        }
    }
}
