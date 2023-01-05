using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATSB.Api.Areas.Entities.Configuracion;
using ATSB.Api.Models.Configuracion;
using ATSB.Models;

namespace ATSB.Api.Areas.Repositories.Configuracion
{
    public interface ICnfCalificacionRiesgoEquivalenciaRepository
    {
        IQueryable GetCnfCalificacionRiesgoEquivalencias();
        Task<CnfCalificacionriesgoequivalencium> GetCnfCalificacionRiesgoEquivalenciaAsync(int CodigoEmpresa, string CalificacionOrigen);
        Task<Response<object>> AddCnfCalificacionRiesgoEquivalenciaAsync(CnfCalificacionRiesgoEquivalenciaRequest cnfCalificacionRiesgoEquivalencia);

        Task<Response<object>> EditCnfCalificacionRiesgoEquivalenciaAsync(CnfCalificacionRiesgoEquivalenciaRequest cnfCalificacionRiesgoEquivalencia);
        Task<Response<object>> DeleteCnfCalificacionRiesgoEquivalenciaAsync(CnfCalificacionRiesgoEquivalenciaRequest cnfCalificacionRiesgoEquivalencia);
    }
}
