#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovePara.Model;

namespace MovePara.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ParaRightsController : ControllerBase
    {
        private readonly ParaDbContext _context;

        public ParaRightsController(ParaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParaRight>>> GetParaRight()
        {
            return await _context.paraRight.OrderBy(x => x.Id).ToListAsync();
        }

        [HttpGet]

        [Route("Desc")]
        public async Task<ActionResult<string>> GetParaRightDesc()
        {
            var res= await _context.paraRight.Join(_context.para,pr=>pr.ParaId, p=>p.ParaId, (pr,p)=>new { Id = pr.Id, ParaText = p.ParaText }).OrderBy(x=>x.Id).ToListAsync();

            return string.Join(System.Environment.NewLine, res);
        }

    }
}
