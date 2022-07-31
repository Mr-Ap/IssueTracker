using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_EF_IssueTracker.Data;
using WebAPI_EF_IssueTracker.Model;

namespace WebAPI_EF_IssueTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueController : ControllerBase
    {
        private readonly IssueDbContext _issueDbContext;
        public IssueController(IssueDbContext issueDbContext)
        {
            _issueDbContext = issueDbContext;
        }

        [HttpGet]
        public async Task<IEnumerable<Issue>> Get() => await _issueDbContext.Issues.ToListAsync();

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var issue = await _issueDbContext.Issues.FindAsync(keyValues: id);
            return issue == null ? NotFound() : Ok(issue);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateIssue(Issue issue)
        {
            await _issueDbContext.Issues.AddAsync(issue);
            await _issueDbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = issue.Id }, issue);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateIssue(int id, Issue issue)
        {
            if(id != issue.Id)
                return BadRequest();
            //_issueDbContext.Issues.Update(issue);
            _issueDbContext.Entry(issue).State = EntityState.Modified;
            await _issueDbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteIssue(int id)
        {
            var issue = await _issueDbContext.Issues.FindAsync(keyValues: id);
            if (issue == null) NotFound();
            _issueDbContext.Issues.Remove(issue);
            await _issueDbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
