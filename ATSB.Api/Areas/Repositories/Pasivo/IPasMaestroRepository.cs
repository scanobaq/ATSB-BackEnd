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
    public interface IPasMaestroRepository
    {
        IQueryable GetPasMaestros();
        Task<PasMaestro> GetPasMaestroAsync(int CodigoEmpresa, string NumeroCuenta);
        Task<Response<object>> AddPasMaestroAsync(PasMaestroRequest pasMaestro);

        Task<Response<object>> EditPasMaestroAsync(PasMaestroRequest pasMaestro);
        Task<Response<object>> DeletePasMaestroAsync(PasMaestroRequest pasMaestro);
    }
}
