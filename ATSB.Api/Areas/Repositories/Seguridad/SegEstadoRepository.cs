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
    public class SegEstadoRepository : ISegEstadoRepository
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IConsecutivoHelper _ConsecutivoHelper;

        public SegEstadoRepository
        (
            ATSBIdentityDbContext context,
            IConsecutivoHelper ConsecutivoHelper
        ) : base()

        {
            _context = context;
            _ConsecutivoHelper = ConsecutivoHelper;
        }

        public IQueryable GetSegEstados()
        {
            return _context.SegEstados
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation); //Empresa
        }

        public async Task<SegEstado> GetSegEstadoAsync(int CodigoEmpresa, string CodigoEstado)
        {
            return await _context.SegEstados.Where(x => x.CodigoEmpresa == CodigoEmpresa && x.CodigoEstado == CodigoEstado)
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation) //Empresa
                .FirstOrDefaultAsync();
        }

        public async Task<Response<object>> AddSegEstadoAsync(SegEstadoRequest segEstado)
        {
            try
            {
                var segestado = new SegEstado
                {
                    CodigoEmpresa = segEstado.CodigoEmpresa,
                    CodigoEstado = segEstado.CodigoEstado,  
                    Descripcion = segEstado.Descripcion
                };

                _context.SegEstados.Add(segestado);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "El estado se creo con exito",
                    Result = segestado
                });
            }
            catch (System.Exception)
            {
                throw new Exception("El estado no fue creado");
            }
        }

        public async Task<Response<object>> EditSegEstadoAsync(SegEstadoRequest segEstado)
        {
            try
            {
                var exist = await _context.SegEstados.AnyAsync(x => x.CodigoEmpresa == segEstado.CodigoEmpresa && x.CodigoEstado == segEstado.CodigoEstado);
                if (!exist)
                {
                    return (new Response<object>
                    {
                        IsSuccess = false,
                        Message = "Registro no encontrado",
                        Result = null
                    });
                }

                var segestado = new SegEstado
                {
                    CodigoEmpresa = segEstado.CodigoEmpresa,
                    CodigoEstado = segEstado.CodigoEstado,
                    Descripcion = segEstado.Descripcion
                };

                _context.Update(segestado);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "Registro actualizado",
                    Result = segestado
                });
            }
            catch (System.Exception)
            {
                throw new Exception("El estado no fue modificado");
            }
        }

        public async Task<Response<object>> DeleteSegEstadoAsync(SegEstadoRequest segEstado)
        {
            try
            {
                var existe = await _context.SegEstados.AnyAsync(x => x.CodigoEmpresa == segEstado.CodigoEmpresa && x.CodigoEstado == segEstado.CodigoEstado);
                if (!existe)
                {
                    return (new Response<Object>
                    {
                        IsSuccess = false,
                        Message = "El registro no existe",
                        Result = null
                    });
                }

                _context.Remove(new SegEstado() { CodigoEmpresa = segEstado.CodigoEmpresa, CodigoEstado = segEstado.CodigoEstado });
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "El estado fue eliminado",
                    Result = segEstado
                });
            }
            catch (System.Exception)
            {
                throw new Exception("No se pudo eliminar el estado");
            }
        }
    }
}
