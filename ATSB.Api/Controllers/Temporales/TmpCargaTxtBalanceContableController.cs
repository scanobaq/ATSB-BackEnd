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
    public class TmpCargaTxtBalanceContableController : ControllerBase
    {
        private readonly ATSBIdentityDbContext _context;
        private readonly ITmpCargaTxtBalanceContableRepository _TmpCargaTxtBalanceContableRepository;

        public TmpCargaTxtBalanceContableController(ATSBIdentityDbContext context, ITmpCargaTxtBalanceContableRepository TmpCargaTxtBalanceContableRepository)
        {
            _context = context;
            _TmpCargaTxtBalanceContableRepository = TmpCargaTxtBalanceContableRepository;
        }

        // GET: api/TmpCargaTxtBalanceContable
        [HttpGet("GetTmpCargaTxtBalancesContables")]
        public async Task<string> GetTmpCargaTxtBalancecontables()
        {
            var dataTmpCargaTxtBalancesContables = _TmpCargaTxtBalanceContableRepository.GetTmpCargaTxtBalancesContables();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strTmpCargaTxtBalancesContables = JsonConvert.SerializeObject(dataTmpCargaTxtBalancesContables, options);

            return await Task.Run(() =>
            {
                return strTmpCargaTxtBalancesContables;
            });
        }

        // GET: api/TmpCargaTxtBalanceContable/5
        [HttpGet("GetTmpCargaTxtBalanceContable/{CodigoEmpresa}/{Fecha}/{Cuenta}")]
        public async Task<string> GetTmpCargaTxtBalancecontable(int CodigoEmpresa, string Fecha, string Cuenta)
        {
            var dataTmpCargaTxtBalanceContable = await _TmpCargaTxtBalanceContableRepository.GetTmpCargaTxtBalanceContableAsync(CodigoEmpresa, Fecha, Cuenta);

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string strTmpCargaTxtBalanceContable = JsonConvert.SerializeObject(dataTmpCargaTxtBalanceContable, options);

            return await Task.Run(() =>
            {
                return strTmpCargaTxtBalanceContable;
            });
        }

        // PUT: api/TmpCargaTxtBalanceContable/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTmpCargaTxtBalancecontable(int id, TmpCargaTxtBalancecontable tmpCargaTxtBalancecontable)
        {
            if (id != tmpCargaTxtBalancecontable.CodigoEmpresa)
            {
                return BadRequest();
            }

            _context.Entry(tmpCargaTxtBalancecontable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TmpCargaTxtBalancecontableExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TmpCargaTxtBalanceContable
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TmpCargaTxtBalancecontable>> PostTmpCargaTxtBalancecontable(TmpCargaTxtBalancecontable tmpCargaTxtBalancecontable)
        {
            _context.TmpCargaTxtBalancecontables.Add(tmpCargaTxtBalancecontable);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TmpCargaTxtBalancecontableExists(tmpCargaTxtBalancecontable.CodigoEmpresa))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTmpCargaTxtBalancecontable", new { id = tmpCargaTxtBalancecontable.CodigoEmpresa }, tmpCargaTxtBalancecontable);
        }

        // DELETE: api/TmpCargaTxtBalanceContable/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTmpCargaTxtBalancecontable(int id)
        {
            var tmpCargaTxtBalancecontable = await _context.TmpCargaTxtBalancecontables.FindAsync(id);
            if (tmpCargaTxtBalancecontable == null)
            {
                return NotFound();
            }

            _context.TmpCargaTxtBalancecontables.Remove(tmpCargaTxtBalancecontable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TmpCargaTxtBalancecontableExists(int id)
        {
            return _context.TmpCargaTxtBalancecontables.Any(e => e.CodigoEmpresa == id);
        }
    }
}
