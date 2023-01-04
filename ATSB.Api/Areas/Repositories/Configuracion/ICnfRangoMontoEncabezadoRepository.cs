using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATSB.Api.Areas.Entities.Configuracion;
using ATSB.Api.Models.Configuracion;
using ATSB.Models;

namespace ATSB.Api.Areas.Repositories.Configuracion
{
    public interface ICnfRangoMontoEncabezadoRepository
    {
        IQueryable GetCnfRangoMontosEncabezados();
        Task<CnfRangomontoencabezado> GetCnfRangoMontoEncabezadoAsync(int CodigoEmpresa, int CodigoTabla);
        Task<Response<object>> AddCnfRangoMontoEncabezadoAsync(CnfRangoMontoEncabezadoRequest cnfRangoMontoEncabezado);

        Task<Response<object>> EditCnfRangoMontoEncabezadoAsync(CnfRangoMontoEncabezadoRequest cnfRangoMontoEncabezado);
        Task<Response<object>> DeleteCnfRangoMontoEncabezadoAsync(CnfRangoMontoEncabezadoRequest cnfRangoMontoEncabezado);
    }
}
