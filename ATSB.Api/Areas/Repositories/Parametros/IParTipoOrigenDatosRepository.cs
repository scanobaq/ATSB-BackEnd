using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATSB.Api.Areas.Entities.Parametros;
using ATSB.Api.Models.Parametros;
using ATSB.Models;

namespace ATSB.Api.Areas.Repositories.Parametros
{
    public interface IParTipoOrigenDatosRepository
    {
        IQueryable GetParTiposOrigenDatos();
        Task<ParTipoorigendato> GetParTipoOrigenDatosAsync(int CodigoEmpresa, int CodigoOrigenDatos);
        Task<Response<object>> AddParTipoOrigenDatosAsync(ParTipoOrigenDatosRequest parTipoOrigenDatos);

        Task<Response<object>> EditParTipoOrigenDatosAsync(ParTipoOrigenDatosRequest parTipoOrigenDatos);
        Task<Response<object>> DeleteParTipoOrigenDatosAsync(ParTipoOrigenDatosRequest parTipoOrigenDatos);
    }
}
