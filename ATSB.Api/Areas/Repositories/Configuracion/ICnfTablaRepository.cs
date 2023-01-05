using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATSB.Api.Areas.Entities.Configuracion;
using ATSB.Api.Models.Configuracion;
using ATSB.Models;

namespace ATSB.Api.Areas.Repositories.Configuracion
{
    public interface ICnfTablaRepository
    {
        IQueryable GetCnfTablas();
        Task<CnfTabla> GetCnfTablaAsync(int CodigoEmpresa, int CodigoTabla);
        Task<Response<object>> AddCnfTablaAsync(CnfTablaRequest cnfTabla);

        Task<Response<object>> EditCnfTablaAsync(CnfTablaRequest cnfTabla);
        Task<Response<object>> DeleteCnfTablaAsync(CnfTablaRequest cnfTabla);
    }
}
