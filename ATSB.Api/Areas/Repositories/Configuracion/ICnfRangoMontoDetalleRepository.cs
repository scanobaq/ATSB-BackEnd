using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATSB.Api.Areas.Entities.Configuracion;
using ATSB.Api.Models.Configuracion;
using ATSB.Models;

namespace ATSB.Api.Areas.Repositories.Configuracion
{
    public interface ICnfRangoMontoDetalleRepository
    {
        IQueryable GetCnfRangoMontosDetalles();
        Task<CnfRangomontodetalle> GetCnfRangoMontoDetalleAsync(int CodigoEmpresa, int CodigoTabla, string CodigoRango);
        Task<Response<object>> AddCnfRangoMontoDetalleAsync(CnfRangoMontoDetalleRequest cnfRangoMontoDetalle);

        Task<Response<object>> EditCnfRangoMontoDetalleAsync(CnfRangoMontoDetalleRequest cnfRangoMontoDetalle);
        Task<Response<object>> DeleteCnfRangoMontoDetalleAsync(CnfRangoMontoDetalleRequest cnfRangoMontoDetalle);
    }
}
