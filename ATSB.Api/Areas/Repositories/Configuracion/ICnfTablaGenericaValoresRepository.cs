using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATSB.Api.Areas.Entities.Configuracion;
using ATSB.Api.Models.Configuracion;
using ATSB.Models;

namespace ATSB.Api.Areas.Repositories.Configuracion
{
    public interface ICnfTablaGenericaValoresRepository
    {
        IQueryable GetCnfTablasGenericasValores();
        Task<CnfTablagenericavalore> GetCnfTablaGenericaValoresAsync(int CodigoEmpresa, int IdTabla, int IdValor);
        Task<Response<object>> AddCnfTablaGenericaValoresAsync(CnfTablaGenericaValoresRequest cnfTablaGenericaValores);

        Task<Response<object>> EditCnfTablaGenericaValoresAsync(CnfTablaGenericaValoresRequest cnfTablaGenericaValores);
        Task<Response<object>> DeleteCnfTablaGenericaValoresAsync(CnfTablaGenericaValoresRequest cnfTablaGenericaValores);
    }
}
