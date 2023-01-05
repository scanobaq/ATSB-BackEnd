using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATSB.Api.Areas.Entities.Configuracion;
using ATSB.Api.Models.Configuracion;
using ATSB.Models;

namespace ATSB.Api.Areas.Repositories.Configuracion
{
    public interface ICnfArchivoCampoRepository
    {
        IQueryable GetCnfArchivoCampos();
        Task<CnfArchivocampo> GetCnfArchivoCampoAsync(int CodigoEmpresa, int IdArchivo, int IdCampo);
        Task<Response<object>> AddCnfArchivoCampoAsync(CnfArchivoCampoRequest cnfArchivoCampo);

        Task<Response<object>> EditCnfArchivoCampoAsync(CnfArchivoCampoRequest cnfArchivoCampo);
        Task<Response<object>> DeleteCnfArchivoCampoAsync(CnfArchivoCampoRequest cnfArchivoCampo);
    }
}
