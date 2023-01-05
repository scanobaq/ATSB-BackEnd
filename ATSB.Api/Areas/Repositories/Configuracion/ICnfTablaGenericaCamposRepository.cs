using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATSB.Api.Areas.Entities.Configuracion;
using ATSB.Api.Models.Configuracion;
using ATSB.Models;

namespace ATSB.Api.Areas.Repositories.Configuracion
{
    public interface ICnfTablaGenericaCamposRepository
    {
        IQueryable GetCnfTablasGenericasCampos();
        Task<CnfTablagenericacampo> GetCnfTablaGenericaCamposAsync(int CodigoEmpresa, int IdTabla, string IdCampo);
        Task<Response<object>> AddCnfTablaGenericaCamposAsync(CnfTablaGenericaCamposRequest cnfTablaGenericaCampos);

        Task<Response<object>> EditCnfTablaGenericaCamposAsync(CnfTablaGenericaCamposRequest cnfTablaGenericaCampos);
        Task<Response<object>> DeleteCnfTablaGenericaCamposAsync(CnfTablaGenericaCamposRequest cnfTablaGenericaCampos);
    }
}
