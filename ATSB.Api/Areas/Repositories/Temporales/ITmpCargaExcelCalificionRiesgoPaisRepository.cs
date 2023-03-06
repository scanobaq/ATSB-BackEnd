using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATSB.Api.Areas.Entities.Temporales;
using ATSB.Api.Models.Temporales;
using ATSB.Models;

namespace ATSB.Api.Areas.Repositories.Temporales
{
    public interface ITmpCargaExcelCalificionRiesgoPaisRepository
    {
        IQueryable GetTmpCargaExcelCalificionRiesgoPais();
        Task<TmpCargaExcelCalificionriesgopai> GetTmpCargaExcelCalificionRiesgoPaisAsync(Guid Llave);
    }
}
