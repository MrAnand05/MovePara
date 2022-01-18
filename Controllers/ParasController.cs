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

        // GET: api/ParaLeft
        [HttpGet]

        [Route("ParaLeft")]
        public ActionResult<IEnumerable<ParaLeft>> GetparaLeft()
        {
            return _context.paraLeft.ToList();
        }

        // GET: api/ParaRight
        [HttpGet]

        [Route("ParaRight")]
        public ActionResult<IEnumerable<ParaRight>> GetparaRight()
        {
            return _context.paraRight.ToList();
        }

        // GET: api/ParaRightDesc
        [HttpGet]

        [Route("ParaRightDesc")]
        public ActionResult<IEnumerable<string>> GetparaRightDesc()
        {
            using(_context)
            {
                var res = from a in _context.paraRight
                          join b in _context.para on a.ParaId equals b.ParaId
                          select b.ParaText;
                return res.ToList();
            }
        }

        // GET: api/ParasRight
        [HttpPut]

        [Route("Initialize")]
        public void InitializeParaList()
        {
            using (_context)
            {
                var result =  _context.Database.ExecuteSqlRaw("Proc_Initilize");
            }
        }

        // GET: api/ParasRight

        [Route("Move/{id}")]

        [HttpPost]
        public void Move(string id)
        {
            var idParam = new SqlParameter("@ParaId", id);
            using (_context)
            {
                var result = _context.Database.ExecuteSqlRaw("Proc_Move @ParaId", idParam);
            }
        }
    }
}
