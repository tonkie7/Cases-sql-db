using Issues.Data;
using Issues.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Issues.Controllers
{
    [Route("api/cases")]
    [ApiController]
    public class CaseIssueController : ControllerBase
    {
        // dependency injection
        private readonly DataContext _context;

        public CaseIssueController(DataContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<IActionResult> Create(CaseIssue caseIssue)
        {
            try
            {
                _context.Add(caseIssue);
                await _context.SaveChangesAsync();
                return new OkResult();
            }
            catch ( Exception ex ) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();
        }

        [HttpGet] 
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return new OkObjectResult(await _context.Cases.ToListAsync());
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                return new OkObjectResult(await _context.Cases.FirstOrDefaultAsync(x => x.Id == id));
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();
        }
    }
}
