#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MovePara.Model;

namespace MovePara.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ParasController : ControllerBase
    {
        private readonly ParaDbContext _context;

        public ParasController(ParaDbContext context)
        {
            _context = context;
        }

        [HttpPut]

        [Route("Initialize")]
        public async Task<IActionResult> InitializeParaList()
        {
            await _context.Database.ExecuteSqlRawAsync("Proc_Initilize");

            return NoContent();
        }


        [Route("Move/{id}")]

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
