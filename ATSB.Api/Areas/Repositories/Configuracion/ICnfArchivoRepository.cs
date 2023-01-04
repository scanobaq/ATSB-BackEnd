using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATSB.Api.Areas.Entities.Configuracion;
using ATSB.Api.Models.Configuracion;
using ATSB.Models;

namespace ATSB.Api.Areas.Repositories.Configuracion
{
    public interface ICnfArchivoRepository
    {
        IQueryable GetCnfArchivos();
        Task<CnfArchivo> GetCnfArchivoAsync(int CodigoEmpresa, int IdArchivo);
        Task<Response<object>> AddCnfArchivoAsync(CnfArchivoRequest cnfArchivo);

        Task<Response<object>> EditCnfArchivoAsync(CnfArchivoRequest cnfArchivo);
        Task<Response<object>> DeleteCnfArchivoAsync(CnfArchivoRequest cnfArchivo);
    }
}
