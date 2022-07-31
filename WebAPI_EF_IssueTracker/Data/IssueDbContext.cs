using Microsoft.EntityFrameworkCore;
using WebAPI_EF_IssueTracker.Model;

namespace WebAPI_EF_IssueTracker.Data
{
    public class IssueDbContext:DbContext
    {
        public IssueDbContext(DbContextOptions<IssueDbContext> options):base(options)
        {

        }

        public DbSet<Issue> Issues { get; set; }
    }
}
