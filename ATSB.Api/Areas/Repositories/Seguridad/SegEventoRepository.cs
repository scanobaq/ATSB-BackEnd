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
    public class SegEventoRepository : ISegEventoRepository
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IConsecutivoHelper _ConsecutivoHelper;

        public SegEventoRepository
        (
            ATSBIdentityDbContext context,
            IConsecutivoHelper ConsecutivoHelper
        ) : base()

        {
            _context = context;
            _ConsecutivoHelper = ConsecutivoHelper;
        }

        public IQueryable GetSegEventos()
        {
            return _context.SegEventos
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation); //Empresa
        }

        public async Task<SegEvento> GetSegEventoAsync(int CodigoEmpresa, int idEvento)
        {
            return await _context.SegEventos.Where(x => x.CodigoEmpresa == CodigoEmpresa && x.IdEvento == idEvento)
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation) //Empresa
                .FirstOrDefaultAsync();
        }
        
        public async Task<Response<object>> AddSegEventoAsync(SegEventoRequest segEvento)
        {
            try
            {
                var update = await _ConsecutivoHelper.updateConsecutivo(segEvento.CodigoEmpresa, "SEG_EVENTO");
                int consecutivo = await _ConsecutivoHelper.GetConsecutivo(segEvento.CodigoEmpresa, "SEG_EVENTO");

                var segevento = new SegEvento
                {
                    CodigoEmpresa = segEvento.CodigoEmpresa,
                    IdEvento = consecutivo,
                    Descripción = segEvento.Descripción
                };

                _context.SegEventos.Add(segevento);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "El evento se creo con exito",
                    Result = segevento
                });
            }
            catch (System.Exception)
            {
                throw new Exception("El evento no fue creado");
            }
        }

        public async Task<Response<object>> EditSegEventoAsync(SegEventoRequest segEvento)
        {
            try
            {
                var exist = await _context.SegEventos.AnyAsync(x => x.CodigoEmpresa == segEvento.CodigoEmpresa && x.IdEvento == segEvento.IdEvento);
                if (!exist)
                {
                    return (new Response<object>
                    {
                        IsSuccess = false,
                        Message = "Registro no encontrado",
                        Result = null
                    });
                }

                var segevento = new SegEvento
                {
                    CodigoEmpresa = segEvento.CodigoEmpresa,
                    IdEvento = segEvento.IdEvento,
                    Descripción = segEvento.Descripción
                };

                _context.Update(segevento);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "Registro actualizado",
                    Result = segevento
                });
            }
            catch (System.Exception)
            {
                throw new Exception("El evento no fue modificado");
            }
        }
        
        public async Task<Response<object>> DeleteSegEventoAsync(SegEventoRequest segEvento)
        {
            try
            {
                var existe = await _context.SegEventos.AnyAsync(x => x.CodigoEmpresa == segEvento.CodigoEmpresa && x.IdEvento == segEvento.IdEvento);
                if (!existe)
                {
                    return (new Response<Object>
                    {
                        IsSuccess = false,
                        Message = "El registro no existe",
                        Result = null
                    });
                }

                _context.Remove(new SegEvento() { CodigoEmpresa = segEvento.CodigoEmpresa, IdEvento = segEvento.IdEvento });
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "El evento fue eliminado",
                    Result = segEvento
                });
            }
            catch (System.Exception)
            {
                throw new Exception("No se pudo eliminar el evento");
            }
        }
    }
}
