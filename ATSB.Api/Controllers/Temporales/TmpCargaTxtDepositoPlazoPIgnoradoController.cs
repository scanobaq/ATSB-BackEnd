using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ATSB.Api.Areas.Entities.Temporales;
using ATSB.Api.Areas.Identity.Data;
using System.Text.Json;
using Newtonsoft.Json;
using ATSB.Api.Areas.Repositories.Temporales;
using ATSB.Models;
using ATSB.Api.Models.Temporales;
using System.Text.Json.Serialization.Metadata;
using ATSB.Api.Areas.Entities.Parametros;

namespace ATSB.Api.Controllers.Temporales
{
    [Route("api/[controller]")]
    [ApiController]
    public class TmpCargaTxtDepositoPlazoPIgnoradoController : ControllerBase
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly ITmpCargaTxtDepositoPlazoPIgnoradoRepository _TmpCargaTxtDepositoPlazoPIgnoradoRepository;

        public TmpCargaTxtDepositoPlazoPIgnoradoController(ATSBIdentityDbContext context, ITmpCargaTxtDepositoPlazoPIgnoradoRepository TmpCargaTxtDepositoPlazoPIgnoradoRepository)
        {
            _context = context;
            _TmpCargaTxtDepositoPlazoPIgnoradoRepository = TmpCargaTxtDepositoPlazoPIgnoradoRepository;
        }

        // GET: api/TmpCargaTxtDepositoPlazoPIgnorado
        [HttpGet("GetTmpCargaTxtDepositoPlazosPIgnorados")]
        public async Task<string> GetTmpCargaTxtDepositoplazopignorados()
        {
            var dataTmpCargaTxtDepositoPlazosPIgnorados = _TmpCargaTxtDepositoPlazoPIgnoradoRepository.GetTmpCargaTxtDepositoPlazosPIgnorados();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strTmpCargaTxtDepositoPlazosPIgnorados = JsonConvert.SerializeObject(dataTmpCargaTxtDepositoPlazosPIgnorados, options);

            return await Task.Run(() =>
            {
                return strTmpCargaTxtDepositoPlazosPIgnorados;
            });
        }

        // GET: api/TmpCargaTxtDepositoPlazoPIgnorado/5
        [HttpGet("GetTmpCargaTxtDepositoPlazoPIgnorado/{CodigoEmpresa}/{NumeroCuenta}")]
        public async Task<string> GetTmpCargaTxtDepositoplazopignorado(int CodigoEmpresa, string NumeroCuenta)
        {
            var dataTmpCargaTxtDepositoPlazoPIgnorado = await _TmpCargaTxtDepositoPlazoPIgnoradoRepository.GetTmpCargaTxtDepositoPlazoPIgnoradoAsync(CodigoEmpresa, NumeroCuenta);

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strTmpCargaTxtDepositoPlazoPIgnorado = JsonConvert.SerializeObject(dataTmpCargaTxtDepositoPlazoPIgnorado, options);

            return await Task.Run(() =>
            {
                return strTmpCargaTxtDepositoPlazoPIgnorado;
            });
        }

        private bool TmpCargaTxtDepositoplazopignoradoExists(int id)
        {
            return _context.TmpCargaTxtDepositoplazopignorados.Any(e => e.CodigoEmpresa == id);
        }
    }
}
