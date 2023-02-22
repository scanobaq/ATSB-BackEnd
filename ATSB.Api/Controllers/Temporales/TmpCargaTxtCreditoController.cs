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
    public class TmpCargaTxtCreditoController : ControllerBase
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly ITmpCargaTxtCreditoRepository _TmpCargaTxtCreditoRepository;

        public TmpCargaTxtCreditoController(ATSBIdentityDbContext context, ITmpCargaTxtCreditoRepository TmpCargaTxtCreditoRepository)
        {
            _context = context;
            _TmpCargaTxtCreditoRepository = TmpCargaTxtCreditoRepository;
        }

        // GET: api/TmpCargaTxtCredito
        [HttpGet("GetTmpCargaTxtCreditos")]
        public async Task<string> GetTmpCargaTxtCreditos()
        {
            var dataTmpCargaTxtCreditos = _TmpCargaTxtCreditoRepository.GetTmpCargaTxtCreditos();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strTmpCargaTxtCreditos = JsonConvert.SerializeObject(dataTmpCargaTxtCreditos, options);

            return await Task.Run(() =>
            {
                return strTmpCargaTxtCreditos;
            });
        }

        // GET: api/TmpCargaTxtCredito/5
        [HttpGet("GetTmpCargaTxtCredito/{CodigoEmpresa}/{NumeroOperacion}")]
        public async Task<string> GetTmpCargaTxtCredito(int CodigoEmpresa, string NumeroOperacion)
        {
            var dataTmpCargaTxtCredito = await _TmpCargaTxtCreditoRepository.GetTmpCargaTxtCreditoAsync(CodigoEmpresa, NumeroOperacion);

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strTmpCargaTxtCredito = JsonConvert.SerializeObject(dataTmpCargaTxtCredito, options);

            return await Task.Run(() =>
            {
                return strTmpCargaTxtCredito;
            });
        }

        private bool TmpCargaTxtCreditoExists(int id)
        {
            return _context.TmpCargaTxtCreditos.Any(e => e.CodigoEmpresa == id);
        }
    }
}
