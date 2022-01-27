#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovePara.Model;
using Newtonsoft.Json.Linq;

namespace MovePara.Controllers
{
    [Route("[controller]")]
    [ApiController]

    //TODO: Return only Id's from ParaRight.
    //TODO: use select in ParaRight Desc.
    public class ParaRightsController : ControllerBase
    {
        private readonly ILogger<ParasController> _logger;
        private readonly ParaDbContext _context;

        public ParaRightsController(ILogger<ParasController> logger, ParaDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParaRight>>> GetParaRight()
        {
            return await _context.paraRight.OrderBy(x => x.Id).ToListAsync();
        }

        [HttpPost]
        [Route("LogButtonColor")]
        public async Task<ActionResult> LogButtonColor(bool buttonColor)
        {
            _logger.LogWarning(buttonColor?"Red":"Blue", buttonColor);
            return NoContent();
        }

        [HttpGet]

        [Route("Desc")]
        public async Task<ActionResult<string>> GetParaRightDesc()
        {
            var res= await _context.paraRight.Join(_context.para,pr=>pr.ParaId, p=>p.ParaId, (pr,p)=>new { Id = pr.Id, ParaText = p.ParaText })
                    .OrderBy(x=>x.Id).ToListAsync();
            return string.Join(System.Environment.NewLine, res.Select(x=>x.ParaText));
        }

    }
}
