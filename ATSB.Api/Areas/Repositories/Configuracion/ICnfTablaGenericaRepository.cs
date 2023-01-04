using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATSB.Api.Areas.Entities.Configuracion;
using ATSB.Api.Models.Configuracion;
using ATSB.Models;

namespace ATSB.Api.Areas.Repositories.Configuracion
{
    public interface ICnfTablaGenericaRepository
    {
        IQueryable GetCnfTablasGenericas();
        Task<CnfTablagenerica> GetCnfTablaGenericaAsync(int CodigoEmpresa, int IdTabla);
        Task<Response<object>> AddCnfTablaGenericaAsync(CnfTablaGenericaRequest cnfTablaGenerica);

        Task<Response<object>> EditCnfTablaGenericaAsync(CnfTablaGenericaRequest cnfTablaGenerica);
        Task<Response<object>> DeleteCnfTablaGenericaAsync(CnfTablaGenericaRequest cnfTablaGenerica);
    }
}
