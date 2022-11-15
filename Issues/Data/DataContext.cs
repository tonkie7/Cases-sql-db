using Issues.Models;
using Microsoft.EntityFrameworkCore;

namespace Issues.Data
{
    // ärver från DBcontext från EFC
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

    // vilka tabeller jag vill ha och i det här fallet döper jag den till CaseIssues
    public DbSet<CaseIssue> Cases { get; set; }
    }
}
