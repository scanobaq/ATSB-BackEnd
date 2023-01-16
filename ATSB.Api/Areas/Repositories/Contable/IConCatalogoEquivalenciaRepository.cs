using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATSB.Api.Areas.Entities.Configuracion;
using ATSB.Api.Areas.Entities.Contable;
using ATSB.Api.Models.Configuracion;
using ATSB.Api.Models.Contable;
using ATSB.Models;

namespace ATSB.Api.Areas.Repositories.Contable
{
    public interface IConCatalogoEquivalenciaRepository
    {
        IQueryable GetConCatalogosEquivalencia();
        Task<ConCatalogoequivalencium> GetConCatalogoEquivalenciaAsync(int CodigoEmpresa, int IdCuenta);
        Task<Response<object>> AddConCatalogoEquivalenciaAsync(ConCatalogoEquivalenciaRequest conCatalogoEquivalencia);

        Task<Response<object>> EditConCatalogoEquivalenciaAsync(ConCatalogoEquivalenciaRequest conCatalogoEquivalencia);
        Task<Response<object>> DeleteConCatalogoEquivalenciaAsync(ConCatalogoEquivalenciaRequest conCatalogoEquivalencia);
    }
}
