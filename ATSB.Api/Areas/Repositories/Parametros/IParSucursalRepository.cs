using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATSB.Api.Areas.Entities.Parametros;
using ATSB.Api.Models.Parametros;
using ATSB.Models;

namespace ATSB.Api.Areas.Repositories.Parametros
{
    public interface IParSucursalRepository
    {
        IQueryable GetParSucursales();
        Task<ParSucursal> GetParSucursalAsync(int CodigoEmpresa, int CodigoBanco, int CodigoSucursal);
        Task<Response<object>> AddParSucursalAsync(ParSucursalRequest parSucursal);

        Task<Response<object>> EditParSucursalAsync(ParSucursalRequest parSucursal);
        Task<Response<object>> DeleteParSucursalAsync(ParSucursalRequest parSucursal);
    }
}
