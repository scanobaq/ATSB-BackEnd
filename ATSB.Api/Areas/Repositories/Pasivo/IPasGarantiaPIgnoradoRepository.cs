using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATSB.Api.Areas.Entities.Pasivo;
using ATSB.Api.Models.Credito;
using ATSB.Api.Models.Pasivo;
using ATSB.Models;

namespace ATSB.Api.Areas.Repositories.Pasivo
{
    public interface IPasGarantiaPIgnoradoRepository
    {
        IQueryable GetPasGarantiasPIgnorado();
        Task<PasGarantiapignorado> GetPasGarantiaPIgnoradoAsync(int CodigoEmpresa, string NumeroCuenta, string NumeroOperacionGarantia);
        Task<Response<object>> AddPasGarantiaPIgnoradoAsync(PasGarantiaPIgnoradoRequest pasGarantiaPIgnorado);

        Task<Response<object>> EditPasGarantiaPIgnoradoAsync(PasGarantiaPIgnoradoRequest pasGarantiaPIgnorado);
        Task<Response<object>> DeletePasGarantiaPIgnoradoAsync(PasGarantiaPIgnoradoRequest pasGarantiaPIgnorado);
    }
}
