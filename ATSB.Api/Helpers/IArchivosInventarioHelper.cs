using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ATSB.Api.Areas.Entities.Tools.Generales;
using ATSB.Api.Areas.Identity.Data;
using ATSB.Api.Helpers;
using NuGet.Packaging;
using ATSB.Api.Areas.Entities.Configuracion;
using ATSB.Models;

namespace ATSB.Api.Helpers
{
    public interface IArchivosInventarioHelper
    {
        List<string> ValidarInventarioArchivosProceso(int CodigoProceso, string Ruta);
        Task<Response<object>> CopiaArchivosAServidor(string Ruta, DateTime FechaProceso);
    }
}
