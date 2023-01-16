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
using ATSB.Api.Areas.Entities.Contable;
using ATSB.Api.Models.Contable;

namespace ATSB.Api.Areas.Repositories.Contable
{
    public class ConBalanceHistoricoRepository : IConBalanceHistoricoRepository
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IConsecutivoHelper _ConsecutivoHelper;

        public ConBalanceHistoricoRepository
        (
            ATSBIdentityDbContext context,
            IConsecutivoHelper ConsecutivoHelper
        ) : base()

        {
            _context = context;
            _ConsecutivoHelper = ConsecutivoHelper;
        }

        public IQueryable GetConBalancesHistorico()
        {
            return _context.ConBalancehistoricos
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation); //Empresa
        }

        public async Task<ConBalancehistorico> GetConBalanceHistoricoAsync(int CodigoEmpresa, DateTime Fecha, int CodigoCuentaContable)
        {
            return await _context.ConBalancehistoricos.Where(x => x.CodigoEmpresa == CodigoEmpresa && x.Fecha == Fecha && x.CodigoCuentaContable == CodigoCuentaContable)
                .AsNoTracking()
                .Include(e => e.CodigoEmpresaNavigation) //Empresa
                .FirstOrDefaultAsync();
        }

        public async Task<Response<object>> AddConBalanceHistoricoAsync(ConBalanceHistoricoRequest conBalanceHistorico)
        {
            try
            {

                var conbalancehistorico = new ConBalancehistorico
                {
                    CodigoEmpresa = conBalanceHistorico.CodigoEmpresa,
                    Fecha = conBalanceHistorico.Fecha,
                    CodigoCuentaContable = conBalanceHistorico.CodigoCuentaContable,
                    SaldoInicio = conBalanceHistorico.SaldoInicio,
                    Debito = conBalanceHistorico.Debito,
                    Credito = conBalanceHistorico.Credito,
                    DiferenciaSaldos = conBalanceHistorico.DiferenciaSaldos,
                    SaldoFinal = conBalanceHistorico.SaldoFinal,
                    IdUsuario = conBalanceHistorico.IdUsuario
                };

                _context.ConBalancehistoricos.Add(conbalancehistorico);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "El balance historico se creo con exito",
                    Result = conbalancehistorico
                });
            }
            catch (System.Exception)
            {
                throw new Exception("El balance historico no fue creado");
            }
        }

        public async Task<Response<object>> EditConBalanceHistoricoAsync(ConBalanceHistoricoRequest conBalanceHistorico)
        {
            try
            {
                var exist = await _context.ConBalancehistoricos.AnyAsync(x => x.CodigoEmpresa == conBalanceHistorico.CodigoEmpresa && x.Fecha == conBalanceHistorico.Fecha && x.CodigoCuentaContable == conBalanceHistorico.CodigoCuentaContable);
                if (!exist)
                {
                    return (new Response<object>
                    {
                        IsSuccess = false,
                        Message = "Registro no encontrado",
                        Result = null
                    });
                }

                var conbalancehistorico = new ConBalancehistorico
                {
                    CodigoEmpresa = conBalanceHistorico.CodigoEmpresa,
                    Fecha = conBalanceHistorico.Fecha,
                    CodigoCuentaContable = conBalanceHistorico.CodigoCuentaContable,
                    SaldoInicio = conBalanceHistorico.SaldoInicio,
                    Debito = conBalanceHistorico.Debito,
                    Credito = conBalanceHistorico.Credito,
                    DiferenciaSaldos = conBalanceHistorico.DiferenciaSaldos,
                    SaldoFinal = conBalanceHistorico.SaldoFinal,
                    IdUsuario = conBalanceHistorico.IdUsuario
                };

                _context.Update(conbalancehistorico);
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "Registro actualizado",
                    Result = conbalancehistorico
                });
            }
            catch (System.Exception)
            {
                throw new Exception("El balance historico no fue modificado");
            }
        }

        public async Task<Response<object>> DeleteConBalanceHistoricoAsync(ConBalanceHistoricoRequest conBalanceHistorico)
        {
            try
            {
                var existe = await _context.ConBalancehistoricos.AnyAsync(x => x.CodigoEmpresa == conBalanceHistorico.CodigoEmpresa && x.Fecha == conBalanceHistorico.Fecha && x.CodigoCuentaContable == conBalanceHistorico.CodigoCuentaContable);
                if (!existe)
                {
                    return (new Response<Object>
                    {
                        IsSuccess = false,
                        Message = "El registro no existe",
                        Result = null
                    });
                }

                _context.Remove(new ConBalancehistorico() { CodigoEmpresa = conBalanceHistorico.CodigoEmpresa, Fecha = conBalanceHistorico.Fecha, CodigoCuentaContable = conBalanceHistorico.CodigoCuentaContable });
                await _context.SaveChangesAsync();

                return (new Response<object>
                {
                    IsSuccess = true,
                    Message = "El balance historico fue eliminado",
                    Result = conBalanceHistorico
                });
            }
            catch (System.Exception)
            {
                throw new Exception("No se pudo eliminar el balance historico");
            }
        }
    }
}
