using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ATSB.Api.Areas.Entities.Contable;
using ATSB.Api.Areas.Identity.Data;
using System.Text.Json;
using Newtonsoft.Json;
using ATSB.Api.Areas.Repositories.Contable;
using ATSB.Models;
using ATSB.Api.Models.Contable;
using Microsoft.EntityFrameworkCore.Metadata;
using ATSB.Api.Areas.Entities.Configuracion;

namespace ATSB.Api.Controllers.Contable
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConBalancecomparativoController : ControllerBase
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly IConBalanceComparativoRepository _ConBalanceComparativoRepository;

        public ConBalancecomparativoController(ATSBIdentityDbContext context, IConBalanceComparativoRepository ConBalanceComparativoRepository)
        {
            _context = context;
            _ConBalanceComparativoRepository = ConBalanceComparativoRepository;
        }

        // GET: api/ConBalancecomparativo
        [HttpGet("GetConBalancesComparativos")]
        public async Task<string> GetConBalancecomparativos()
        {
            var dataConBalancesComparativos = _ConBalanceComparativoRepository.GetConBalancesComparativos();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strBalancesComparativos = JsonConvert.SerializeObject(dataConBalancesComparativos, options);

            return await Task.Run(() =>
            {
                return strBalancesComparativos;
            });
        }

        // GET: api/ConBalancecomparativo/5
        [HttpGet("GetConBalanceComparativo/{Llave}")]
        public async Task<string> GetConBalancecomparativo(Guid Llave)
        {
            var conBalanceComparativo = await _ConBalanceComparativoRepository.GetConBalanceComparativoAsync(Llave);

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strBalanceComparativo = JsonConvert.SerializeObject(conBalanceComparativo, options);

            return await Task.Run(() =>
            {
                return strBalanceComparativo;
            });
        }

        private bool ConBalancecomparativoExists(Guid id)
        {
            return _context.ConBalancecomparativos.Any(e => e.Llave == id);
        }
    }
}
