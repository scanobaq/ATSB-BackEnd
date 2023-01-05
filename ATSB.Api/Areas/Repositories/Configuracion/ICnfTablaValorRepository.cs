using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATSB.Api.Areas.Entities.Configuracion;
using ATSB.Api.Models.Configuracion;
using ATSB.Models;

namespace ATSB.Api.Areas.Repositories.Configuracion
{
    public interface ICnfTablaValorRepository
    {
        IQueryable GetCnfTablaValores();
        Task<CnfTablavalor> GetCnfTablaValorAsync(int CodigoEmpresa, int CodigoTabla, int IdValor);
        Task<Response<object>> AddCnfTablaValorAsync(CnfTablaValorRequest cnfTablaValor);

        Task<Response<object>> EditCnfTablaValorAsync(CnfTablaValorRequest cnfTablaValor);
        Task<Response<object>> DeleteCnfTablaValorAsync(CnfTablaValorRequest cnfTablaValor);
    }
}
