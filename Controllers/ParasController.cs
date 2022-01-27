#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.FeatureManagement;
using MovePara.Model;

namespace MovePara.Controllers
{
    //TODO: Name of function and route to be same.
    [Route("[controller]")]
    [ApiController]
    public class ParasController : ControllerBase
    {
        private readonly ILogger<ParasController> _logger;
        private readonly IFeatureManager _featureManager;
        private readonly ParaDbContext _context;

        public ParasController(ILogger<ParasController> logger, IFeatureManager featureManager,
            ParaDbContext context)
        {
            this._logger = logger;
            this._featureManager = featureManager;
            _context = context;
        }

        [HttpDelete]

        [Route("Initialize")]
        public async Task<ActionResult<bool>> InitializeParaList()
        {
            var buttonColor = await _featureManager.IsEnabledAsync("ButtonColor");
            Console.WriteLine(buttonColor);
            await _context.Database.ExecuteSqlRawAsync("Proc_Initilize");
            return buttonColor;
        }

        [Route("Move")]

        [HttpPost]
        public async Task<IActionResult> Move(string id, string side)
        {
            var paraId = new SqlParameter("@ParaId", id);
            var sideId = new SqlParameter("@Side", side);
            await _context.Database.ExecuteSqlRawAsync("Proc_Move @ParaId, @Side", paraId, sideId);
            return NoContent();
        }

    }
}
