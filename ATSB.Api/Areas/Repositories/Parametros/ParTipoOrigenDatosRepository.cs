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
    public class ParTipoOrigenDatosRepository : IParTipoOrigenDatosRepository
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IConsecutivoHelper _ConsecutivoHelper;

        public ParTipoOrigenDatosRepository
        (
            ATSBIdentityDbContext context,
            IConsecutivoHelper ConsecutivoHelper
        ) : base()

        {
            _context = context;
            _ConsecutivoHelper = ConsecutivoHelper;
        }

        public IQueryable GetParTiposOrigenDatos()
        {
            return _context.ParTipoorigendatos
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation); //Empresa
        }

        public async Task<ParTipoorigendato> GetParTipoOrigenDatosAsync(int CodigoEmpresa, int CodigoOrigenDatos)
        {
            return await _context.ParTipoorigendatos.Where(x => x.CodigoEmpresa == CodigoEmpresa && x.CodigoOrigenDatos == CodigoOrigenDatos)
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation) //Empresa
                .FirstOrDefaultAsync();
        }

        public async Task<Response<object>> AddParTipoOrigenDatosAsync(ParTipoOrigenDatosRequest parTipoOrigenDatos)
        {
            try
            {
                var update = await _ConsecutivoHelper.updateConsecutivo(parTipoOrigenDatos.CodigoEmpresa, "PAR_TIPOORIGENDATOS");
                int consecutivo = await _ConsecutivoHelper.GetConsecutivo(parTipoOrigenDatos.CodigoEmpresa, "PAR_TIPOORIGENDATOS");

                var partipoorigendatos = new ParTipoorigendato
                {
                    CodigoEmpresa = parTipoOrigenDatos.CodigoEmpresa,
                    CodigoOrigenDatos = consecutivo,
                    Descripcion = parTipoOrigenDatos.Descripcion,
                    DelimitadorDatos = parTipoOrigenDatos.DelimitadorDatos
                };

                _context.ParTipoorigendatos.Add(partipoorigendatos);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "El tipo origen datos se creo con exito",
                    Result = partipoorigendatos
                });
            }
            catch (System.Exception)
            {
                throw new Exception("El tipo origen datos no fue creado");
            }
        }

        public async Task<Response<object>> EditParTipoOrigenDatosAsync(ParTipoOrigenDatosRequest parTipoOrigenDatos)
        {
            try
            {
                var exist = await _context.ParTipoorigendatos.AnyAsync(x => x.CodigoEmpresa == parTipoOrigenDatos.CodigoEmpresa && x.CodigoOrigenDatos == parTipoOrigenDatos.CodigoOrigenDatos);
                if (!exist)
                {
                    return (new Response<object>
                    {
                        IsSuccess = false,
                        Message = "Registro no encontrado",
                        Result = null
                    });
                }

                var partipoorigendatos = new ParTipoorigendato
                {
                    CodigoEmpresa = parTipoOrigenDatos.CodigoEmpresa,
                    CodigoOrigenDatos = parTipoOrigenDatos.CodigoOrigenDatos,
                    Descripcion = parTipoOrigenDatos.Descripcion,
                    DelimitadorDatos = parTipoOrigenDatos.DelimitadorDatos
                };

                _context.Update(partipoorigendatos);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "Registro actualizado",
                    Result = partipoorigendatos
                });
            }
            catch (System.Exception)
            {
                throw new Exception("El tipo origen datos no fue modificado");
            }
        }

        public async Task<Response<object>> DeleteParTipoOrigenDatosAsync(ParTipoOrigenDatosRequest parTipoOrigenDatos)
        {
            try
            {
                var existe = await _context.ParTipoorigendatos.AnyAsync(x => x.CodigoEmpresa == parTipoOrigenDatos.CodigoEmpresa && x.CodigoOrigenDatos == parTipoOrigenDatos.CodigoOrigenDatos);
                if (!existe)
                {
                    return (new Response<Object>
                    {
                        IsSuccess = false,
                        Message = "El registro no existe",
                        Result = null
                    });
                }

                _context.Remove(new ParTipoorigendato() { CodigoEmpresa = parTipoOrigenDatos.CodigoEmpresa, CodigoOrigenDatos = parTipoOrigenDatos.CodigoOrigenDatos });
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "El tipo origen datos fue eliminado",
                    Result = parTipoOrigenDatos
                });
            }
            catch (System.Exception)
            {
                throw new Exception("No se pudo eliminar el tipo origen datos");
            }
        }
    }
}
