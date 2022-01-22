﻿#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovePara.Model;

namespace MovePara.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ParaLeftsController : ControllerBase
    {
        private readonly ParaDbContext _context;

        public ParaLeftsController(ParaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParaLeft>>> GetParaLeft()
        {
            return await _context.paraLeft.OrderBy(x=>x.Id).ToListAsync();
        }
    }
}